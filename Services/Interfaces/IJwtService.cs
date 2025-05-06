using TaskManagementAPI.Models.User;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IJwtService
    {

        string GenerateJwtToken(User user);

        //Task<string> GenerateRefreshToken(string token);
    }
}
