using System;
using System.Collections.Generic;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Models
{
    public class HospitalDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string HospitalAddress { get; set; }

        public Speciality Speciality { get; set; }

        public bool DoesHaveEmergencyWard { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public CommentViewModel Comment { get; set; }
    }
}