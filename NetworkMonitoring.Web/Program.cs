using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Web.Hubs;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = "Server=.\\MSSQL2019;Database=NetworkMonitoring;User id=sa;Password=Password1234;TrustServerCertificate=True;MultipleActiveResultSets=True;Encrypt=False;";
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseCors("AllowAll");
app.UseStaticFiles();  // Add this line to serve static files
app.MapHub<AlertHub>("/alertHub");

app.MapGet("/pinglogs", async (AppDbContext db) =>
    await db.PingLogs.OrderByDescending(x => x.CreatedAt).Take(50).ToListAsync());

app.MapGet("/chatmessages", async (AppDbContext db) =>
    await db.ChatMessages.OrderByDescending(x => x.CreatedAt).Take(50).ToListAsync());

app.Run();