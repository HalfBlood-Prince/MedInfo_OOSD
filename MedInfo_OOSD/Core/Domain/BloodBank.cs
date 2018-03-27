using System;
using MedInfo_OOSD.Core.Domain.Interface;

namespace MedInfo_OOSD.Core.Domain
{
    public class BloodBank : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AvailableDays { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }
    }
}