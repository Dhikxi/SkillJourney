namespace MqubeSkill.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }

        public string Title { get; set; } = "";
        public int MarksObtained { get; set; }
        public int TotalMarks { get; set; }
        public string? Remarks { get; set; }
        public DateTime TakenAt { get; set; } = DateTime.Now;
    }
}