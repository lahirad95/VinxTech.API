using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace VinxTech.API.Models.Domain
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string firstNameEn { get; set; }
        public string lastNameEn { get; set; }
        public string firstNameAr { get; set; }
        public string lastNameAr { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public Int64 IdNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime IdExpiryDate { get; set; }
        public Boolean IsActive { get; set; }
        public int Branch { get; set; }
        public int CretedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Image { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }
    }
}
