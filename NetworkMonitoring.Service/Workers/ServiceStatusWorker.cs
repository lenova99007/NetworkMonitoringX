using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Service.Workers
{
    public class ServiceStatusWorker : BackgroundService
    {
        private readonly ILogger<ServiceStatusWorker> _logger;
        private readonly IServiceProvider _sp;
        public ServiceStatusWorker(ILogger<ServiceStatusWorker> logger, IServiceProvider sp) { _logger = logger; _sp = sp; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ServiceStatusWorker starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    // TODO: enumerate services to check - placeholder example
                    db.ServicesLogs.Add(new ServicesLog { DeviceId = 1, ResultMessage = "SampleService - Running", SessionId = Guid.NewGuid().ToString(), CreatedAt = DateTime.UtcNow });
                    await db.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "ServiceStatusWorker error");
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
