using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    class Recorder
    {
        private WaveInEvent waveSource = null;
        public List<byte> Buffer = null;

        public event EventHandler<StoppedEventArgs> RecordingStopped;
        public Recorder()
        {
            Buffer = new List<byte>();
        }
        public void StartRecording()
        {
            try
            {
                if (waveSource == null)
                {
                    waveSource = new WaveInEvent();
                    waveSource.DataAvailable += WaveSource_DataAvailable;
                    if (RecordingStopped != null)
                    {
                        waveSource.RecordingStopped += RecordingStopped;
                    }
                }
                Buffer.Clear();
                waveSource.StartRecording();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void StopRecording()
        {
            try
            {
                waveSource.StopRecording();
                Buffer.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            Buffer.AddRange(e.Buffer);
        }
    }
}
