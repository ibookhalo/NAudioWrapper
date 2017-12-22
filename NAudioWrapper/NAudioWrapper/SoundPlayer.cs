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
        private WaveOutEvent waveOutEvent;

        public delegate void PlayingStoppedHandler(object obj, EventArgs e);
        public event PlayingStoppedHandler PlaybackStoppedEvent;

        private int deviceNumber;
        public SoundPlayer(int deviceNumber)
        {
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
            waveOutEvent.Init(new RawSourceWaveStream(new MemoryStream(buffer), new WaveFormat(44100, WaveOut.GetCapabilities(waveOutEvent.DeviceNumber).Channels)));
            waveOutEvent.Volume = 1;
            waveOutEvent.Play();
        }

        private void playbackStopped(object sender, StoppedEventArgs e)
        {
            PlaybackStoppedEvent?.BeginInvoke(this, new EventArgs(), null, null);
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
