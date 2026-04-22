using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Shared.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // All DbSets matching database tables
        public DbSet<AlertLog> AlertLogs { get; set; }
        public DbSet<PingLog> PingLogs { get; set; }
        public DbSet<HttpLog> HttpLogs { get; set; }
        public DbSet<HddLog> HddLogs { get; set; }
        public DbSet<DbLog> DbLogs { get; set; }
        public DbSet<ServicesLog> ServicesLogs { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<EmailGroup> EmailGroups { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map to actual database table names (with T_ prefix)

            modelBuilder.Entity<AlertLog>().ToTable("T_AlertLogs");

            modelBuilder.Entity<PingLog>(entity =>
            {
                entity.ToTable("T_PingLogs");
                entity.HasKey(e => e.PingLogId);
                entity.Property(e => e.DeviceId).HasColumnName("PLDeviceId");
                entity.Property(e => e.SessionId).HasColumnName("PLSessionId");
                entity.Property(e => e.ResultMessage).HasColumnName("PingReply");
                entity.Property(e => e.IsIssue).HasColumnName("PLisIssue");
                entity.Property(e => e.CreatedAt).HasColumnName("PingDate");
                entity.Property(e => e.IsSuspended).HasColumnName("PLSuspend");
            });

            modelBuilder.Entity<HttpLog>(entity =>
            {
                entity.ToTable("T_HttpLogs");
                entity.HasKey(e => e.HttpLogId);
                entity.Property(e => e.DeviceId).HasColumnName("HDeviceId");
                entity.Property(e => e.SessionId).HasColumnName("HSessionId");
                entity.Property(e => e.ResultMessage).HasColumnName("HttpReMessage");
                entity.Property(e => e.IsIssue).HasColumnName("HisIssue");
                entity.Property(e => e.CreatedAt).HasColumnName("HttpDate");
                entity.Property(e => e.IsSuspended).HasColumnName("HSuspend");
            });

            modelBuilder.Entity<HddLog>(entity =>
            {
                entity.ToTable("T_HddLogs");
                entity.HasKey(e => e.HddLogId);
                entity.Property(e => e.DeviceId).HasColumnName("HdDeviceId");
                entity.Property(e => e.SessionId).HasColumnName("HdSessionId");
                entity.Property(e => e.HDDInfo).HasColumnName("HddInfo");
                entity.Property(e => e.IsIssue).HasColumnName("HdisIssue");
                entity.Property(e => e.CreatedAt).HasColumnName("HddDate");
                entity.Property(e => e.IsSuspended).HasColumnName("HdSuspend");
            });

            modelBuilder.Entity<DbLog>(entity =>
            {
                entity.ToTable("T_DbLogs");
                entity.HasKey(e => e.DbLogId);
                entity.Property(e => e.DbDate).HasColumnType("date");
                entity.Property(e => e.DbTime).HasColumnType("time");
            });

            modelBuilder.Entity<ServicesLog>(entity =>
            {
                entity.ToTable("T_ServicesLogs");
                entity.HasKey(e => e.ServicesLogId);
                entity.Property(e => e.ServicesLogId).HasColumnName("ServiceLogId");
                entity.Property(e => e.DeviceId).HasColumnName("SDeviceId");
                entity.Property(e => e.SessionId).HasColumnName("SSessionId");
                entity.Property(e => e.ResultMessage).HasColumnName("ServiceInfo");
                entity.Property(e => e.IsIssue).HasColumnName("SisIssue");
                entity.Property(e => e.CreatedAt).HasColumnName("ServiceDate");
                entity.Property(e => e.IsSuspended).HasColumnName("SSuspend");
            });


            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("T_Device");
                entity.Property(e => e.LocationId).HasColumnName("DLocationId");
                entity.Property(e => e.DeviceTypeId).HasColumnName("DDeviceTypeId");
                entity.Property(e => e.DeviceName).HasColumnName("DName");
                entity.Property(e => e.Description).HasColumnName("DDescription");
                entity.Property(e => e.Suspend).HasColumnName("DSuspend");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("T_DeviceTypes");
                entity.Property(e => e.TypeName).HasColumnName("DTName");
                entity.Property(e => e.Suspend).HasColumnName("DTSuspend");
            });

            modelBuilder.Entity<EmailGroup>(entity =>
            {
                entity.ToTable("T_EmailGroups");
                entity.Property(e => e.EmailGroupsName).HasColumnName("EGName");
                entity.Property(e => e.EmailFrom).HasColumnName("EGFrom");
                entity.Property(e => e.EmailTO).HasColumnName("EGTo");
                entity.Property(e => e.EmailCC).HasColumnName("EGCC");
                entity.Property(e => e.EmailBCC).HasColumnName("EGBCC");
                entity.Property(e => e.EmailSubject).HasColumnName("EGSubject");
                entity.Property(e => e.Suspend).HasColumnName("EGSuspend");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("T_ActivityTypes");
                entity.Property(e => e.Name).HasColumnName("AcName");
                entity.Property(e => e.StartTime).HasColumnName("AcStartTime");
                entity.Property(e => e.EndTime).HasColumnName("AcEndTime");
                entity.Property(e => e.Timer).HasColumnName("AcTimer");
                entity.Property(e => e.Suspend).HasColumnName("AcSuspend");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("T_Country");
                entity.Property(e => e.CountryName).HasColumnName("CouName_EN");
                entity.Property(e => e.Suspend).HasColumnName("CouSuspend");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("T_Location");
                entity.Property(e => e.CountryId).HasColumnName("LoCountryId");
                entity.Property(e => e.LocationName_En).HasColumnName("LoName_En");
                entity.Property(e => e.LocationName_Ar).HasColumnName("LoLocationName_Ar");
                entity.Property(e => e.Suspend).HasColumnName("LoSuspend");
            });
        }
    }
}
}