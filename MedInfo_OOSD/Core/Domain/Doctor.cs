using System;
using MedInfo_OOSD.Core.Domain.Interface;

namespace MedInfo_OOSD.Core.Domain
{
    public class Doctor : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ChemberAddress { get; set; }

        public string AvailableDays { get; set; }

        public Speciality Speciality { get; set; }

        public short SpecialityId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}