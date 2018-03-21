using System;
using MedInfo_OOSD.Core.Domain;

namespace MedInfo_OOSD.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public Guid RecordId { get; set; }

        public string PostComment { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime CommentDateTime { get; set; }
    }
}