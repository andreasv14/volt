using CommunityToolkit.Mvvm.ComponentModel;

namespace Volt.MAUI.Models;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string Password);
