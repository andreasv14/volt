namespace Volt.Application.Services;

public record AuthenticationResult(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    string Token);