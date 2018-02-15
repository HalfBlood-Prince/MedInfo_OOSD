using System;
using MedInfo_OOSD.Core.Domain.Interface;

namespace MedInfo_OOSD.Core.Domain
{
    public class Hospital : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string HospitalAddress { get; set; }

        public Speciality Speciality { get; set; }

        public short SpecialityId { get; set; }

        public bool DoesHaveEmergencyWard { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }


    }
}