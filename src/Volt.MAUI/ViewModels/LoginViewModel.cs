using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using Volt.MAUI.Models;
using Volt.MAUI.Services;

namespace Volt.MAUI.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly IAccountService _accountService;

    private IAsyncRelayCommand _loginCommand;

    public LoginViewModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    public IAsyncRelayCommand LoginCommand => _loginCommand ??= new AsyncRelayCommand(LoginAsync, () =>
    {
        return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
    });

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.PropertyName == nameof(Username) || e.PropertyName == nameof(Password))
        {
            _loginCommand?.NotifyCanExecuteChanged();
        }
    }

    private async Task LoginAsync()
    {
        try
        {
            IsBusy = true;

            var res = await _accountService.LoginAsync(new LoginRequest(Username, Password));
            var oauthToken = await SecureStorage.Default.GetAsync("oauth_token");
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
