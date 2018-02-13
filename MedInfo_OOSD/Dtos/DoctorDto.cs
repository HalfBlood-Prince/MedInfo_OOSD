using System;

namespace MedInfo_OOSD.Dtos
{
    public class DoctorDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ChemberAddress { get; set; }

        public string AvailableDays { get; set; }

        public short SpecialityId { get; set; }

        public string ApplicationUserId { get; set; }
    }
}