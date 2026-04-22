using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Data
{
    public class NetworkDbContext : DbContext
    {
        public NetworkDbContext(DbContextOptions<NetworkDbContext> options) : base(options)
        {
        }

        public DbSet<AlertLog> AlertLogs { get; set; }

        // Add other DbSets as needed
        public DbSet<Device> Devices { get; set; }
        public DbSet<EmailGroup> EmailGroups { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<PingLog> PingLogs { get; set; }
        public DbSet<HttpLog> HttpLogs { get; set; }
        public DbSet<HddLog> HddLogs { get; set; }
        public DbSet<ServicesLog> ServicesLogs { get; set; }
        public DbSet<DbLog> DbLogs { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlertLog>().ToTable("T_AlertLogs");
            modelBuilder.Entity<Device>().ToTable("T_Device");
            modelBuilder.Entity<EmailGroup>().ToTable("T_EmailGroups");
            modelBuilder.Entity<Login>().ToTable("T_Login");
            modelBuilder.Entity<PingLog>().ToTable("T_PingLogs");
            modelBuilder.Entity<HttpLog>().ToTable("T_HttpLogs");
            modelBuilder.Entity<HddLog>().ToTable("T_HddLogs");
            modelBuilder.Entity<ServicesLog>().ToTable("T_ServicesLogs");
            modelBuilder.Entity<DbLog>().ToTable("T_DbLogs");
            modelBuilder.Entity<ChatMessage>().ToTable("T_ChatMessages");
        }
    }
}
