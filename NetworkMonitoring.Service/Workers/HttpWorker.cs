using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Service.Workers
{
    public class HttpWorker : BackgroundService
    {
        private readonly ILogger<HttpWorker> _logger;
        private readonly IServiceProvider _sp;
        private readonly HttpClient _http = new HttpClient();
        public HttpWorker(ILogger<HttpWorker> logger, IServiceProvider sp) { _logger = logger; _sp = sp; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HttpWorker starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    // TODO: replace with configured endpoints
                    var res = await _http.GetAsync("https://example.com", stoppingToken);
                    db.HttpLogs.Add(new HttpLog { DeviceId = 1, ResultMessage = res.IsSuccessStatusCode ? "200 OK" : "Error", IsIssue = !res.IsSuccessStatusCode, SessionId = Guid.NewGuid().ToString(), CreatedAt = DateTime.UtcNow });
                    await db.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "HttpWorker error");
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
