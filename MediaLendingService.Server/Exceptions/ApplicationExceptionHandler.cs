using System.Reflection;
using MediaLendingService.Server.Serializers;
using Microsoft.AspNetCore.Diagnostics;

namespace MediaLendingService.Server.Exceptions;

public class ApplicationExceptionHandler : IExceptionHandler
{
    private const string ProblemDetailsJsonMediaType = "application/problem+json";

    private readonly IJsonSerializer _jsonSerializer;
    private readonly ILogger<ApplicationExceptionHandler> _logger;

    public ApplicationExceptionHandler(IJsonSerializer jsonSerializer, ILogger<ApplicationExceptionHandler> logger)
    {
        ArgumentNullException.ThrowIfNull(jsonSerializer);
        ArgumentNullException.ThrowIfNull(logger);

        _jsonSerializer = jsonSerializer;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An error occurred while processing the request.");

        var apiAttribute = exception.GetType().GetCustomAttribute<ApiExceptionAttribute>();
        // ReSharper disable once InvertIf
        if (apiAttribute != null)
        {
            var message = exception is ExternalApiException external ? external.Message : null;
            var problemDetails = ApplicationProblemDetailsDefaults.GetProblemDetails(apiAttribute.StatusCode, message);
            httpContext.Response.StatusCode = apiAttribute.StatusCode;
            httpContext.Response.ContentType = ProblemDetailsJsonMediaType;

            var result = _jsonSerializer.Serialize(problemDetails);
            await httpContext.Response.WriteAsync(result, cancellationToken);
            return true;
        }

        // The IProblemDetailsService service will handle in this case
        // see Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddlewareImpl
        return false;
    }
}