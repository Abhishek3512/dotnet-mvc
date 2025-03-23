using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DovetailSol.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isAuthenticated = context.Session.GetString("IsAuthenticated");
            if (isAuthenticated != "true" && !context.Request.Path.StartsWithSegments("/Account") && !context.Request.Path.StartsWithSegments("/css") &&
                    !context.Request.Path.StartsWithSegments("/js") &&
                    !context.Request.Path.StartsWithSegments("/lib"))
            {
                context.Response.Redirect("/Account/Login");
                return;
            }
            await _next(context);
        }
    }
}