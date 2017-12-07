using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    public class SoundPlayer
    {
        private WaveFormat waveFormat;
        private WaveOutEvent waveOutEvent;

        public delegate void PlayingStoppedHandler(object obj, EventArgs e);
        public PlayingStoppedHandler PlaybackStopped;

        private int deviceNumber;
        public SoundPlayer(int deviceNumber)
        {
            this.waveFormat = new WaveFormat(8000, 1);
            this.deviceNumber = deviceNumber;
        }
        public void Play(byte[] buffer)
        {
            if (waveOutEvent == null)
            {
                waveOutEvent = new WaveOutEvent();
                waveOutEvent.DeviceNumber = deviceNumber;
                waveOutEvent.PlaybackStopped += playbackStopped;
            }
            else
            {
                waveOutEvent.Stop();
            }
            waveOutEvent.Init(new RawSourceWaveStream(new MemoryStream(buffer), waveFormat));
            waveOutEvent.Volume = 1;
            waveOutEvent.Play();
        }

        private void playbackStopped(object sender, StoppedEventArgs e)
        {
            PlaybackStopped?.BeginInvoke(this, new EventArgs(), null, null);
        }

        public void Stop()
        {
            try
            {
                waveOutEvent.Stop();
                waveOutEvent.Dispose();
            }
            catch
            {
            }
        }
    }
}
