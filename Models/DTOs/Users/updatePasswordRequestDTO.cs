using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs
{
    public class updatePasswordRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
