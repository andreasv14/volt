using Refit;
using Volt.MAUI.Models;

namespace Volt.MAUI.Services;

public interface IAccountService

{
    [Post("/api/Account/request")]
    Task<AuthenticationResponse> RegisterAsync([Body] RegisterRequest request);

    [Post("/api/Account/login")]
    Task<AuthenticationResponse> LoginAsync([Body] LoginRequest request);
}