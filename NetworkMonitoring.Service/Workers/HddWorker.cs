using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Service.Workers
{
    public class HddWorker : BackgroundService
    {
        private readonly ILogger<HddWorker> _logger;
        private readonly IServiceProvider _sp;
        public HddWorker(ILogger<HddWorker> logger, IServiceProvider sp) { _logger = logger; _sp = sp; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HddWorker starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    // TODO: insert real HDD monitoring logic here
                    db.HddLogs.Add(new HddLog { DeviceId = 1, HDDInfo = "C: 120GB free", SessionId = Guid.NewGuid().ToString(), CreatedAt = DateTime.UtcNow });
                    await db.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "HddWorker error");
                }
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
