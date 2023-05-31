using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class LearnPage : ContentPage
{
	LearnViewModel viewModel;
	public LearnPage(LearnViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}