using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Collector.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Fatal($"Exception: {ex} in [Action] : {System.Reflection.MethodBase.GetCurrentMethod().Name} \n" +
                                  $" [Attributes]: \n" +
                                  $" [Time]: { DateTime.UtcNow}");

                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { message = ex?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
