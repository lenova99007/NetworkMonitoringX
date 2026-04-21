namespace NetworkMonitoring.Maui;

//public static class Program
//{
//    public static void Main(string[] args)
//    {
//        var builder = MauiApp.CreateBuilder();
//        builder
//            .UseMauiApp<App>()
//            .UseMauiCommunityToolkit()
//            .ConfigureFonts(fonts =>
//            {
//                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
//            });

//        builder.Services.AddMauiBlazorWebView();

//#if DEBUG
//        builder.Services.AddBlazorWebViewDeveloperTools();
//#endif

//        var app = builder.Build();

//        // For Windows
//#if WINDOWS
//        Microsoft.UI.Xaml.Application.Start((p) => {});
//#endif

//        // For other platforms, the app runs automatically
//        return;
//    }
//}



public static class Program
{
    public static void Main(string[] args)
    {
        var app = MauiProgram.CreateMauiApp();
        // App runs automatically
    }
}