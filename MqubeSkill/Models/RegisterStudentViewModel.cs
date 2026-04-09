using System.ComponentModel.DataAnnotations;

namespace MqubeSkill.Models
{
    public class RegisterStudentViewModel
    {
        [Required]
        public User User { get; set; } = new();

        [Required]
        public Student Student { get; set; } = new();
    }
}