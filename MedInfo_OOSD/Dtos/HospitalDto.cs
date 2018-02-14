using System;

namespace MedInfo_OOSD.Dtos
{
    public class HospitalDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string HospitalAddress { get; set; }

        public SpecialityDto Speciality { get; set; }

        public short SpecialityId { get; set; }

        public bool DoesHaveEmergencyWard { get; set; }
    }
}