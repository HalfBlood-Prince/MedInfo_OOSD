using System;
using System.Collections.Generic;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Models
{
    public class BankDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AvailableDays { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public CommentViewModel Comment { get; set; }

        public string ApiKey { get; set; }
    }
}