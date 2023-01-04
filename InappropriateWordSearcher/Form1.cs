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

namespace InappropriateWordSearcher
{
    public partial class Form1 : Form
    {

        public readonly string TEMP_PATH = Path.Combine(Path.GetTempPath(), "WordSearcher");

        public Form1()
        {
            InitializeComponent();
        }


        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.URL = @"D:\Ziegfred\Downloads\One Piece Film Red (CAM - 1080p Eng Sub) V2.mkv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"D:\Ziegfred\Downloads";
                openFileDialog.Filter = "Video Files(*.mp4)|*.mp4";
                //openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    axWindowsMediaPlayer1.URL = openFileDialog.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(axWindowsMediaPlayer1.URL))
            {
                MessageBox.Show("Please upload video");
                return;
            }
            scanButton.Text = "Scanning";
            scanButton.Enabled= false;
            var transcriptGenerator = new TranscriptGenerator();
            Process process = transcriptGenerator.GenerateTranscriptProcess(axWindowsMediaPlayer1.URL);
            process.Exited += new EventHandler(_processExited);
            process.Start();
        }

        private void _processExited(object sender, System.EventArgs e)
        {
            string fileName = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            string jsonFilePath = Path.Combine(TEMP_PATH, $"{fileName}.en.json");
            if (File.Exists(jsonFilePath)) 
            {
                List<TranscriptChunk> transcript = TranscriptSerializer.Deserialize(jsonFilePath);
                foreach(var t in transcript)
                {
                    string[] words = t.content.Split(' ');
                    foreach(var word in words)
                    {
                        if(!string.IsNullOrWhiteSpace(word))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                listBox1.Items.Add(new WordClass
                                {
                                    Word = word,
                                    StartTime = t.start,
                                    EndTime = t.end
                                });
                            }));
                        }
                        
                        
                    }
                }
            }
            this.Invoke(new MethodInvoker(delegate
            {
                scanButton.Text = "Scan";
                scanButton.Enabled = true;
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

        private void hashButton_Click(object sender, EventArgs e)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(axWindowsMediaPlayer1.URL))
                {
                    byte[] hash = sha256.ComputeHash(stream);
                    MessageBox.Show(Encoding.UTF8.GetString(hash));
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
