using System;

namespace NetworkMonitoring.Shared.Models
{
    public class HddLog
    {
        public int HddLogId { get; set; }
        public int DeviceId { get; set; }
        public string HDDInfo { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public System.DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsSuspended { get; set; }
        public double UsagePercentage { get; set; }
        public long TotalSpace { get; set; }
        public long FreeSpace { get; set; }
        public int Id { get; set; }
        public string DriveName { get; set; } = string.Empty;
    }
}