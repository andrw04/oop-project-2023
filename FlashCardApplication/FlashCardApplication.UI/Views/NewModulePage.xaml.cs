using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class NewModulePage : ContentPage
{
	NewModuleViewModel viewModel;
	public NewModulePage(NewModuleViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}