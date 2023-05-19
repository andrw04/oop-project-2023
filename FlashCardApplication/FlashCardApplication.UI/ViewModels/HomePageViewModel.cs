using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
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
        async void SignOut() => await Shell.Current.GoToAsync("//LoginPage");

        public HomePageViewModel(IUserService userService, IModuleService moduleService)
        {
            this.userService = userService;
            this.moduleService = moduleService;
            currentUser = App.User;
        }

        public async Task GetModules()
        {
            var modules = moduleService.GetAllUserModules(currentUser.Id).Result;
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Modules.Clear();
                foreach (var module in modules)
                {
                    Modules.Add(module);
                }
            });
        }

        public async Task GotoLoginPageAsync()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
