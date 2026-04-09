using Microsoft.EntityFrameworkCore;
using MqubeSkill.Data;
using MqubeSkill.Models;

namespace MqubeSkill.Services
{
    public class ChatService
    {
        private readonly IDbContextFactory<MQubeDbContext> _contextFactory;

        public ChatService(IDbContextFactory<MQubeDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<ChatMessage>> GetMessagesAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.ChatMessages
                .Include(m => m.Sender)
                .Where(m => m.EnrollmentId == enrollmentId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task SendMessageAsync(int enrollmentId, int senderUserId, string content, string messageType = "Text")
        {
            using var db = _contextFactory.CreateDbContext();
            var message = new ChatMessage
            {
                EnrollmentId = enrollmentId,
                SenderUserId = senderUserId,
                Content = content,
                MessageType = messageType,
                SentAt = DateTime.Now
            };
            db.ChatMessages.Add(message);
            await db.SaveChangesAsync();
        }

        public async Task<Enrollment?> GetEnrollmentAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Enrollments
                .Include(e => e.Student).ThenInclude(s => s!.User)
                .Include(e => e.Tutor).ThenInclude(t => t!.User)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId);
        }

        public async Task<List<Enrollment>> GetEnrollmentsForUserAsync(int userId, string role)
        {
            using var db = _contextFactory.CreateDbContext();
            if (role == "Tutor")
            {
                return await db.Enrollments
                    .Include(e => e.Student).ThenInclude(s => s!.User)
                    .Include(e => e.Subject)
                    .Where(e => e.Tutor!.UserId == userId && e.Status == "Active")
                    .ToListAsync();
            }
            else
            {
                return await db.Enrollments
                    .Include(e => e.Tutor).ThenInclude(t => t!.User)
                    .Include(e => e.Subject)
                    .Where(e => e.Student!.UserId == userId && e.Status == "Active")
                    .ToListAsync();
            }
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        // ── Attendance ──────────────────────────────
        public async Task<List<ClassSession>> GetSessionsAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.ClassSessions
                .Where(s => s.EnrollmentId == enrollmentId)
                .OrderByDescending(s => s.ScheduledAt)
                .ToListAsync();
        }

        public async Task CreateSessionAsync(int enrollmentId, string title, string? link, DateTime? date, int durationMinutes)
        {
            using var db = _contextFactory.CreateDbContext();

            db.ClassSessions.Add(new ClassSession
            {
                EnrollmentId = enrollmentId,
                Title = title,
                ClassLink = link,
                ScheduledAt = date ?? DateTime.Now, // ✅ FIXED
                DurationMinutes = durationMinutes,  // ✅ ADD THIS
                Status = "Upcoming",
                CreatedAt = DateTime.Now
            });

            await db.SaveChangesAsync();
        }
        public async Task MarkAttendanceAsync(int sessionId, int studentId, string status)
        {
            using var db = _contextFactory.CreateDbContext();
            var existing = await db.Attendances
                .FirstOrDefaultAsync(a => a.ClassSessionId == sessionId && a.StudentId == studentId);
            if (existing != null)
            {
                existing.Status = status;
            }
            else
            {
                db.Attendances.Add(new Attendance
                {
                    ClassSessionId = sessionId,
                    StudentId = studentId,
                    Status = status,
                    MarkedAt = DateTime.Now
                });
            }
            await db.SaveChangesAsync();
        }

        public async Task<List<Attendance>> GetAttendancesAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            var sessions = await db.ClassSessions
                .Where(s => s.EnrollmentId == enrollmentId)
                .Select(s => s.ClassSessionId)
                .ToListAsync();
            return await db.Attendances
                .Include(a => a.ClassSession)
                .Where(a => sessions.Contains(a.ClassSessionId))
                .OrderByDescending(a => a.ClassSession!.ScheduledAt)
                .ToListAsync();
        }

        public async Task CompleteSessionAsync(int sessionId)
        {
            using var db = _contextFactory.CreateDbContext();
            var session = await db.ClassSessions.FindAsync(sessionId);

            if (session != null)
            {
                session.Status = "Completed";

                // ✅ NEW: check if attendance already exists
                var existingAttendance = await db.Attendances
                    .FirstOrDefaultAsync(a => a.ClassSessionId == sessionId);

                if (existingAttendance == null)
                {
                    // get student from enrollment
                    var enrollment = await db.Enrollments
                        .FirstOrDefaultAsync(e => e.EnrollmentId == session.EnrollmentId);

                    if (enrollment != null)
                    {
                        db.Attendances.Add(new Attendance
                        {
                            ClassSessionId = sessionId,
                            StudentId = enrollment.StudentId,
                            Status = "Absent",
                            MarkedAt = DateTime.Now
                        });
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        // ── Homework ─────────────────────────────────
        public async Task<List<Homework>> GetHomeworksAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Homeworks
                .Where(h => h.EnrollmentId == enrollmentId)
                .OrderByDescending(h => h.AssignedAt)
                .ToListAsync();
        }

        public async Task AssignHomeworkAsync(int enrollmentId, string title, string? description, DateTime? dueDate)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Homeworks.Add(new Homework
            {
                EnrollmentId = enrollmentId,
                Title = title,
                Description = description,
                AssignedAt = DateTime.Now,
                DueDate = dueDate,
                Status = "Assigned"
            });
            await db.SaveChangesAsync();
        }

        public async Task UpdateHomeworkStatusAsync(int homeworkId, string status, string? remarks = null)
        {
            using var db = _contextFactory.CreateDbContext();
            var hw = await db.Homeworks.FindAsync(homeworkId);
            if (hw != null)
            {
                hw.Status = status;
                if (remarks != null) hw.TutorRemarks = remarks;
                await db.SaveChangesAsync();
            }
        }

        public async Task SubmitHomeworkAsync(int homeworkId, string submissionText, string filePath)
        {
            using var db = _contextFactory.CreateDbContext();

            var hw = await db.Homeworks.FindAsync(homeworkId);

            if (hw != null)
            {
                hw.Status = "Submitted";
                hw.SubmissionText = submissionText;
                hw.FilePath = filePath;

                await db.SaveChangesAsync();
            }
        }

        // ── Assessments ──────────────────────────────
        public async Task<List<Assessment>> GetAssessmentsAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Assessments
                .Where(a => a.EnrollmentId == enrollmentId)
                .OrderByDescending(a => a.TakenAt)
                .ToListAsync();
        }

        public async Task AddAssessmentAsync(int enrollmentId, string title, int marks, int total, string? remarks)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Assessments.Add(new Assessment
            {
                EnrollmentId = enrollmentId,
                Title = title,
                MarksObtained = marks,
                TotalMarks = total,
                Remarks = remarks,
                TakenAt = DateTime.Now
            });
            await db.SaveChangesAsync();
        }

        public async Task<int?> GetStudentIdByEnrollmentAsync(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();
            var enrollment = await db.Enrollments.FindAsync(enrollmentId);
            return enrollment?.StudentId;
        }

        public async Task AddSession(int enrollmentId)
        {
            using var db = _contextFactory.CreateDbContext();

            var session = new ClassSession
            {
                EnrollmentId = enrollmentId,
                Title = "Live Class",
                ScheduledAt = DateTime.Now.AddHours(1),
                DurationMinutes = 60,
                Status = "Upcoming",
                CreatedAt = DateTime.Now
            };

            db.ClassSessions.Add(session);
            await db.SaveChangesAsync();
        }
    }
}
