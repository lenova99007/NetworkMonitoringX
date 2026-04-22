using System;

namespace NetworkMonitoring.Shared.Models
{
    public class HddLog
    {
        public long HddLogId { get; set; }
        public int? DeviceId { get; set; }
        public long? SessionId { get; set; }
        public string? HDDInfo { get; set; }
        public bool? IsIssue { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsSuspended { get; set; }
    }
}
}