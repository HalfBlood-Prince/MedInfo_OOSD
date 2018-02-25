using System.ComponentModel.DataAnnotations;

namespace MedInfo_OOSD.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}