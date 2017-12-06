using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    public class RecordingStoppedEventArgs:EventArgs
    {
        public byte[] SoundeData { get; private set; }

        public RecordingStoppedEventArgs(byte[] soundeData)
        {
            SoundeData = soundeData;
        }
    }
}
