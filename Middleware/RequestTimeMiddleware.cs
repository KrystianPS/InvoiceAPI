
using System.Diagnostics;

namespace InvoiceAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {

        private readonly ILogger<RequestTimeMiddleware> _logger;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {

            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            var stopwatch = Stopwatch.StartNew();

            await next.Invoke(context);
            stopwatch.Stop();
            var elapsedMiliseconds = stopwatch.ElapsedMilliseconds;

                var message =
                    $"Request [{context.Request.Method}] at {context.Request.Path}] took {elapsedMiliseconds} ms";
                _logger.LogWarning(message);




        }
    }
}
