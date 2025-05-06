using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models.User
{
    [Index(nameof(Username), IsUnique = true)] // Unique Index
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A username is mandatory")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = " A Role is mandatory")]
        public UserRole Role { get; set; } // "Admin" or "User"

        [Required]
        [MinLength(8, ErrorMessage = "Password must have at least 8 characters long")]
        public string Password { get; internal set; } = string.Empty;

        //public virtual ICollection<TaskToDo> TaskItems { get; set; } = new HashSet<TaskToDo>();
    }

    public enum UserRole
    {
        Admin,
        User
    }



}
