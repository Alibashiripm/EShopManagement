using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using RazorLight;
using System.Net.Mail;
 
namespace EShopManagement.Infrastructure.Services
{

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
 
        public EmailService(IConfiguration configuration )
        {
            _emailSettings = new EmailSettings();
            configuration.GetSection("EmailSettings").Bind(_emailSettings);
         }

        public async Task SendEmail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient(_emailSettings.SmtpServer);

            mail.From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtpServer.Port = _emailSettings.SmtpPort;
            smtpServer.Credentials = new System.Net.NetworkCredential(_emailSettings.Username, _emailSettings.Password);
            smtpServer.EnableSsl = _emailSettings.EnableSsl;

            smtpServer.Send(mail);
        }
    
    }
     
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
     
    }

}
