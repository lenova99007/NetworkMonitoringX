namespace NetworkMonitoring.Shared.Models
{
    public class ServicesLog
    {
        public int ServicesLogId { get; set; }
        public int DeviceId { get; set; }
        public string ResultMessage { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public System.DateTime CreatedAt { get; set; }
        public bool IsSuspended { get; set; }
    }
}