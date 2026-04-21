using System;

namespace NetworkMonitoring.Shared.Models
{
    public class HttpLog
    {
        public int HttpLogId { get; set; }
        public int DeviceId { get; set; }
        public string ResultMessage { get; set; } = string.Empty;
        public bool IsIssue { get; set; }
        public string SessionId { get; set; } = string.Empty;
        public System.DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsSuspended { get; set; }
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public long ResponseTimeMs { get; set; }
        public bool IsSuccess { get; set; }

    }
}