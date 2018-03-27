using System;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Dtos
{
    public class BloodBankDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AvailableDays { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }
    }
}