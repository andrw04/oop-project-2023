using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;

namespace FlashCardApplication.UI.ViewModels
{
    public partial class NewModuleViewModel : ObservableObject
    {
        private readonly IModuleService moduleService;

        [ObservableProperty]
        string moduleName;

        [ObservableProperty]
        string description;

        [RelayCommand]
        public async void Create() => await CreateModule();

        [RelayCommand]
        async void Cancel() => await Shell.Current.GoToAsync("///" + nameof(HomePage));

        public NewModuleViewModel(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        public async Task CreateModule()
        {
            if (!string.IsNullOrWhiteSpace(moduleName))
            {
                Module module = new Module()
                {
                    Name = moduleName,
                    Description = description,
                    UserId = App.User.Id
                };
                await moduleService.AddAsync(module);
                await Shell.Current.GoToAsync("///" + nameof(HomePage));
                MessagingCenter.Send(this, "UpdateModules");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Incorrect input!", "Cancel");
            }
        }
    }
}
