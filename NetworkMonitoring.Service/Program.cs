using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Service.Workers;
using NetworkMonitoring.Shared.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // allows running as a Windows Service when installed
    .ConfigureServices((context, services) =>
    {
        // register DbContext for workers - adjust connection string via appsettings or environment
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
        services.AddHostedService<PingWorker>();
        services.AddHostedService<HttpWorker>();
        services.AddHostedService<HddWorker>();
        services.AddHostedService<DbSizeWorker>();
        services.AddHostedService<ServiceStatusWorker>();
    })
    .Build();

await host.RunAsync();
