namespace NetworkMonitoring.Shared.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public int CountryId { get; set; }
        public string LocationName_En { get; set; } = string.Empty;
        public string LocationName_Ar { get; set; } = string.Empty;
        public bool Suspend { get; set; }

        // Navigation property
        public Country? Country { get; set; }
    }
}