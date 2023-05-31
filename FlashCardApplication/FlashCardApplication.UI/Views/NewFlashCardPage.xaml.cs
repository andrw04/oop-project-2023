using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class NewFlashCardPage : ContentPage
{
	NewFlashCardViewModel viewModel;
	public NewFlashCardPage(NewFlashCardViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}