using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace MediaLendingService.Server.Exceptions;

public static class ApplicationProblemDetailsDefaults
{
    private static readonly Dictionary<int, (string Type, string Title)> Defaults = new()
    {
        [400] = ("https://tools.ietf.org/html/rfc9110#section-15.5.1", "Bad Request"),
        [401] = ("https://tools.ietf.org/html/rfc9110#section-15.5.2", "Unauthorized"),
        [403] = ("https://tools.ietf.org/html/rfc9110#section-15.5.4", "Forbidden"),
        [404] = ("https://tools.ietf.org/html/rfc9110#section-15.5.5", "Not Found"),
        [405] = ("https://tools.ietf.org/html/rfc9110#section-15.5.6", "Method Not Allowed"),
        [406] = ("https://tools.ietf.org/html/rfc9110#section-15.5.7", "Not Acceptable"),
        [409] = ("https://tools.ietf.org/html/rfc9110#section-15.5.10", "Conflict"),
        [415] = ("https://tools.ietf.org/html/rfc9110#section-15.5.16", "Unsupported Media Type"),
        [422] = ("https://tools.ietf.org/html/rfc4918#section-11.2", "Unprocessable Entity"),
        [500] = DefaultValue
    };

    private static (string Type, string Title) DefaultValue => (
        "https://tools.ietf.org/html/rfc9110#section-15.6.1",
        "An error occurred while processing your request.");

    public static ProblemDetails GetProblemDetails(int statusCode, string? detail = null)
    {
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Detail = detail
        };

        if (Defaults.TryGetValue(statusCode, out var defaults))
        {
            problemDetails.Type = defaults.Type;
            problemDetails.Title = defaults.Title;
        }
        else
        {
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);
            problemDetails.Title = !string.IsNullOrEmpty(reasonPhrase)
                ? reasonPhrase
                : DefaultValue.Title;
        }

        return problemDetails;
    }
}