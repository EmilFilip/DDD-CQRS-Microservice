using System.ComponentModel.DataAnnotations;

namespace STC.Authentication.Domain.Models
{
    public class UserCredentials
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
