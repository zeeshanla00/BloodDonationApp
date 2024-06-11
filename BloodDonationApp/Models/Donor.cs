using BloodDonationApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationApp.Models
{
    public class Donor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Your first name must be between 2 and 20 characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Your first name must be between 2 and 20 characters")]
        public string LastName { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }


        [Required(ErrorMessage = "Zip Code is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code.")]
        public int ZipCode { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number.")]

        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Blood Group")]
        public BloodGroup BloodGroup { get; set; }


        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Have you ever donated blood before?")]
        public bool EverDonatedBlood { get; set; }


        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get { return $"{AddressLine1} {AddressLine2}"; }
        }

    }
}
