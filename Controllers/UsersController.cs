using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models.User;
using TaskManagementAPI.Repositories.Interfaces;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class UsersController(IUserRepository userRepository, ILogger<UsersController> logger) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILogger<UsersController> _logger = logger;

        [HttpGet]
        public IActionResult GetAll() 
        {
            _logger.LogInformation("Getting all users");
            return Ok(_userRepository.GetAll()); 
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            _logger.LogInformation("Getting user by ID: {Id}", id);
            return Ok(_userRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(DtoUser user)
        {
            _logger.LogInformation("Creating user: {User}", user);
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut]
        public IActionResult Update(DtoUser user)
        {
            _logger.LogInformation("Updating user: {User}", user);
            _userRepository.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting user by ID: {Id}", id);
            _userRepository.Delete(id);
            return NoContent();
        }
    }
}
