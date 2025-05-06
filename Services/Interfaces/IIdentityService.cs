using TaskManagementAPI.Models.User;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IIdentityService
    {
        int GetCurrentUserId();
        UserRole GetCurrentUserRole();
    }
}
