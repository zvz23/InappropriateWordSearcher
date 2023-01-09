﻿namespace InappropriateWordSearcher
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.uploadButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.analyzeResultLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toxicityValueLabel = new System.Windows.Forms.Label();
            this.identityAttackValueLabel = new System.Windows.Forms.Label();
            this.insultValueLabel = new System.Windows.Forms.Label();
            this.profanityValueLabel = new System.Windows.Forms.Label();
            this.threatValueLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(43, 290);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 1;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(567, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(303, 238);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(124, 290);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 3;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "List of words:";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(43, 51);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(418, 233);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(751, 319);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(119, 23);
            this.analyzeButton.TabIndex = 5;
            this.analyzeButton.Text = "Analyze Transcript";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // analyzeResultLabel
            // 
            this.analyzeResultLabel.AutoSize = true;
            this.analyzeResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzeResultLabel.Location = new System.Drawing.Point(567, 358);
            this.analyzeResultLabel.Name = "analyzeResultLabel";
            this.analyzeResultLabel.Size = new System.Drawing.Size(56, 16);
            this.analyzeResultLabel.TabIndex = 6;
            this.analyzeResultLabel.Text = "Toxicity:";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(567, 48);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(135, 20);
            this.searchBox.TabIndex = 7;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(567, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Identity Attack: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(567, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Insult:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(567, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Profanity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(567, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Threat:";
            // 
            // toxicityValueLabel
            // 
            this.toxicityValueLabel.AutoSize = true;
            this.toxicityValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toxicityValueLabel.Location = new System.Drawing.Point(709, 358);
            this.toxicityValueLabel.Name = "toxicityValueLabel";
            this.toxicityValueLabel.Size = new System.Drawing.Size(30, 16);
            this.toxicityValueLabel.TabIndex = 12;
            this.toxicityValueLabel.Text = "N/A";
            // 
            // identityAttackValueLabel
            // 
            this.identityAttackValueLabel.AutoSize = true;
            this.identityAttackValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identityAttackValueLabel.Location = new System.Drawing.Point(709, 385);
            this.identityAttackValueLabel.Name = "identityAttackValueLabel";
            this.identityAttackValueLabel.Size = new System.Drawing.Size(30, 16);
            this.identityAttackValueLabel.TabIndex = 13;
            this.identityAttackValueLabel.Text = "N/A";
            // 
            // insultValueLabel
            // 
            this.insultValueLabel.AutoSize = true;
            this.insultValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insultValueLabel.Location = new System.Drawing.Point(709, 415);
            this.insultValueLabel.Name = "insultValueLabel";
            this.insultValueLabel.Size = new System.Drawing.Size(30, 16);
            this.insultValueLabel.TabIndex = 14;
            this.insultValueLabel.Text = "N/A";
            // 
            // profanityValueLabel
            // 
            this.profanityValueLabel.AutoSize = true;
            this.profanityValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profanityValueLabel.Location = new System.Drawing.Point(709, 440);
            this.profanityValueLabel.Name = "profanityValueLabel";
            this.profanityValueLabel.Size = new System.Drawing.Size(30, 16);
            this.profanityValueLabel.TabIndex = 15;
            this.profanityValueLabel.Text = "N/A";
            // 
            // threatValueLabel
            // 
            this.threatValueLabel.AutoSize = true;
            this.threatValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threatValueLabel.Location = new System.Drawing.Point(709, 465);
            this.threatValueLabel.Name = "threatValueLabel";
            this.threatValueLabel.Size = new System.Drawing.Size(30, 16);
            this.threatValueLabel.TabIndex = 16;
            this.threatValueLabel.Text = "N/A";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(206, 289);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 17;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 521);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.threatValueLabel);
            this.Controls.Add(this.profanityValueLabel);
            this.Controls.Add(this.insultValueLabel);
            this.Controls.Add(this.identityAttackValueLabel);
            this.Controls.Add(this.toxicityValueLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.analyzeResultLabel);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label analyzeResultLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label toxicityValueLabel;
        private System.Windows.Forms.Label identityAttackValueLabel;
        private System.Windows.Forms.Label insultValueLabel;
        private System.Windows.Forms.Label profanityValueLabel;
        private System.Windows.Forms.Label threatValueLabel;
        private System.Windows.Forms.Button exportButton;
    }
}

