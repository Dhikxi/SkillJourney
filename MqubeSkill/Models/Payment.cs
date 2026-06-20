using System;

namespace MqubeSkill.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int TutorId { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public string? ScreenshotPath { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public decimal Amount { get; set; }
    }
}