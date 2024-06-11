using BloodDonationApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationApp
{
    public class DonorVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullAddress { get; set; }
        
    public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool EverDonatedBlood { get; set; }
    }
}
