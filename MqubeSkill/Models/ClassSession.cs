namespace MqubeSkill.Models
{
    public class ClassSession
    {
        public int ClassSessionId { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }

        public string Title { get; set; } = "";
        public string? ClassLink { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Status { get; set; } = "Upcoming"; // Upcoming | Completed | Cancelled
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int DurationMinutes { get; set; }
    }
}