using System.ComponentModel.DataAnnotations;
namespace MqubeSkill.Models { 
    public class Student {  
        public int StudentId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string? ParentName { get; set; } 
        public string? Gender { get; set; }
        [Required]
        public string? SchoolName { get; set; }
        [Required]
        public string? ContactNo { get; set; }
        public string? Address { get; set; }
        [Required]
        public string? Board { get; set; }
        [Required]
        public string? GradeLevel { get; set; }
        public string? PreferredTime { get; set; }
        [Required]
        public string? Subject { get; set; }
        public User? User { get; set; }
    } 
}