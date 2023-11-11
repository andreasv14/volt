using Volt.MAUI.ViewModels;

namespace Volt.MAUI.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}