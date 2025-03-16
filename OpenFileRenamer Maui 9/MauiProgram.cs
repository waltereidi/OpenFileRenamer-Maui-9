using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;

namespace OpenFileRenamer_Maui_9
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            
            var builder = MauiApp.CreateBuilder();
            builder
                
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitCore(options=>
                {
                    options.SetShouldUseStatusBarBehaviorOnAndroidModalPage(true);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
