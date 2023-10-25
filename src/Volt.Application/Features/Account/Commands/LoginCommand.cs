using Volt.Application.Services;

namespace Volt.Application.Features.Account.Commands;

public record LoginRequest(string Usename, string Password) : IRequest<AuthenticationResult>;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Usename).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
    }
}

public class LoginCommand : IRequestHandler<LoginRequest, AuthenticationResult>
{
    private readonly IIdentityService _identityService;

    public LoginCommand(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthenticationResult> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        return await _identityService.LoginAsync(request.Usename, request.Password);
    }
}