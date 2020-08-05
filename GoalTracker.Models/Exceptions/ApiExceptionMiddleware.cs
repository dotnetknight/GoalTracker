using GoalTracker.Models.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace GoalTracker.Models.Exceptions
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = ex.ContentType;

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message
                }.ToString());

                return;
            }
        }
    }

    public static class ApiExtensions
    {
        public static IApplicationBuilder UseApiExceptionnMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiExceptionMiddleware>();
        }
    }
}
