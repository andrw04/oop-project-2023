using FlashCardApplication.UI.Views;

namespace FlashCardApplication.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(NewModulePage), typeof(NewModulePage));
            Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
            Routing.RegisterRoute(nameof(FlashCardPage), typeof(FlashCardPage));
            Routing.RegisterRoute(nameof(ModulePage), typeof(ModulePage));
            Routing.RegisterRoute(nameof(EditUserPage), typeof(EditUserPage));
            Routing.RegisterRoute(nameof(NewFlashCardPage), typeof(NewFlashCardPage));
            Routing.RegisterRoute(nameof(LearnPage), typeof(LearnPage));
        }
    }
}