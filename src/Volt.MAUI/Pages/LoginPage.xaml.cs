using Volt.MAUI.ViewModels;

namespace Volt.MAUI.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnFacebookLoginClicked(object sender, EventArgs e)
    {
        // Handle Facebook login logic here
    }

    private void OnGoogleLoginClicked(object sender, EventArgs e)
    {
        // Handle Google login logic here
    }

    private void OnAppleLoginClicked(object sender, EventArgs e)
    {
        // Handle Apple login logic here
    }
}