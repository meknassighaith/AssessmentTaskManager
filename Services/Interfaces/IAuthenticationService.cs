using TaskManagementAPI.Controllers;
using TaskManagementAPI.Data;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string? AuthenticateUserAsync(LoginRequest loginRequest);

        //void ChangePasswordAsync(string username, string newPassword);

        //void ForgotPasswordAsync(string username);
    }
}
