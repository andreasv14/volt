namespace Volt.Application.Services;

public interface IIdentityService
{
    Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string username, string password);

    Task<AuthenticationResult> LoginAsync(string username, string password);
}