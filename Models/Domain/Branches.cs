using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.Domain
{
    public class Branches
    {//add extra lines
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string DescriptionEn { get; set; }
        [Required]
        public string DescriptionAr { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
