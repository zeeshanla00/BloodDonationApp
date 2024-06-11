using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BloodDonationApp.Models
{
    public class EmailConfiguration
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
