using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Edu_Station.Helpers
{
    // Serviço para enviar e-mails
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        // Construtor que recebe a configuração necessária para enviar e-mails
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Método para enviar e-mails assíncronos
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                // Obtém as configurações SMTP do arquivo de configuração
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                // Cria uma nova mensagem de e-mail
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Edu Station", smtpSettings["Username"]));
                email.To.Add(new MailboxAddress("", toEmail)); // Adiciona o destinatário do e-mail
                email.Subject = subject; // Define o assunto do e-mail

                // Adiciona o corpo do e-mail
                email.Body = new TextPart("plain")
                {
                    Text = message
                };

                // Conecta-se ao servidor SMTP e envia o e-mail
                using (var client = new SmtpClient())
                {
                    client.Connect(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.SslOnConnect);
                    client.Authenticate(smtpSettings["Username"], smtpSettings["Password"], CancellationToken.None);
                    await client.SendAsync(email); // Envio assíncrono do e-mail
                    await client.DisconnectAsync(true); // Fecha a conexão com o servidor SMTP
                }

                return true; // Retorna true se o e-mail for enviado com sucesso
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro ao enviar o e-mail
            }
        }
    }
}
