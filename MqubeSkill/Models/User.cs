using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MqubeSkill.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        [NotMapped]
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }


        public string? Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
