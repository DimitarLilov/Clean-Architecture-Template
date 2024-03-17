using FastEndpoints;
using FluentResults;
using FluentValidation.Results;
using Template.Domain.Common.Errors;

namespace Template.Web.Extensions;

public static class ResponseExtensions
{
    public static async Task SendProblemResponse<T>(this IEndpoint endpoint, Result<T> result, CancellationToken cancellationToken)
    {
        if(!result.IsSuccess)
        {
            ErrorCode errorCode = GetErrorCode(result.Errors.First());

            int statusCode = errorCode switch
            {
                ErrorCode.NotFound => StatusCodes.Status404NotFound,
                ErrorCode.Invalid => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            List<ValidationFailure> failures = ToFailures(result.Errors);

            await endpoint.HttpContext.Response.SendErrorsAsync(failures, statusCode, cancellation: cancellationToken);
        }
    }

    static ErrorCode GetErrorCode(IError error)
    {
        return (ErrorCode)error.Metadata[nameof(ErrorCode)];
    }

    static List<ValidationFailure> ToFailures(List<IError> errors)
    {
        return errors
        .Select(e => 
        {
            var errorCode = e.Metadata[DomainError.ErrorCodeLiteral];
            return new ValidationFailure(errorCode.ToString(), e.Message);
        })
        .ToList();
    }
}
