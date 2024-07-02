namespace MediaLendingService.Server.Exceptions.api;

[ApiException(404)]
public class NotFoundException(string message) : ExternalApiException(message);