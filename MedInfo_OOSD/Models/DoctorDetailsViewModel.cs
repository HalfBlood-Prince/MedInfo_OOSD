using System;
using System.Collections.Generic;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Models
{
    public class DoctorDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ChemberAddress { get; set; }

        public string AvailableDays { get; set; }

        public Speciality Speciality { get; set; }

        public short SpecialityId { get; set; }

        public CommentViewModel Comment { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public string ApiKey { get; set; }
    }
}