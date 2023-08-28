namespace BuisnessObjectLayer
{
    public class Klingelnberg
    {
        public int? seriesNumber { get; set; }
        public string? machineType { get; set; }
        public string? assetName { get; set; }


        public Klingelnberg()
        {

        }
        public Klingelnberg(string? assetName, string? machineType, int? seriesNumber)
        {
            this.seriesNumber = seriesNumber;
            this.machineType = machineType;
            this.assetName = assetName;
        }
    }
}