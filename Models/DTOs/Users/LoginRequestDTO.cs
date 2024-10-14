using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
