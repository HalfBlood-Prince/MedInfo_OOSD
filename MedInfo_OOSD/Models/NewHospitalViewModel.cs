using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Models
{
    public class NewHospitalViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Hospital Address")]
        public string HospitalAddress { get; set; }

        [Required]
        [Display(Name = "Speciality")]
        public short SpecialityId { get; set; }

        [Required]
        public bool DoesHaveEmergencyWard { get; set; }

        public IEnumerable<Speciality> Specialities { get; set; }

        public Speciality Speciality { get; set; }


        public string Title
        {
            get
            {
                return Name == null ? "New Hospital" : "Edit Hospital";
            }
        }

    }
}