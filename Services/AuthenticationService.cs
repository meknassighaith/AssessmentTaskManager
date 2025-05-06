using TaskManagementAPI.Controllers;
using TaskManagementAPI.Repositories.Interfaces;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class AuthenticationService(IUserRepository userRepository, IJwtService jwtService) : IAuthenticationService
    {


        public string? AuthenticateUserAsync(LoginRequest loginRequest)
        {
            var user = userRepository.GetByName(loginRequest.Username);

            if (user == null)
            {
                return null;
            }
            if (user.Password != loginRequest.Password)
            {
                return null;
            }

            return jwtService.GenerateJwtToken(user);

        }
    }
}
