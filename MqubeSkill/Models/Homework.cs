namespace MqubeSkill.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }

        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }

        // Assigned | Submitted | Reviewed
        public string Status { get; set; } = "Assigned";
        public string? TutorRemarks { get; set; }
        public string? SubmissionText { get; set; }
        public string? FilePath { get; set; }
    }
}