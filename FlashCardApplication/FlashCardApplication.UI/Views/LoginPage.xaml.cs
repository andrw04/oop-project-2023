using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class LoginPage : ContentPage
{
	LoginPageViewModel viewModel;
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}