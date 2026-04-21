
using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:5001/alertHub")
    .WithAutomaticReconnect()
    .Build();

await connection.StartAsync();

while (true)
{
    var msg = Console.ReadLine();
    await connection.InvokeAsync("SendAlert", "Device01", msg, "Info");
}
