using System.Reflection;
using MediaLendingService.Server.Exceptions;

namespace MediaLendingService.Server.Startup;

public class ApiExceptionStartupAssertion : IStartupAssertion
{
    public void Validate()
    {
        var invalidTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(type =>
                type.GetCustomAttribute<ApiExceptionAttribute>() != null
                && !typeof(Exception).IsAssignableFrom(type))
            .ToList();

        // ReSharper disable once InvertIf
        if (invalidTypes.Count != 0)
        {
            var typeNames = string.Join(", ", invalidTypes.Select(t => t.FullName));
            throw new InvalidOperationException(
                $"{nameof(ApiExceptionAttribute)} can only be used on Exception classes."
                + $" Invalid usage found on: {typeNames}");
        }
    }
}