using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;
using MongoDB.Bson.IO;

namespace FlashCardApplication.UI.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly IUserService userService;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;

        [RelayCommand]
        public async void GotoRegisterPage() => await Shell.Current.GoToAsync("//RegisterPage");

        [RelayCommand]
        public async void Login()
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var user = await userService.GetUserAsync(userName, password);

                if (user != null)
                {
                    App.User = user;

                    await Shell.Current.GoToAsync(nameof(HomePage));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong login or password!", "Cancel");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Incorrect login or password!", "Cancel");
            }
        }

        public LoginPageViewModel(IUserService userService)
        {
            this.userService = userService;
        }

    }
}
