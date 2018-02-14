using System;

namespace MedInfo_OOSD.Core.Domain
{
    public class Comment
    {
        public int Id { get; set; }

        public Guid RecordId { get; set; }

        public string PostComment { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime CommentDateTime { get; set; }
    }
}