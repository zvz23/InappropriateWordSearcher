using InappropriateWordSearcher.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace InappropriateWordSearcher
{
    public partial class Main : Form
    {

        public List<WordClass> LastWords = new List<WordClass>();
        public Main()
        {
            InitializeComponent();
            filterComboBox.SelectedIndex = 0;
            

        }

        private void _loadAppDependencies()
        {
            using(var webClient = new WebClient())
            {
            }
        }
       
        private void _processExited(object sender, System.EventArgs e)
        {
            string fileName = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            string jsonFilePath = Path.Combine(AppConstants.ABS_TEMP_FOLDER, $"{fileName}.en.json");
            if (File.Exists(jsonFilePath)) 
            {
                string videoHash = FileHashGenerator.GetFileHash(axWindowsMediaPlayer1.URL);
                var dbContext = new AppDBContext();
                string hasTranscript = dbContext.GetTranscript(videoHash);
                string transcriptJson = File.ReadAllText(jsonFilePath);
                if (hasTranscript == null)
                {
                    dbContext.SaveTranscript(videoHash, transcriptJson);
                }
                else
                {
                    dbContext.UpdateTranscript(videoHash, transcriptJson);
                }
                
                List<TranscriptChunk> transcript = TranscriptSerializer.DeserializeFile(jsonFilePath);
                this.Invoke(new MethodInvoker(delegate
                {
                    _loadWords(transcript);
                }));

            }
            this.Invoke(new MethodInvoker(delegate
            {
                scanButton.Text = "Scan";
                scanButton.Enabled = true;
                uploadButton.Enabled = true;
                MessageBox.Show("The scan has completed");
            }));
            
        }

        private void _setDefaultControlState()
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.EndUpdate();
            uploadButton.Enabled = true;
            scanButton.Enabled = true;
            scanButton.Text = "Scan";
            analyzeButton.Enabled = true;
            toxicityValueLabel.Text = "N/A";
            identityAttackValueLabel.Text = "N/A";
            insultValueLabel.Text = "N/A";
            profanityValueLabel.Text = "N/A";
            threatValueLabel.Text = "N/A";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                WordClass word = (WordClass)listBox1.SelectedItem;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = word.StartTime;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                openFileDialog.Filter = "Video Files(*.mp4)|*.mp4";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    axWindowsMediaPlayer1.URL = openFileDialog.FileName;
                    _setDefaultControlState();
                }
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(axWindowsMediaPlayer1.URL))
            {
                MessageBox.Show("Please upload video");
                return;
            }

            string videoHash = FileHashGenerator.GetFileHash(axWindowsMediaPlayer1.URL);
            var dbContext = new AppDBContext();
            string hasTranscript = dbContext.GetTranscript(videoHash);
            if (hasTranscript != null)
            {
                DialogResult result = MessageBox.Show("There was a scan performed before, do you want to reuse its data?", "Information", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<TranscriptChunk> transcript = TranscriptSerializer.Deserialize(hasTranscript);
                    _loadWords(transcript);
                    return;
                }
            }

            scanButton.Text = "Scanning";
            scanButton.Enabled = false;
            uploadButton.Enabled = false;
            var transcriptGenerator = new TranscriptGenerator();
            string fileName = $"{Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL)}.en.json";
            if (File.Exists(Path.Combine(AppConstants.ABS_TEMP_FOLDER, fileName)))
            {
                File.Delete(Path.Combine(AppConstants.ABS_TEMP_FOLDER, fileName));
            }
            Process process = transcriptGenerator.GenerateTranscriptProcess(axWindowsMediaPlayer1.URL);
            process.Exited += new EventHandler(_processExited);
            process.Start();
        }

        private void _loadWords(List<TranscriptChunk> transcript)
        {
            LastWords.Clear();
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            AppDBContext appDBContext = new AppDBContext();
            foreach (var t in transcript)
            {
                string[] words = t.content.Split(' ');
                
                foreach (var word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        WordClass wordClass = new WordClass()
                        {
                            Word = word,
                            StartTime = t.start,
                            EndTime = t.end,
                            IsProfane = appDBContext.IsProfane(word)
                        };
                        LastWords.Add(wordClass);
                        
                    }
                }
                listBox1.Items.AddRange(LastWords.ToArray());
                listBox1.EndUpdate();
            }
        }

        private async void analyzeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(axWindowsMediaPlayer1.URL))
            {
                MessageBox.Show("Please upload and scan a video");
                return;
            }
            string videoHash = FileHashGenerator.GetFileHash(axWindowsMediaPlayer1.URL);
            AppDBContext dbContext = new AppDBContext();

            string rawTranscript = dbContext.GetTranscript(videoHash);
            if (rawTranscript == null)
            {
                MessageBox.Show("Please scan a video");
                return;
            }
            analyzeButton.Text = "Analyzing";
            analyzeButton.Enabled = false;
            List<TranscriptChunk> transcript = JsonConvert.DeserializeObject<List<TranscriptChunk>>(rawTranscript);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var t in transcript)
            {
                stringBuilder.Append($" {t.content}");
            }
            PerspectiveAPI perspectiveAPI = new PerspectiveAPI();
            ScoreResponse scoreResponse = await perspectiveAPI.AnaylizeText(stringBuilder.ToString());
            toxicityValueLabel.Text = $"{scoreResponse.attributeScores.TOXICITY.summaryScore.value[2]} of 10 people";
            identityAttackValueLabel.Text = $"{scoreResponse.attributeScores.IDENTITY_ATTACK.summaryScore.value[2]} of 10 people";
            insultValueLabel.Text = $"{scoreResponse.attributeScores.INSULT.summaryScore.value[2]} of 10 people";
            profanityValueLabel.Text = $"{scoreResponse.attributeScores.PROFANITY.summaryScore.value[2]} of 10 people";
            threatValueLabel.Text = $"{scoreResponse.attributeScores.THREAT.summaryScore.value[2]} of 10 people";
            analyzeButton.Text = "Analyze Transcript";
            analyzeButton.Enabled = true;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                WordClass[] searchResult = LastWords.Where(w => w.Word.ToLower().Contains(searchBox.Text.ToLower())).ToArray();
                listBox1.Items.AddRange(searchResult);
            }
            else
            {
                listBox1.Items.AddRange(LastWords.ToArray());
            }

            listBox1.EndUpdate();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a word from the list");
                return;
            }
            using (ExtractForm extractForm = new ExtractForm())
            {
                extractForm.SelectedItem = (WordClass)listBox1.SelectedItem;
                extractForm.VideoURL = axWindowsMediaPlayer1.URL;
                extractForm.ShowDialog(this);
            }


        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            if (filterComboBox.Text == "Profane")
            {
                WordClass[] searchResult = LastWords.Where(w => w.IsProfane).ToArray();
                listBox1.Items.AddRange(searchResult);
            }
            else
            {
                listBox1.Items.AddRange(LastWords.ToArray());
            }

            listBox1.EndUpdate();
        }
    }

    public class WordClass
    {
        public string Word { get; set; }
        public double StartTime { get; set; }
        public double EndTime { get; set; }
        public bool IsProfane { get; set; } = false;


        public override string ToString()
        {
            return Word;
        }
    }
}
