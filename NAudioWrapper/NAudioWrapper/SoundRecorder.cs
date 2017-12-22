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
    public class SoundRecorder
    {
        private WaveInEvent waveSource = null;
        private List<byte> buffer = null;
        private int deviceNumber;

        public delegate void RecordingStoppedHandler(object obj, SoundRecordingStoppedEventArgs e);
        public event RecordingStoppedHandler RecordingStoppedEvent;

        public SoundRecorder(int deviceNumber)
        {
            buffer = new List<byte>();
            this.deviceNumber = deviceNumber;
        }
        public void Start()
        {
            try
            {
                if (waveSource == null)
                {
                    waveSource = new WaveInEvent();
                    waveSource.DeviceNumber = deviceNumber;
                    waveSource.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(waveSource.DeviceNumber).Channels);
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
            var bufArray = buffer.ToArray();
            if (bufArray.Length>0)
            {
                RecordingStoppedEvent?.BeginInvoke(this, new SoundRecordingStoppedEventArgs(bufArray), null, null);
            }
            buffer.Clear();
        }

        public void Stop()
        {
            try
            {
                waveSource.StopRecording();
                waveSource.Dispose();
            }
            catch
            {
            }
        }
        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            buffer.AddRange(e.Buffer);
        }
    }
}
