namespace MediaLendingService.Server.Startup;

public class StartupAssertionValidator(IEnumerable<IStartupAssertion> assertions) : IStartupAssertionValidator
{
    public void Validate()
    {
        foreach (var assertion in assertions)
        {
            assertion.Validate();
        }
    }
}