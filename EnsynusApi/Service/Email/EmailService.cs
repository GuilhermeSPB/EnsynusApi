using System.Net;
using System.Net.Mail;
using EnsynusApi.Service.Email;


namespace EnsynusApi.Service.Auth
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {

            var smtp = new SmtpClient
            {
                Host = _config["Email:Smtp"],
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                
                    _config["Email:Username"],
                    _config["Email:Password"]
                )
            };

            var mail = new MailMessage(
                _config["Email:User"],
                to,
                subject,
                body
            );

            mail.IsBodyHtml = true;

            await smtp.SendMailAsync(mail);
        }
    }
}
