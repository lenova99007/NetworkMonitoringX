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
            modelBuilder.Entity<PingLog>().ToTable("T_PingLogs");
            modelBuilder.Entity<HttpLog>().ToTable("T_HttpLogs");
            modelBuilder.Entity<HddLog>().ToTable("T_HddLogs");
            modelBuilder.Entity<DbLog>().ToTable("T_DbLogs");
            modelBuilder.Entity<ServicesLog>().ToTable("T_ServicesLogs");
            modelBuilder.Entity<ChatMessage>().ToTable("T_ChatMessages");
            modelBuilder.Entity<Device>().ToTable("T_Device");
            modelBuilder.Entity<DeviceType>().ToTable("T_DeviceTypes");
            modelBuilder.Entity<Login>().ToTable("T_Login");
            modelBuilder.Entity<EmailGroup>().ToTable("T_EmailGroups");
            modelBuilder.Entity<ActivityType>().ToTable("T_ActivityTypes");
            modelBuilder.Entity<Country>().ToTable("T_Country");
            modelBuilder.Entity<Location>().ToTable("T_Location");
        }
    }
}