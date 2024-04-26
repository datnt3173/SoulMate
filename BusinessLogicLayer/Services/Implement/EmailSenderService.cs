using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BusinessLogicLayer.Services.Implement
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly MailSettings mailSettings;

        private readonly ILogger<EmailSenderService> logger;
        public EmailSenderService(IOptions<MailSettings> _mailSettings, ILogger<EmailSenderService> _logger)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Create SendMailService");
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;


            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(message);
            }

            catch (Exception ex)
            {
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
            }

            smtp.Disconnect(true);

            logger.LogInformation("send mail to " + email);
        }

        public Task SendSmsAsync(string number, string message)
        {
            System.IO.Directory.CreateDirectory("smssave");
            var emailsavefile = string.Format(@"smssave/{0}-{1}.txt", number, Guid.NewGuid());
            System.IO.File.WriteAllTextAsync(emailsavefile, message);
            return Task.FromResult(0);
        }
    }
}
