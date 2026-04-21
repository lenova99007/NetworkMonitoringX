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
    }
}