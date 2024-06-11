using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using BloodDonationApp.Models;

namespace BloodDonationApp
{
    // EmailService.cs
    public class EmailService
    {
        private readonly EmailConfiguration _emailEntity;

        public EmailService(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailEntity = emailConfiguration.Value;
        }
            
        public void SendDonationRequestEmail(string recipientEmail)
        {
            using (var client = new SmtpClient(_emailEntity.SmtpHost, _emailEntity.SmtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailEntity.SmtpUsername, _emailEntity.SmtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress("zeeshan723182@gmail.com", "Zeeshan Ahmed"),
                    Subject = "Blood Donation Request",
                    Body = "Dear donor, we request your availability for blood donation. Thank you for your support."
                };

                message.To.Add(recipientEmail);

                client.Send(message);
                Console.WriteLine($"Email sent to: {recipientEmail} at {DateTime.Now}");
            }
        }
    }

}
