using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Volt.MAUI.Models;
using Volt.MAUI.Services;

namespace Volt.MAUI.ViewModels;

public partial class RegisterViewModel : ViewModelBase
{
    private readonly IAccountService _identityService;

    public RegisterViewModel(IAccountService identityService)
    {
        _identityService = identityService;
    }

    [ObservableProperty]
    string firstName;

    [ObservableProperty]
    string lastName;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string username;

    [ICommand]
    async Task Register()
    {
        try
        {
            IsBusy = true;

            var res = await _identityService.RegisterAsync(new RegisterRequest(firstName,
                lastName,
                email,
                password,
                username));

            string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");
            if (oauthToken == null)
            {
                await SecureStorage.Default.SetAsync("oauth_token", res.Token);
            }

            IsBusy = false;

            await Shell.Current.GoToAsync("//home");
        }
        catch (Exception e)
        {

            throw;
        }
    }
}