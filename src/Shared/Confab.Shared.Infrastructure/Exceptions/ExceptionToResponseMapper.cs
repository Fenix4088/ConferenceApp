using System.Collections.Concurrent;
using System.Net;
using Confab.Shared.Abstractions.Exceptions;
using Humanizer;

namespace Confab.Shared.Infrastructure.Exceptions;

public class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();
    
    public ExceptionResponse Map(Exception exception) => exception switch
    {
        ConferenceAppException => new ExceptionResponse(new ErrorsResponse(new Error(GetErrorCode(exception), exception.Message)), HttpStatusCode.BadRequest),
        _ => new ExceptionResponse(new ErrorsResponse(new Error("error", "There was an error.")), HttpStatusCode.InternalServerError)
    };

    private record Error(string Code, string Message);
    
    private record ErrorsResponse(params Error[] Errors);
    
    private static string GetErrorCode(object exception) {

        var codeType = exception.GetType();
        return Codes.GetOrAdd(codeType, codeType.Name.Underscore().Replace("_exception", string.Empty));
    }
}
