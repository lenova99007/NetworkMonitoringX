using System;

namespace NetworkMonitoring.Shared.Models
{
    public class PingLog
    {
        public int PingLogId { get; set; }  // Changed from Id
        public int? DeviceId { get; set; }  // Changed from IpAddress
        public string? ResultMessage { get; set; }  // Changed from RoundtripTimeMs
        public bool? IsIssue { get; set; }  // Changed from IsSuccess
        public string? SessionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsSuspended { get; set; }
    }
}