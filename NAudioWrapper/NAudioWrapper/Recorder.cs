using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    public class Recorder
    {
        private WaveInEvent waveSource = null;
        private List<byte> buffer = null;
        private int deviceNumber;

        public delegate void RecordingStoppedHandler(object obj, RecordingStoppedEventArgs e);
        public event RecordingStoppedHandler RecordingStoppedEvent;

        public Recorder(int deviceNumber)
        {
            buffer = new List<byte>();
            this.deviceNumber = deviceNumber;
        }
        public void StartRecording()
        {
            try
            {
                if (waveSource == null)
                {
                    waveSource = new WaveInEvent();
                    waveSource.DeviceNumber = deviceNumber;
                    waveSource.RecordingStopped += WaveSource_RecordingStopped;
                    waveSource.DataAvailable += WaveSource_DataAvailable;
                    
                }
                buffer.Clear();
                waveSource.StartRecording();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void WaveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            RecordingStoppedEvent?.BeginInvoke(this, new RecordingStoppedEventArgs(buffer.ToArray()), null, null);
            buffer.Clear();
        }

        public void StopRecording()
        {
            try
            {
                waveSource.StopRecording();
                waveSource.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            buffer.AddRange(e.Buffer);
        }
    }
}
