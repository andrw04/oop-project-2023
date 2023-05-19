using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class RegisterPage : ContentPage
{
	RegisterPageViewModel viewModel;
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}