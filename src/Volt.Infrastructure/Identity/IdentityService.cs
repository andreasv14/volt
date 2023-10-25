using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Volt.Application.Services;

namespace Volt.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<UserRole> _roleManager;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<UserRole> roleManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AuthenticationResult> LoginAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username) ?? throw new Exception("User does not exist");

        var passwordIsValid = await _userManager.CheckPasswordAsync(user, password);
        if (!passwordIsValid)
        {
            throw new Exception("Invalid credentials");
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        var userRolesClaims = new List<Claim>();
        foreach (var userRole in userRoles)
        {
            userRolesClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = _jwtTokenGenerator.GenerateToken(
            user.Id,
            user.FirstName,
            user.LastName);

        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            token);
    }

    public async Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string username, string password)
    {
        var userExists = await _userManager.FindByNameAsync(username);
        if (userExists != null)
        {
            throw new InvalidOperationException("Username already exist");
        }

        var userId = Guid.NewGuid();
        ApplicationUser newUser = new ApplicationUser
        {
            Id = userId,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = username
        };
        // Hash the password
        var passwordHash = new PasswordHasher<ApplicationUser>().HashPassword(newUser, password);
        newUser.PasswordHash = passwordHash;

        var identityResult = await _userManager.CreateAsync(newUser);
        if (!identityResult.Succeeded)
        {
            var errors = new List<string>();
            foreach (var item in identityResult.Errors)
            {
                errors.Add(item.Description);
            }
            string errorList = string.Join(',', errors);
            throw new InvalidOperationException($"Registration failed with errors: {errorList}");
        }

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }
}
