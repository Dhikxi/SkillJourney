using Microsoft.EntityFrameworkCore;
using MqubeSkill.Data;
using MqubeSkill.Models;

namespace MqubeSkill.Services
{
    public class EnrollmentService
    {
        private readonly IDbContextFactory<MQubeDbContext> _contextFactory;

        public EnrollmentService(IDbContextFactory<MQubeDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateEnrollmentAsync(int studentId, int tutorId, int subjectId)
        {
            using var db = _contextFactory.CreateDbContext();

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                TutorId = tutorId,
                SubjectId = subjectId
            };

            db.Enrollments.Add(enrollment);
            await db.SaveChangesAsync();
        }
    }
}