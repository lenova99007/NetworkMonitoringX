using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Service.Workers
{
    public class PingWorker : BackgroundService
    {
        private readonly ILogger<PingWorker> _logger;
        private readonly IServiceProvider _sp;
        public PingWorker(ILogger<PingWorker> logger, IServiceProvider sp) { _logger = logger; _sp = sp; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("PingWorker starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    // TODO: replace with real ping logic
                    db.PingLogs.Add(new PingLog { DeviceId = 1, ResultMessage = "Ping OK (sample)", IsIssue = false, SessionId = Guid.NewGuid().ToString(), CreatedAt = DateTime.UtcNow });
                    await db.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "PingWorker error");
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
