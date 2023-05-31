using FlashCardApplication.UI.ViewModels;

namespace FlashCardApplication.UI.Views;

public partial class ModulePage : ContentPage
{
	ModuleViewModel viewModel;
	public ModulePage(ModuleViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}