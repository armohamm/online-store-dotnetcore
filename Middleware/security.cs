using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using project.Services;
using project.Entities;

namespace project.Middleware
{
    public class UserKeyValidatorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly EmployeeServicesImpl employeeServicesImpl;
        public UserKeyValidatorsMiddleware(RequestDelegate next)
        {
            _next = next;
            employeeServicesImpl = new EmployeeServicesImpl();
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Values"))
            {
                if (!context.Request.Headers.Keys.Contains("accessToken"))
                {
                    context.Response.StatusCode = 400; //Bad Request
                    await context.Response.WriteAsync("User Key is missing");
                    return;
                }
                else
                {
                    // parse token to get user info
                    string accessToken = context.Request.Headers["accessToken"];
                    Token token = employeeServicesImpl.parseToken(accessToken);
                    // pass token to next request
                    context.Items["userInfo"] = token;

                }
            }



            await _next.Invoke(context);
        }

    }
    #region ExtensionMethod
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorsMiddleware>();
            return app;
        }
    }
    #endregion
}