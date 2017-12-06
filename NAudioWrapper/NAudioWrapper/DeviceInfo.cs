using System;

namespace NAudioWrapper
{
    [Serializable]
    public class DeviceInfo
    {
        public DeviceInfo(string productName,int id)
        {
            this.Productname = productName;
            this.Id = id;
        }
        public DeviceInfo()
        {
            Productname = "Kein";
            Id = -1;
        }
        public string Productname { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Productname != null ? Productname : "Kein";
        }
    }
}
