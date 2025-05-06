using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TaskUserManagementAPI.Services.Middleware
{
    public class RoleMiddleware
{
    private readonly RequestDelegate _next;

    public RoleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Logic to validate roles
        var userRole = context.User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;

        if (string.IsNullOrEmpty(userRole))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }

        await _next(context);
    }
}

}