namespace MediaLendingService.Server.Startup;

public static class StartupAssertions
{
    public static void RegisterStartupAssertions(this IServiceCollection services)
    {
        var assertionType = typeof(IStartupAssertion);
        var assertions = typeof(StartupAssertions).Assembly.GetTypes()
            .Where(p => assertionType.IsAssignableFrom(p)
                        && p is { IsInterface: false, IsAbstract: false });

        foreach (var assertion in assertions)
        {
            services.AddSingleton(assertionType, assertion);
        }
    }
}