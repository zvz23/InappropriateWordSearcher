using InappropriateWordSearcher.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace InappropriateWordSearcher
{
    public partial class Form1 : Form
    {

        public readonly string TEMP_PATH = Path.Combine(Path.GetTempPath(), "WordSearcher");

        public Form1()
        {
            InitializeComponent();
        }


       
        private void _processExited(object sender, System.EventArgs e)
        {
            string fileName = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            string jsonFilePath = Path.Combine(TEMP_PATH, $"{fileName}.en.json");
            if (File.Exists(jsonFilePath)) 
            {
                string videoHash = FileHashGenerator.GetFileHash(axWindowsMediaPlayer1.URL);
                var dbContext = new TranscriptHistoryDbContext();
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
                //openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    axWindowsMediaPlayer1.URL = openFileDialog.FileName;
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
            var dbContext = new TranscriptHistoryDbContext();
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
            foreach (var t in transcript)
            {
                string[] words = t.content.Split(' ');
                foreach (var word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        listBox1.Items.Add(new WordClass
                        {
                            Word = word,
                            StartTime = t.start,
                            EndTime = t.end
                        });
                        
                    }
                }
            }
        }
    }

    public class WordClass
    {
        public string Word { get; set; }
        public double StartTime { get; set; }
        public double EndTime { get; set; }


        public override string ToString()
        {
            return Word;
        }
    }
}
