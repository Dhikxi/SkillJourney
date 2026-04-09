using System.ComponentModel.DataAnnotations;

namespace MqubeSkill.Models
{
    public class RegisterTutorViewModel
    {
        [Required]
        public User User { get; set; } = new();

        [Required]
        public Tutor Tutor { get; set; } = new();
    }
}