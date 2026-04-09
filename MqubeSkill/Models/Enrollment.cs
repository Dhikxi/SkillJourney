using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MqubeSkill.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public int SubjectId { get; set; }

        public Student? Student { get; set; }
        public Tutor? Tutor { get; set; }
        public Subject? Subject { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Active";
        public string PaymentStatus { get; set; } = "Pending";
    }
}