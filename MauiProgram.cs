using Maui_SQLite_Demo.Services;
using Microsoft.Extensions.Logging;

namespace Maui_SQLite_Demo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            builder.Services.AddSingleton<LocalDbService>(); // Add LocalDbService to the DI container (DI container is a collection of services that are available throughout the application)
            builder.Services.AddTransient<MainPage>(); // Add MainPage to the DI container


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
