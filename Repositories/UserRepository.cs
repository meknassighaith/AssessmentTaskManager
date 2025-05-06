using System;
using TaskManagementAPI.Data;
using TaskManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using TaskManagementAPI.Models.User;

namespace TaskManagementAPI.Repositories
{
    public class UserRepository(TaskManagementDB context, IValidator<DtoUser> validator) : IUserRepository
    {
        private readonly TaskManagementDB _context = context;
        private readonly IValidator<DtoUser> _validator = validator;

        public IEnumerable<DtoUser> GetAll()
        {
            List<DtoUser> dtoUsers = new List<DtoUser>();
            var countorigin = _context.Users.Count();
            foreach (var user in _context.Users)
            {
                dtoUsers.Add(new DtoUser
                {
                    UserId = user.Id,
                    UserName = user.Username,
                    Role = user.Role.ToString()
                });
            }
            var count = dtoUsers.Count;
            return dtoUsers;
        }
        public DtoUser GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id must be greater than zero", nameof(id));
            var user = _context.Users.Find(id) ?? throw new ArgumentException("User not found", nameof(id));
            DtoUser dtoUser = new()
            {
                UserId = user.Id,
                UserName = user.Username,
                Role = user.Role.ToString()
            };
            
            return dtoUser;
        }
        public User GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be null or empty", nameof(name));
            var user = _context.Users.FirstOrDefault(u => u.Username == name);
            return user ?? throw new ArgumentException("User not found", nameof(name));
        }
        public void Add(DtoUser user) {
            if (user == null) throw new ArgumentException("User must not be null", nameof(user));
            
            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _context.Users.Add(new User
            {
                Username = user.UserName,
                Role = Enum.Parse<UserRole>(user.Role),
                Password = "123456"
                
            });
            _context.SaveChanges(); 
        }
        public void Update(DtoUser user) 
        {
            if (user == null) throw new ArgumentException("User must not be null", nameof(user));
            var userupdated = _context.Users.Find(user.UserId) ?? throw new ArgumentException("User not found", nameof(user.UserId));
            userupdated.Username = user.UserName;
            userupdated.Role = Enum.Parse<UserRole>(user.Role);
            userupdated.Password = "123456"; // We don't manage Password in this example, we hard the password just for Test
            _context.Users.Update(userupdated); 
            _context.SaveChanges(); 
        }
        public void Delete(int id) 
        { 
            var user = _context.Users.Find(id); 
            if (user != null) 
            { 
                _context.Users.Remove(user); 
                _context.SaveChanges(); 
            } 
        }
    }
}
