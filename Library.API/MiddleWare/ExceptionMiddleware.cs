using System.Net;
using System.Text.Json;
using Library.API.Helper;
using Microsoft.Extensions.Caching.Memory;

namespace Library.API.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostEnvironment environment;
        private readonly IMemoryCache memory;
        private readonly TimeSpan rateLimitWindow = TimeSpan.FromSeconds(30);

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment, IMemoryCache memory)
        {
            this.next = next;
            this.environment = environment;
            this.memory = memory;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                ApplySecurity(context);
                if (IsRequestAllowed(context) == false) { 
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var response = 
                        new APIException((int)HttpStatusCode.TooManyRequests,"Too Many requests, please try again later.");
                    await context.Response.WriteAsJsonAsync(response);

                }
                await next(context);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = environment.IsDevelopment()?
                    new APIException((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace)
                : new APIException((int)HttpStatusCode.InternalServerError,ex.Message);
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }

        private bool IsRequestAllowed(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            var cachKey = $"Rate:{ip}";
            var dateNow = DateTime.Now;

            var (timeStamp, count) = memory.GetOrCreate(cachKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = rateLimitWindow;
                return (timeStamp: dateNow, count: 0);
            });

            if(dateNow -  timeStamp < rateLimitWindow)
            {
                if (count >= 0)
                {
                    return false;
                }
                memory.Set(cachKey, (timeStamp, count += 1),rateLimitWindow);
            }
            else
            {
                memory.Set(cachKey, (timeStamp, count), rateLimitWindow);

            }
            return true;

        }

        private void ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1;mode=block";
            context.Response.Headers["X-Frame-Options"] = "DENY";
        }
    }
}
