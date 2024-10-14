using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.Domain
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ServiceNameEn { get; set; }
        [Required]
        public string ServiceNameAr { get; set; }
        [Required]
        public string ServiceDescriptionEn { get; set; }
        [Required]
        public string ServiceDescriptionAr { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
