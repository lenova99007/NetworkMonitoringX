using System;

namespace NetworkMonitoring.Shared.Models
{
    public class HttpLog
    {
        public long HttpLogId { get; set; }
        public int? DeviceId { get; set; }
        public long? SessionId { get; set; }
        public string? ResultMessage { get; set; }
        public bool? IsIssue { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsSuspended { get; set; }
    }
}
