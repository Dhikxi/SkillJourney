using System.ComponentModel.DataAnnotations;

namespace MqubeSkill.Models
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }

        public int SenderUserId { get; set; }
        public User? Sender { get; set; }

        [Required]
        public string Content { get; set; } = "";

        // Text | ClassLink | Homework | Assessment
        public string MessageType { get; set; } = "Text";

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}