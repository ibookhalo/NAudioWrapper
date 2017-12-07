using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    public class SoundRecordingStoppedEventArgs:EventArgs
    {
        public byte[] SoundeData { get; private set; }

        public SoundRecordingStoppedEventArgs(byte[] soundeData)
        {
            SoundeData = soundeData;
        }
    }
}
