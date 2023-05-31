using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;
using MongoDB.Bson;
using Windows.Media.PlayTo;

namespace FlashCardApplication.UI.ViewModels
{
    public partial class EditUserViewModel : ObservableObject
    {
        IUserService userService;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string password;

        [RelayCommand]
        async void Cancel() => await Shell.Current.GoToAsync("///" + nameof(HomePage));

        [RelayCommand]
        async void Change() => await ChangeUserPage();

        public EditUserViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task ChangeUserPage()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password))
            {
                App.User.Name = Name;
                App.User.Password = Password;
                await userService.UpdateAsync(App.User);
                await Shell.Current.GoToAsync("///" + nameof(HomePage));
            }
        }
    }
}
