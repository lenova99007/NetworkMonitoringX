using Microsoft.AspNetCore.SignalR;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System;
using System.Threading.Tasks;

namespace NetworkMonitoring.Web.Hubs
{
    public class AlertHub : Hub
    {
        private readonly AppDbContext _db;

        public AlertHub(AppDbContext db)
        {
            _db = db;
        }

        public async Task SendAlert(string device, string message, string severity)
        {
            var log = new AlertLog
            {
                Device = device,
                Message = message,
                Severity = severity,
                CreatedAt = DateTime.Now
            };

            _db.AlertLogs.Add(log);
            await _db.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveAlert", new
            {
                Id = log.Id,
                Device = device,
                Message = message,
                Severity = severity,
                CreatedAt = log.CreatedAt
            });
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Connected", $"Connected to AlertHub at {DateTime.Now}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}