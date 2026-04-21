using Microsoft.AspNetCore.SignalR.Client;
using NetworkMonitoring.Shared.Models;

namespace NetworkMonitoring.Maui.Services
{
    public class SignalRService
    {
        private HubConnection _connection;
        public event Action<ChatMessageDto>? OnMessage;
        public event Action<LogAlertDto>? OnLog;

        public SignalRService(string hubUrl = "https://localhost:7001/chathub")
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<ChatMessageDto>("ReceiveMessage", m => OnMessage?.Invoke(m));
            _connection.On<LogAlertDto>("ReceiveLog", l => OnLog?.Invoke(l));
        }

        public async Task StartAsync()
        {
            if (_connection.State == Microsoft.AspNetCore.SignalR.Client.HubConnectionState.Disconnected)
            {
                await _connection.StartAsync();
            }
        }

        public async Task SendMessageAsync(ChatMessageDto msg)
        {
            if (_connection.State == Microsoft.AspNetCore.SignalR.Client.HubConnectionState.Connected)
            {
                await _connection.InvokeAsync("SendMessage", msg);
            }
        }

        public async Task StopAsync()
        {
            await _connection.DisposeAsync();
        }
    }
}