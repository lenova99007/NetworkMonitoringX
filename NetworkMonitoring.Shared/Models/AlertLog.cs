using System;

namespace NetworkMonitoring.Shared.Models  // Change to Models namespace
{
    public class AlertLog
    {
        public int Id { get; set; }
        public string Device { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}