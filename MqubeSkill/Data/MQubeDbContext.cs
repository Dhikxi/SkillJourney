using Microsoft.EntityFrameworkCore;
using MqubeSkill.Models;

namespace MqubeSkill.Data
{
    public class MQubeDbContext : DbContext
    {
        public MQubeDbContext(DbContextOptions<MQubeDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<TutorSubject> TutorSubjects { get; set; }
        public DbSet<DemoBooking> DemoBookings { get; set; }

        public DbSet<TutorRequest> TutorRequests { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ClassSession> ClassSessions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
    }
}
