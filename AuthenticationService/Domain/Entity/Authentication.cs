using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChatServerApi.Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string? Email { get; set; } // TODO :: зашифровывать в bcrypt
        [Required]
        public DateTime CreatedDate { get; set; }
    }

    [PrimaryKey(nameof(UserId))]
    public class Identification
    {
        public Guid UserId { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Значение {0} не может превышать {1} символов. и быть короче {2}")]
        [RegularExpression(@"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$")]
        public string Login { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Значение {0} не может превышать {1} символов. и быть короче {2}")]
        [RegularExpression(@"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$")]        
        public string Password { get; set; } // TODO :: зашифровывать в bcrypt
        [Required]
        public List<string> Roles { get; set; }

        public Identification()
        {
            Roles = new List<string>();
        }

    }
}