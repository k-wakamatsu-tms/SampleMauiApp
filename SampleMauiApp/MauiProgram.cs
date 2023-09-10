using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace SampleMauiApp
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
                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FiraSans-Light.ttf", "RegularFont");
                    fonts.AddFont("FiraSans-Medium.ttf", "MediumFont");
                })
                .ConfigureLifecycleEvents(events =>
                {
#if ANDROID
                    events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusTrancelucent(activity)));
                    static void MakeStatusTrancelucent(Android.App.Activity activity)
                    {
                        activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                        activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
                        activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                    }
#endif
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            RegisterAppServices(builder.Services);

            return builder.Build();
        }

        private static void RegisterAppServices(IServiceCollection services)
        {

            services.AddSingleton<IConnectivity>(Connectivity.Current);
        }
    }
}