namespace MediaLendingService.Server.Exceptions;

public abstract class ExternalApiException : Exception
{
    private ExternalApiException() { }

    protected ExternalApiException(string message) : base(message) { }
}