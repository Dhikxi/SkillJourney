using MailKit.Net.Smtp;
using MimeKit;

namespace MqubeSkill.Services
{
    public class EmailService
    {
        public async Task SendOtpEmail(string toEmail, string otp)
        {
            var email = new MimeMessage();

            email.From.Add(
                MailboxAddress.Parse("dhikxig@gmail.com"));

            email.To.Add(
                MailboxAddress.Parse(toEmail));

            email.Subject = "MQube OTP Verification";

            email.Body = new TextPart("plain")
            {
                Text = $"Your OTP is: {otp}"
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                "smtp.gmail.com",
                587,
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
    "dhikxig@gmail.com",
    "qqwy qwca ltoa dlic");

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}