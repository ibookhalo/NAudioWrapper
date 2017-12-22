using System;

namespace NAudioWrapper
{
    [Serializable]
    public class DeviceInfo
    {
        private const string NO_DEVICE = "Kein Gerät";
        public DeviceInfo(string productName,string productGuid)
        {
            this.Productname = productName;
            this.ProductGuid = productGuid;
        }
        public DeviceInfo()
        {
            Productname = NO_DEVICE;
            ProductGuid = string.Empty;
        }
        public string Productname { get; set; }
        public string ProductGuid { get; set; }

        public override string ToString()
        {
            return Productname != null ? Productname : NO_DEVICE;
        }
    }
}
