using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    class Player
    {
        private WaveFormat waveFormat;
        private WaveOutEvent waveOutEvent;
        public EventHandler<StoppedEventArgs> PlaybackStopped;
        public Player(WaveFormat waveFormat)
        {
            this.waveFormat = waveFormat;
        }
        public void Play(byte[] buffer)
        {
            try
            {
                if (waveOutEvent == null)
                {
                    waveOutEvent = new WaveOutEvent();
                    if (PlaybackStopped != null)
                    {
                        waveOutEvent.PlaybackStopped += PlaybackStopped;
                    }
                }
                else
                {
                    waveOutEvent.Stop();
                }
                waveOutEvent.Init(new RawSourceWaveStream(new MemoryStream(buffer), waveFormat));
                waveOutEvent.Volume = 1;
                waveOutEvent.Play();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Stop()
        {
            waveOutEvent.Stop();
        }
    }
}
