using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Shared.Data;


namespace NetworkMonitoring.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=.\\MSSQL2019;Database=NetworkMonitoring;User id=sa;Password=Password1234;TrustServerCertificate=True;MultipleActiveResultSets=True;Encrypt=False;"));

            return builder.Build();
        }
    }
}