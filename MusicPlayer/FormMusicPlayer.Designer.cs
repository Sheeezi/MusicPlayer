using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MusicPlayer
{
    partial class FormMusicPlayer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStartResumeSong = new Button();
            buttonPreviousSong = new Button();
            buttonNextSong = new Button();
            labelDisplaySongName = new System.Windows.Forms.Label();
            buttonStopSong = new Button();
            labelDisplayTime = new System.Windows.Forms.Label();
            trackBarVolume = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            SuspendLayout();
            // 
            // buttonStartResumeSong
            // 
            buttonStartResumeSong.Location = new Point(324, 227);
            buttonStartResumeSong.Name = "buttonStartResumeSong";
            buttonStartResumeSong.Size = new Size(75, 23);
            buttonStartResumeSong.TabIndex = 0;
            buttonStartResumeSong.Text = "▶/❚❚";
            buttonStartResumeSong.UseVisualStyleBackColor = true;
            buttonStartResumeSong.Click += ButtonStartStopSong_Click;
            // 
            // buttonPreviousSong
            // 
            buttonPreviousSong.Location = new Point(245, 227);
            buttonPreviousSong.Name = "buttonPreviousSong";
            buttonPreviousSong.Size = new Size(75, 23);
            buttonPreviousSong.TabIndex = 1;
            buttonPreviousSong.Text = "🢀";
            buttonPreviousSong.UseVisualStyleBackColor = true;
            buttonPreviousSong.Click += ButtonPreviousSong_Click;
            // 
            // buttonNextSong
            // 
            buttonNextSong.Location = new Point(482, 227);
            buttonNextSong.Name = "buttonNextSong";
            buttonNextSong.Size = new Size(75, 23);
            buttonNextSong.TabIndex = 2;
            buttonNextSong.Text = "🢂";
            buttonNextSong.UseVisualStyleBackColor = true;
            buttonNextSong.Click += ButtonNextSong_Click;
            // 
            // labelDisplaySongName
            // 
            labelDisplaySongName.AutoSize = true;
            labelDisplaySongName.Location = new Point(245, 209);
            labelDisplaySongName.Name = "labelDisplaySongName";
            labelDisplaySongName.Size = new Size(41, 15);
            labelDisplaySongName.TabIndex = 3;
            labelDisplaySongName.Text = "Lorem";
            labelDisplaySongName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonStopSong
            // 
            buttonStopSong.Location = new Point(403, 227);
            buttonStopSong.Name = "buttonStopSong";
            buttonStopSong.Size = new Size(75, 23);
            buttonStopSong.TabIndex = 4;
            buttonStopSong.Text = "◼";
            buttonStopSong.UseVisualStyleBackColor = true;
            buttonStopSong.Click += ButtonStopSong_Click;
            // 
            // labelDisplayTime
            // 
            labelDisplayTime.AutoSize = true;
            labelDisplayTime.Location = new Point(516, 209);
            labelDisplayTime.Name = "labelDisplayTime";
            labelDisplayTime.Size = new Size(34, 15);
            labelDisplayTime.TabIndex = 5;
            labelDisplayTime.Text = "00:00";
            labelDisplayTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(245, 256);
            trackBarVolume.Maximum = 50;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(312, 45);
            trackBarVolume.TabIndex = 6;
            trackBarVolume.Value = 50;
            trackBarVolume.Scroll += TrackBarVolume_Scroll;
            // 
            // FormMusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBarVolume);
            Controls.Add(labelDisplayTime);
            Controls.Add(buttonStopSong);
            Controls.Add(labelDisplaySongName);
            Controls.Add(buttonNextSong);
            Controls.Add(buttonPreviousSong);
            Controls.Add(buttonStartResumeSong);
            Name = "FormMusicPlayer";
            Text = "Music Player";
            Load += FormMusicPlayer_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStartResumeSong;
        private Button buttonPreviousSong;
        private Button buttonNextSong;
        private System.Windows.Forms.Label labelDisplaySongName;
        private Button buttonStopSong;
        private System.Windows.Forms.Label labelDisplayTime;
        private TrackBar trackBarVolume;
    }
}
