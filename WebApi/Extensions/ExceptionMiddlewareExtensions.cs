using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Models.Concrete.ErrorDetails;
using Models.Concrete.Exceptions;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };





                        var errorDetails = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        };


                        await context.Response.WriteAsync(errorDetails.ToString());
                    }
                });
            });
        }
    }
}
