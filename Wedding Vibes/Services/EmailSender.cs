using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding_Vibes.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, IConfiguration config)
        {
            Options = optionsAccessor.Value;
            this.configuration = config;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //return Task.CompletedTask;
            return Execute(Options.SendGridKey, subject, message, email);
        }
       public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            apiKey = configuration.GetConnectionString("SendGridKey");
            var client = new SendGridClient(apiKey);
            //var client = new SendGridClient();
            var from = new EmailAddress("Support@WeddingVibes.com", "Wedding Vibes");
            var to = new EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return client.SendEmailAsync(msg);

        }
    }
}
