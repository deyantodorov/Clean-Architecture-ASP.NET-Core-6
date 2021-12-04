
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Mvc.Models.User
{
    public class LoginVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set;}
    }
}
