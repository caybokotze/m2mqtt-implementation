namespace IOTCore
{
    public class BeaconData
    {
        public string Timestamp { get; set; }
        public string Type { get; set; }
        public string Mac { get; set; }
        public string BleName { get; set; }
        public string IBeaconUuid { get; set; }
        public string IBeaconMajor { get; set; }
        public string IBeaconMinor { get; set; }
        public string Rssi { get; set; }
        public string IbeaconTxPower { get; set; }
        public string Battery { get; set; }
    }
}