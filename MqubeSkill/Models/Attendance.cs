namespace MqubeSkill.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int ClassSessionId { get; set; }
        public ClassSession? ClassSession { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        // Present | Absent | Late
        public string Status { get; set; } = "Absent";
        public DateTime MarkedAt { get; set; } = DateTime.Now;
    }
}