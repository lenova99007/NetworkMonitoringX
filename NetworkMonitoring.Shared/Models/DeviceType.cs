namespace NetworkMonitoring.Shared.Models
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public bool Suspend { get; set; }
    }
}