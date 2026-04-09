using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MqubeSkill.Models
{
    public class DemoBooking
    {
        [Key]
        [Column("DemoId")]
        public int DemoBookingId { get; set; }

        public int StudentId { get; set; }
        public int TutorId { get; set; }

        public int SubjectId { get; set; }
        public string? Subject { get; set; }

        public Student? Student { get; set; }
        public Tutor? Tutor { get; set; }

        public string Status { get; set; } = "Pending";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime BookingDate { get; set; }

        public string? DemoLink { get; set; }
        public string? StudentDecision { get; set; }
        public string? SelectedSlot { get; set; }
        public string? SelectedSlot2 { get; set; }
        public int RequestGroupId { get; set; }   // NEW
    }
}