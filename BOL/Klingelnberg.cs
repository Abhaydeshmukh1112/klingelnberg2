using Microsoft.VisualBasic;

namespace BOL
{
    
    public class KlingelnBerg
    {
        public int? seriesNumber { get; set; }
        public string? machineType { get; set; }
        public string? assetName { get; set; }


        public KlingelnBerg()
        {

        }
        public KlingelnBerg(string? assetName, string? machineType, int? seriesNumber)
        {
            this.seriesNumber = seriesNumber;
            this.machineType = machineType;
            this.assetName = assetName;
        }
    }
}