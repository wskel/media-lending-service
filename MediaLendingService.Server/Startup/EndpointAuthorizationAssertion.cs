using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MediaLendingService.Server.Startup;

public class EndpointAuthorizationAssertion : IStartupAssertion
{
    private readonly List<string> _failures = [];

    public void Validate()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var controllers = assembly.GetTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
            .Where(type => type.FullName != null && !type.FullName.StartsWith("Microsoft.AspNetCore.Identity"))
            .Where(type => type is { IsAbstract: false, IsInterface: false });
        ;

        foreach (var controller in controllers)
        {
            ValidateController(controller);
        }

        if (_failures.Count != 0)
        {
            throw new AggregateException(
                "The following endpoints are missing [Authorize] or [AllowAnonymous] attribute:",
                _failures.Select(f => new Exception(f)));
        }
    }

    private void ValidateController(Type controller)
    {
        var methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.DeclaringType == controller);

        foreach (var method in methods)
        {
            if (IsEndpointMethod(method))
            {
                ValidateEndpoint(controller, method);
            }
        }
    }

    private static bool IsEndpointMethod(MethodInfo method)
        => method.GetCustomAttributes(true).Any(attr => attr is HttpMethodAttribute);

    private void ValidateEndpoint(Type controller, MethodInfo method)
    {
        var hasAuthorize = HasAttribute<AuthorizeAttribute>(controller) || HasAttribute<AuthorizeAttribute>(method);
        var hasAllowAnonymous = HasAttribute<AllowAnonymousAttribute>(controller) ||
                                HasAttribute<AllowAnonymousAttribute>(method);

        if (!hasAuthorize && !hasAllowAnonymous)
        {
            _failures.Add(
                $"Endpoint {controller.Name}.{method.Name} is missing [Authorize] or [AllowAnonymous] attribute.");
        }
    }

    private static bool HasAttribute<T>(MemberInfo memberInfo) where T : Attribute
        => memberInfo.GetCustomAttributes(typeof(T), true).Length != 0;
}