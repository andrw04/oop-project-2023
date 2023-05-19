using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;
using System.Net.Mail;

namespace FlashCardApplication.UI.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        private readonly IUserService userService;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [RelayCommand]
        public async void GotoLoginPage() => await Shell.Current.GoToAsync("//LoginPage");

        [RelayCommand]
        public async void Register()
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                if (!IsValid(email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email is incorrect!", "Cancel");
                    return;
                }

                var exists = await userService.Exists(userName);

                if (exists)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "This name is already taken!", "Cancel");
                    return;
                }


                await userService.AddAsync(new Domain.Entities.User() { Login = userName, Email = email, Password = password });

                var user = await userService.GetUserAsync(userName, password);

                if (user != null)
                {
                    App.User = user;

                    await Shell.Current.GoToAsync("//HomePage");
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

        public RegisterPageViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress _ = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
