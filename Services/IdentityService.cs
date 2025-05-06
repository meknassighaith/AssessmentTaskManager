using System.Security.Claims;
using TaskManagementAPI.Models.User;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetCurrentUserId()
        {
            if (_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Sid)?.Value is string userIdStr && int.TryParse(userIdStr, out int userId))
            {
                return userId;
            }
            throw new UnauthorizedAccessException("UserId is not set in the current context.");
        }

        public UserRole GetCurrentUserRole()
        {
            if (_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value is string userRoleStr && Enum.TryParse(userRoleStr, out UserRole userRole))
            {
                return userRole;
            }
            throw new UnauthorizedAccessException("UserRole is not set in the current context.");
        }
    }
}
