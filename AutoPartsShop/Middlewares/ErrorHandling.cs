using System.ComponentModel.DataAnnotations;
using AutoPartsShop.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var (statusCode, title, detail) = ex switch
                {
                    KeyNotFoundException => (StatusCodes.Status404NotFound, "Not Found", ex.Message),
                    NotFoundException => (StatusCodes.Status404NotFound, "Not Found", ex.Message),

                    ValidationException => (StatusCodes.Status400BadRequest, "Validation Failed", ex.Message),
                    BadRequestException => (StatusCodes.Status400BadRequest, "Bad Request", ex.Message),

                    UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized", ex.Message),

                    _ => (StatusCodes.Status500InternalServerError, "Server Error", "Please contact support if the problem persists.")
                };

                if (statusCode >= 500)
                {
                    _logger.LogError(ex, "Unhandled exception for {Method} {Path}: {Message}", context.Request.Method, context.Request.Path, ex.Message);
                }
                else
                {
                    _logger.LogWarning("Request failed with {StatusCode} for {Method} {Path}: {Message}", statusCode, context.Request.Method, context.Request.Path, ex.Message);
                }

                if (context.Response.HasStarted) throw;

                context.Response.Clear();
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/problem+json";

                var problem = new ProblemDetails
                {
                    Status = statusCode,
                    Title = title,
                    Detail = detail,
                    Instance = context.Request.Path
                };

                problem.Extensions["traceId"] = context.TraceIdentifier;

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}