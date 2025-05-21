using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Library.User.Management.Models;
using MailKit.Net.Smtp;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Library.User.Management.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguiration emailConfiguiration;

        public EmailService(EmailConfiguiration emailConfiguiration) => this.emailConfiguiration = emailConfiguiration;
        public void sendEmail(Message message)
        {
            var emailMessage = createEmailMessage(message);
            send(emailMessage);
        }

        private MimeMessage createEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", emailConfiguiration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private void send(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(emailConfiguiration.SmtpServer, emailConfiguiration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(emailConfiguiration.Username, emailConfiguiration.Password);
                client.Send(message);

            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
