using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Service.Workers
{
    public class DbSizeWorker : BackgroundService
    {
        private readonly ILogger<DbSizeWorker> _logger;
        private readonly IServiceProvider _sp;
        public DbSizeWorker(ILogger<DbSizeWorker> logger, IServiceProvider sp) { _logger = logger; _sp = sp; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("DbSizeWorker starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    // Example: query for DB size (placeholder)
                    db.DbLogs.Add(new DbLog { DbDeviceId = 1, DbSizeInfo = "DB size: 100MB", DbSessionId = DateTime.UtcNow.Ticks, DbDate = DateTime.UtcNow.Date, DbTime = DateTime.UtcNow });
                    await db.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "DbSizeWorker error");
                }
                await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }
    }
}