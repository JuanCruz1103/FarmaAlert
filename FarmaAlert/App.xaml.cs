namespace FarmaAlert;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Comienza con la página de login en lugar de AppShell
        MainPage = new AppShell();
    }
}

// Clase auxiliar para obtener servicios desde cualquier lugar
public static class ServiceHelper
{
    public static TService GetService<TService>()
        => Current.GetService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS
        MauiWinUIApplication.Current.Services;
#elif ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#else
        null;
#endif
}