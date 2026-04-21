namespace NetworkMonitoring.Shared.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public bool Suspend { get; set; }
    }
}