using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkMonitoring.Shared.Models
{
    public class DbLog
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DbLogId { get; set; }
        public int? DbDeviceId { get; set; }
        public long? DbSessionId { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string DbSizeInfo { get; set; } = string.Empty;
        public bool? DbisIssue { get; set; }
        public DateTime? DbDate { get; set; }
        public TimeSpan? DbTime { get; set; }
        public bool? DbSuspend { get; set; }

        [NotMapped]
        public DateTime CreatedAt
        {
            get => (DbDate ?? DateTime.UtcNow.Date) + (DbTime ?? TimeSpan.Zero);
            set
            {
                DbDate = value.Date;
                DbTime = value.TimeOfDay;
            }
        }
    }
}
}