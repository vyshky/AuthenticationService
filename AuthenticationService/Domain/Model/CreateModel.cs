using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Domain.Model
{
    public class CreateModel
    {
        [Required]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Значение {0} не может превышать {1} символов. и быть короче {2}")]
        [RegularExpression(@"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$")]
        public string UserName { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Значение {0} не может превышать {1} символов. и быть короче {2}")]
        [RegularExpression(@"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$")]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public List<string> Roles { get; set; }
    }
}
