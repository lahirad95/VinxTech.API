using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs
{
    public class userActivationRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public Boolean Status { get; set; }
    }
}
