namespace MediaLendingService.Server.Exceptions.api;

[ApiException(204)]
public class NoOpDeleteException(string message = "Nothing to delete") : ExternalApiException(message);