using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Model
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsValid()
        {
            return UserName != string.Empty && Password != string.Empty;
        }
    }
}
