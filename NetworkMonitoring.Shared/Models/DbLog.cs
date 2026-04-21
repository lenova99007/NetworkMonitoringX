using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkMonitoring.Shared.Models
{
    public class DbLog
    {
        //public int DbLogId { get; set; }
        //public int DeviceId { get; set; }
        //public string DbSizeInfo { get; set; } = string.Empty;
        //public string SessionId { get; set; } = string.Empty;
        //public System.DateTime CreatedAt { get; set; } = DateTime.Now;
        //public bool IsSuspended { get; set; }
        //public int Id { get; set; }
        //public string DatabaseName { get; set; } = string.Empty;
        //public long SizeInMB { get; set; }
        [Key]
        //   [Display(Name = "Ping Log Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DbLogId { get; set; }
        public int DbDeviceId { get; set; } = 1;
        public long DbSessionId { get; set; } = 1;
        [Column(TypeName = "nvarchar(MAX)")]
        public string DbSizeInfo { get; set; } = string.Empty;
        public Boolean DbisIssue { get; set; } = false;
        public DateTime DbDate { get; set; } = DateTime.Now;
        public DateTime DbTime { get; set; } = DateTime.Now;
        public Boolean DbSuspend { get; set; } = false;
    }
}