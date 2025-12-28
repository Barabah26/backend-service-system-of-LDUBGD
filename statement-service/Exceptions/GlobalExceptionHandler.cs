using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace statement_service.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is ResourceNotFoundException notFoundEx)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                httpContext.Response.ContentType = "application/problem+json";

                var problemDetails = new ProblemDetails
                {
                    Status = 404,
                    Title = "Recource not found",
                    Detail = notFoundEx.Message ?? "Requested recource not found"
                };

                await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
                return true;
            }

            return false;
        }
    }
}
