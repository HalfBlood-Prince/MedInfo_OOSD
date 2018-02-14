using System;
using System.ComponentModel.DataAnnotations;

namespace MedInfo_OOSD.Models
{
    public class CommentViewModel
    {
        public Guid RecordId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Comment")]
        public string PostComment { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime CommentDateTime { get; set; }
    }
}