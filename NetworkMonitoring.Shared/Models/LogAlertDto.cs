using System;

namespace NetworkMonitoring.Shared.Models
{
    public class LogAlertDto
    {
        public string DeviceName { get; set; } = string.Empty;
        public string LogType { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
