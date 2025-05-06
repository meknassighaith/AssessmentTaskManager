using System.ComponentModel;

namespace TaskManagementAPI.Models.User;

public class DtoUser
{
    public int UserId { get; set; }
    [DisplayName("User")]
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
   

}

