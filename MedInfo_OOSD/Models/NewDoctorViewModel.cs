using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Models
{
    public class NewDoctorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string ChemberAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string AvailableDays { get; set; }

        [Display(Name = "Speciality")]
        public short SpecialityId { get; set; }


        public IEnumerable<Speciality> Specialities { get; set; }


        public string Title
        {
            get
            {
                return Name == null ? "New Doctor" : "Edit Doctor";
            }
        }
    }
}