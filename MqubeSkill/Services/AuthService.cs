using MqubeSkill.Data;
using MqubeSkill.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace MqubeSkill.Services
{
    public class AuthService
    {
        public static int LoggedInUserId;
        private readonly IDbContextFactory<MQubeDbContext> _contextFactory;

        public AuthService(IDbContextFactory<MQubeDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> Register(User user)
        {
            using var context = _contextFactory.CreateDbContext();
            user.PasswordHash = HashPassword(user.Password!);
            user.Password = null;
            user.CreatedAt = DateTime.Now;

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Login(string email, string password)
        {
            using var context = _contextFactory.CreateDbContext();
            var hashed = HashPassword(password);

            email = email.Trim();

            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == hashed);

            if (user != null)
            {
                LoggedInUserId = user.UserId;
            }

            return user;
        }

        private string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password cannot be empty.");

            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public void Logout()
        {
            LoggedInUserId = 0;
        }
    }
}