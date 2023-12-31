﻿using Microsoft.AspNetCore.Diagnostics;
using Models.Concrete.ErrorDetails;
using Models.Concrete.Exceptions.Common;
using Serilog;

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
                            UnauthorizedException => StatusCodes.Status401Unauthorized,
                            _ => StatusCodes.Status500InternalServerError
                        };


                        var errorDetails = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        };

                        Log.Error("error during executing {@RequestPath} {@Error}", context.Request.Path.Value, contextFeature.Error);
                        Log.CloseAndFlush();
                        await context.Response.WriteAsync(errorDetails.ToString());

                    }
                });
            });
        }
    }
}
