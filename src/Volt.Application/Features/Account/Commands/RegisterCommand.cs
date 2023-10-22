using Volt.Application.Services;

namespace Volt.Application.Features.Account.Commands;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string Password) : IRequest<AuthenticationResult>;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}

public class RegisterCommand : IRequestHandler<RegisterRequest, AuthenticationResult>
{
    private readonly IIdentityService _identityService;

    public RegisterCommand(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthenticationResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
         return await _identityService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Username, request.Password);
    }
}