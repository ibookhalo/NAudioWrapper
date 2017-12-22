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
                var device = WaveIn.GetCapabilities(index);
                if (device.ProductGuid!=null && device.ProductGuid.ToString().Length>0)
                {
                    devices.Add(new DeviceInfo(device.ProductName, device.ProductGuid.ToString()));
                }
            }
            return devices;
        }
        public int GetCaptureDeviceIdByProductGUID(string guid)
        {
            for (int index = 0; index < WaveIn.DeviceCount; index++)
            {
                var device = WaveIn.GetCapabilities(index);
                if (device.ProductGuid != null && device.ProductGuid.ToString().Length > 0)
                {
                    return index;
                }
            }
            return -1;
        }

        public int GetRenderDeviceIdByProductGUID(string guid)
        {
            for (int index = 0; index < WaveOut.DeviceCount; index++)
            {
                var device = WaveOut.GetCapabilities(index);
                if (device.ProductGuid != null && device.ProductGuid.ToString().Equals(guid))
                {
                    return index;
                }
            }
            return -1;
        }
        public List<DeviceInfo> GetRenderDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            for (int index = 0; index < WaveOut.DeviceCount; index++)
            {
                var device = WaveOut.GetCapabilities(index);
                if (device.ProductGuid != null && device.ProductGuid.ToString().Length > 0)
                {
                    devices.Add(new DeviceInfo(device.ProductName, device.ProductGuid.ToString()));
                }
            }

            return devices;
        }
    }
}
