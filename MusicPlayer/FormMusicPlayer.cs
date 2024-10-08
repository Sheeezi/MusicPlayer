using MusicPlayerLib;
using NAudio.Wave;
using System;
using System.IO;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MusicPlayer
{
    public partial class FormMusicPlayer : Form
    {
        private MusicPlayerLibrary? musicPlayerLibrary;

        public FormMusicPlayer()
        {
            InitializeComponent();

            var mp3Path = Path.GetDirectoryName(Application.ExecutablePath);

            InitPlayer(mp3Path);
        }

        private void InitPlayer(string? mp3Path)
        {
            musicPlayerLibrary = new MusicPlayerLibrary(mp3Path!);

            musicPlayerLibrary.OnPlayTime += MusicPlayerLibrary_OnPlayTime;
            musicPlayerLibrary.OnButtonState += MusicPlayerLibrary_OnButtonState;
        }

        private void MusicPlayerLibrary_OnButtonState(object? sender, (bool previousSongState, bool nextSongState) e)
        {
            SetButtonsFromEvent(e.previousSongState, e.nextSongState);
        }

        private void MusicPlayerLibrary_OnPlayTime(object? sender, (TimeSpan timeSpan, string songName) e)
        {
            SetLabelsFromEvent(e.timeSpan, e.songName);
        }

        private void ButtonStartStopSong_Click(object sender, EventArgs e)
        {
            musicPlayerLibrary!.StartStopSong();
        }

        private void ButtonPreviousSong_Click(object sender, EventArgs e)
        {
            musicPlayerLibrary!.PreviousSong();
        }

        private void ButtonNextSong_Click(object sender, EventArgs e)
        {
            musicPlayerLibrary!.NextSong();
        }

        private void TrackBarVolume_Scroll(object sender, EventArgs e)
        {
            musicPlayerLibrary!.SetVolume(trackBarVolume.Value);
        }

        private void ButtonStopSong_Click(object sender, EventArgs e)
        {
            musicPlayerLibrary!.StopMusic();
        }

        private void FormMusicPlayer_Load(object sender, EventArgs e)
        {
            musicPlayerLibrary!.LoadMusicPlayer();
        }

        private void SetLabelsFromEvent(TimeSpan timeSpan, string songName)
        {
            if (musicPlayerLibrary!.SongsExistState)
                return;

            labelDisplaySongName.Text = songName;

            var playTime = timeSpan.ToString();

            labelDisplayTime.Text = playTime.Substring(3, 5);
        }

        private void SetButtonsFromEvent(bool previousSongState, bool nextSongState)
        {
            buttonPreviousSong.Enabled = previousSongState;
            buttonNextSong.Enabled = nextSongState;
        }

    }
}
