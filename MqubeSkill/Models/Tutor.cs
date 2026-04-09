using System.ComponentModel.DataAnnotations;
namespace MqubeSkill.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }
        public int UserId { get; set; }

        [Required]
        public string? Qualification { get; set; }
        public int ExperienceYears { get; set; }
        public int ExperienceMonths { get; set; }
        [Required]
        public string? Subjects { get; set; }
        public string? Availability { get; set; }
        public TimeOnly? AvailableStartTime { get; set; }
        public TimeOnly? AvailableEndTime { get; set; }
        public decimal FeePerHour { get; set; }

        // NEW FIELDS
        [Phone]
        [Required]
        public string? ContactNo { get; set; }
        public string? WhatsAppNo { get; set; }
        public string? SkypeId { get; set; }
        public string? Address { get; set; }

        [Required]
        public string? WorkingHours { get; set; } = "";// FullTime / PartTime
        public bool ReadyEarlyMorning { get; set; }
        public bool HighSpeedInternet { get; set; }
        public bool HasDigitalPen { get; set; }

        [Required]
        public string? ResumePath { get; set; }
        [Required]
        public string? IdentityProofPath { get; set; }

        [Required]
        public string? DegreePath { get; set; }

        [Required]
        public string? HearAboutUs { get; set; } = "";

        public bool IsApproved { get; set; }

        public User? User { get; set; }
        public string? QrImagePath { get; set; }
    }

}
