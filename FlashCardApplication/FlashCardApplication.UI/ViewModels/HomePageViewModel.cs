using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;
using System.Collections.ObjectModel;

namespace FlashCardApplication.UI.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly IUserService userService;
        private readonly IModuleService moduleService;

        public ObservableCollection<Module> Modules { get; set; } = new();

        [ObservableProperty]
        User currentUser;

        [RelayCommand]
        async void UpdateModuleList() => await GetModules();

        [RelayCommand]
        async void SignOut() => await Shell.Current.GoToAsync("//" + nameof(LoginPage));

        [RelayCommand]
        async void AddModule() => await Shell.Current.GoToAsync(nameof(NewModulePage));

        [RelayCommand]
        async void ChangeUser() => await Shell.Current.GoToAsync(nameof(EditUserPage));

        [RelayCommand]
        async void Info() => await Shell.Current.GoToAsync(nameof(InfoPage));

        [RelayCommand]
        async void ShowModule(Module module) => await GotoModulePage(module);


        public HomePageViewModel(IUserService userService, IModuleService moduleService)
        {
            this.userService = userService;
            this.moduleService = moduleService;
            currentUser = App.User;

            MessagingCenter.Subscribe<NewModuleViewModel>(this, "UpdateModules", async (sender) =>
            {
                await GetModules();
            });
        }

        public async Task GetModules()
        {
            var modules = await moduleService.GetAllUserModules(currentUser.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Modules.Clear();
                foreach (var module in modules)
                {
                    Modules.Add(module);
                }
            });
        }

        public async Task GotoModulePage(Module module)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Module", module }
            };
            await Shell.Current.GoToAsync(nameof(ModulePage), parameters);
        }
    }
}
