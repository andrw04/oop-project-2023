using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class HomePage : ContentPage
{
	HomePageViewModel viewModel;
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}