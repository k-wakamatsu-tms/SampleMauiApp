namespace SampleMauiApp.Helpers;

public static class ServiceHelpers
{
    public static TService GetService<TService>() =>
        Current.GetService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
            Microsoft.Maui.MauiWinUIApplication.Current.Services;
#elif ANDROID
        Microsoft.Maui.MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        Microsoft.Maui.MauiUIApplicationDelegate.Current.Services;
#else
        null;
#endif
}
