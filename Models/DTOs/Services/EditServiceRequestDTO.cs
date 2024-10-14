using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs.Services
{
    public class EditServiceRequestDTO
    {
        [Required]
        public string ServiceNameEn { get; set; }
        [Required]
        public string ServiceNameAr { get; set; }
        [Required]
        public string ServiceDescriptionEn { get; set; }
        [Required]
        public string ServiceDescriptionAr { get; set; }
    }
}
