using Microsoft.AspNetCore.SignalR.Client;
using NetworkMonitoring.Service.Workers;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;

private readonly ILogger<PingWorkerSignalR> _logger;
private readonly IServiceProvider _sp;
private HubConnection? _conn;

public PingWorkerSignalR(ILogger<PingWorkerSignalR> logger, IServiceProvider sp)
{
    _logger = logger; _sp = sp;
    // hub URL should be configurable; default to localhost:5000
    _conn = new HubConnectionBuilder().WithUrl("http://localhost:5000/chathub").WithAutomaticReconnect().Build();
}

public override async Task StartAsync(CancellationToken cancellationToken)
{
    await _conn.StartAsync(cancellationToken);
    await base.StartAsync(cancellationToken);
}

protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        try
        {
            using var scope = _sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var pl = new NetworkMonitoring.Shared.Models.PingLog { DeviceId = 1, ResultMessage = "Ping OK (from SignalR worker)", IsIssue = false, SessionId = DateTime.UtcNow.Ticks, CreatedAt = DateTime.UtcNow };
            db.PingLogs.Add(pl);
            await db.SaveChangesAsync(stoppingToken);

            // broadcast via SignalR client to hub
            var alert = new LogAlertDto { DeviceName = "Main Server", LogType = "Ping", Message = pl.ResultMessage, Timestamp = pl.CreatedAt };
            if (_conn.State == HubConnectionState.Connected)
            {
                await _conn.InvokeAsync("BroadcastLog", alert, cancellationToken: stoppingToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SignalR ping worker error");
        }
        await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
    }
}
