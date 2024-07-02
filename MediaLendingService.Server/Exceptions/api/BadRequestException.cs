namespace MediaLendingService.Server.Exceptions.api;

[ApiException(400)]
public class BadRequestException(string message) : ExternalApiException(message);