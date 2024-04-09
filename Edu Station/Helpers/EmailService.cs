using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Edu_Station.Helpers
{    
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Edu Station", smtpSettings["Username"]));
                email.To.Add(new MailboxAddress("", toEmail));
                email.Subject = subject;

                email.Body = new TextPart("plain")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.SslOnConnect);
                    client.Authenticate(smtpSettings["Username"], smtpSettings["Password"], CancellationToken.None);
                    await client.SendAsync(email);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
