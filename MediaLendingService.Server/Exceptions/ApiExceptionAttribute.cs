namespace MediaLendingService.Server.Exceptions;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ApiExceptionAttribute(int statusCode) : Attribute
{
    public int StatusCode { get; } = statusCode;
}