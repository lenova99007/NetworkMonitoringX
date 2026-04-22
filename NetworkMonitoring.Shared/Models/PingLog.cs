using System;

namespace NetworkMonitoring.Shared.Models
{
    public class PingLog
    {
        public long PingLogId { get; set; }
        public int? DeviceId { get; set; }
        public string? ResultMessage { get; set; }
        public bool? IsIssue { get; set; }
        public long? SessionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsSuspended { get; set; }
    }
}
