using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class EditUserPage : ContentPage
{
	EditUserViewModel viewModel;
	public EditUserPage(EditUserViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}