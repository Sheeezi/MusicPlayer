using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace MusicPlayerLib
{
    public class MusicPlayerLibrary
    {
        private WaveOutEvent? outputDevice;
        private AudioFileReader? audioFile;
        private bool musicPlaying;
        private List<string>? musicPlayList;

        private int songIndex = 0;
        private readonly string exePath;

        private System.Windows.Forms.Timer? updateTimer;

        public event EventHandler<TimeSpan>? OnPlayTime;

        public event EventHandler<string> OnPlaySongName;

        public event EventHandler<(bool previousSongState, bool nextSongState)>? OnButtonState;

        public int SongIndex { get => songIndex; }
        public bool SongsExistState { get => musicPlayList!.Count == 0; }
        public int SongCount { get => musicPlayList!.Count; }

        public MusicPlayerLibrary(string exePath)
        {
            this.exePath = exePath;

            InitPlayList();

            InitUpdateTimer();
        }

        private void InitUpdateTimer()
        {
            if (updateTimer != null)
                return;

            updateTimer = new System.Windows.Forms.Timer
            {
                Interval = 100
            };
            updateTimer.Tick += UpdateTimer_Tick;

            updateTimer.Enabled = true;
        }

        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            var playTime = GetPlayTime();
            var currentFileName = GetCurrentPlayFileName();

            SetPlayTime(playTime);
            SetSongName(currentFileName);

            var (previousSongState, nextSongState) = GetButtonsState();

            SetButtonState(previousSongState, nextSongState);
        }

        public void PlayMusic(int songIndex)
        {
            if (outputDevice == null)
                outputDevice = new WaveOutEvent();

            if (audioFile == null)
            {
                audioFile = new AudioFileReader(musicPlayList![songIndex]);
                outputDevice.Init(audioFile);
            }

            outputDevice.Play();
        }

        public void PauseMusic()
        {
            outputDevice?.Stop();
        }

        public void StopMusic()
        {
            outputDevice?.Stop();

            outputDevice?.Dispose();
            outputDevice = null;
            audioFile?.Dispose();
            audioFile = null;

            musicPlaying = false;
        }

        private void InitPlayList()
        {
            var mp3Path = Path.Combine(exePath!, "Songs");

            if (!Path.Exists(mp3Path))
                Directory.CreateDirectory(mp3Path);

            musicPlayList = Directory
                .GetFiles(mp3Path!)
                .ToList()
                ;
        }

        public void PreviousSong()
        {
            //if (musicPlaying)
                StopMusic();

            PlayMusic(--songIndex);

            musicPlaying = true;
        }

        public void NextSong()
        {
            //if (musicPlaying)
                StopMusic();

            PlayMusic(++songIndex);

            musicPlaying = true;
        }

        public void StartStopSong()
        {
            if (!musicPlaying)
                PlayMusic(songIndex);
            else
                PauseMusic();

            musicPlaying = !musicPlaying;
        }

        public void SetVolume(int volume)
        {
            outputDevice!.Volume = (volume * 2) / 100f;
        }

        public void LoadMusicPlayer()
        {
            if (outputDevice == null)
                outputDevice = new WaveOutEvent();

            if (!musicPlayList!.Any())
            {
                MessageBox.Show("Nie znaleziono plikowe z muzyka");
                return;
            }

            if (audioFile == null)
            {
                audioFile = new AudioFileReader(musicPlayList![songIndex]);
                outputDevice.Init(audioFile);
            }
        }

        public string GetCurrentPlayFileName()
        {
            var result = string.Empty;

            result = Path.GetFileName(musicPlayList![songIndex]);

            return result;
        }

        private void SetPlayTime(TimeSpan timeSpan)
        {
            OnPlayTime?.Invoke(this, timeSpan);
        }

        private void SetSongName(string songName)
        {
            OnPlaySongName?.Invoke(this, songName);
        }

        private void SetButtonState(bool previousSongState, bool nextSongState)
        {
            OnButtonState?.Invoke(this, (previousSongState, nextSongState));
        }

        public TimeSpan GetPlayTime()
        {
            var result = default(TimeSpan);

            if (audioFile != null)
                result = audioFile!.CurrentTime;
            else
                result = TimeSpan.Zero;

            return result;
        }

        private (bool previousSongState, bool nextSongState) GetButtonsState()
        {
            var result = default((bool previousSongState, bool nextSongState));

            if (SongIndex == 0)
                result.previousSongState = false;
            else
                result.previousSongState = true;

            if (SongIndex == (SongCount - 1))
                result.nextSongState = false;
            else
                result.nextSongState = true;

            return result;
        }

    }
}
