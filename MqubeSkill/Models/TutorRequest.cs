using System.ComponentModel.DataAnnotations;

namespace MqubeSkill.Models
{
    public class TutorRequest
    {
        public int TutorRequestId { get; set; }

        public int TutorId { get; set; }
        public int StudentId { get; set; }

        public string? Subject { get; set; }
        public string? PreferredTime { get; set; }

        public string Status { get; set; } = "Pending"; // Pending / Accepted / Rejected
        
        public DateTime RequestDate { get; set; } = DateTime.Now;

        public Tutor? Tutor { get; set; }
        public Student? Student { get; set; }
    }
}