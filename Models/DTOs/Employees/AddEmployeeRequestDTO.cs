using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace VinxTech.API.Models.DTOs.Employees
{
    public class AddEmployeeRequestDTO
    {

        [Required]
        public string firstNameEn { get; set; }
        [Required]
        public string lastNameEn { get; set; }
        [Required]
        public string firstNameAr { get; set; }
        [Required]
        public string lastNameAr { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public Int64 IdNumber { get; set; }
     
        public DateTime? HireDate { get; set; }
        [Required]
        public DateTime IdExpiryDate { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
        [Required]
        public int Branch { get; set; }
        [Required]
        public int CretedBy { get; set; }

        public string? Image { get; set; }
        public List<Int32> Services { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }

    }
}


