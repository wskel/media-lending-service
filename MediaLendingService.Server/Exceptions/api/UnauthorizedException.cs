namespace MediaLendingService.Server.Exceptions.api;

[ApiException(401)]
public class UnauthorizedException(string message) : ExternalApiException(message);