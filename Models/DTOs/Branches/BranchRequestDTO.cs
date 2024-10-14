using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs
{
    public class BranchRequestDTO
    {

        [Required]
        public string NameEn { get; set; }

        [Required]
        public string NameAr { get; set; }

        [Required]
        public string DescriptionEn { get; set; }

        [Required]
        public string DescriptionAr { get; set; }

    }
}
