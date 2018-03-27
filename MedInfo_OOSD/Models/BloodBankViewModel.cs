using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MedInfo_OOSD.Models
{
    public class BloodBankViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Available Days")]
        public string AvailableDays { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }


        public string Title
        {
            get
            {
                return Name == null ? "New Bank" : "Edit Bank";
            }
    
        }
    }
}