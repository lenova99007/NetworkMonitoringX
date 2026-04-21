using System;

namespace NetworkMonitoring.Shared.Models
{
    public class ActivityType
    {
        public int ActivityTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Timer { get; set; }
        public bool Suspend { get; set; }
    }
}