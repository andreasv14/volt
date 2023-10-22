namespace Volt.Application.Services;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}