using FlashCardApplication.UI.Views;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.MyApplication.Services;
using Microsoft.Extensions.Logging;
using FlashCardApplication.UI.ViewModels;
using CommunityToolkit.Maui;

namespace FlashCardApplication.UI
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

            SetupServices(builder.Services);

            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {
            // Services
            services.AddSingleton<IModuleService, ModuleService>();
            services.AddSingleton<IUserService, UserService>();

            // Pages
            services.AddTransient<LoginPage>();
            // services.AddTransient<RegistrationPage>();

            // ViewModels
            services.AddSingleton<LoginPageViewModel>();
        }
    }
}