using Microsoft.Extensions.Logging;
using FarmaAlert.Services;
using FarmaAlert.ViewModels;
using FarmaAlert.Pages;
using FarmaAlert.ViewModel;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Charts;

namespace FarmaAlert;

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

        // Registrar Servicios
        builder.Services.AddSingleton<BaseApiService>();
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<AlarmaService>();

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("TU_CLAVE_DE_LICENCIA");
        builder.ConfigureSyncfusionCore();

        // Registrar todos los controles de Syncfusion manualmente
        builder.Services.AddSingleton(typeof(SfCircularChart));
        builder.Services.AddSingleton(typeof(PieSeries));
        builder.Services.AddSingleton(typeof(ChartLegend));

        // Registrar ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<AlarmaViewModel>();
        builder.Services.AddTransient<AgregarAlarmaViewModel>();
        builder.Services.AddTransient<EditarAlarmaViewModel>();
        
        // Registrar Páginas
        builder.Services.AddTransient<login>();
        builder.Services.AddTransient<Register>();
        builder.Services.AddTransient<recoberPassword>();
        builder.Services.AddTransient<Pastillas>();
        builder.Services.AddTransient<AgregarAlarma>();
        builder.Services.AddTransient<EditarAlarma>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}