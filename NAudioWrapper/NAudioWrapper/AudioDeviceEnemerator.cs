using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioWrapper
{
    public class AudioDeviceEnemerator
    {
        public List<DeviceInfo> GetCaptureDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            for (int index = 0; index < WaveIn.DeviceCount; index++)
            {
                devices.Add(new DeviceInfo(WaveIn.GetCapabilities(index).ProductName, index));
            }
            return devices;
        }

        public List<DeviceInfo> GetRenderDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            for (int index = 0; index < WaveOut.DeviceCount; index++)
            {
                devices.Add(new DeviceInfo(WaveOut.GetCapabilities(index).ProductName, index));
            }

            return devices;
        }
    }
}
