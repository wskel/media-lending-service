namespace MediaLendingService.Server.Exceptions.api;

[ApiException(409)]
public class ConflictException(string message) : ExternalApiException(message);