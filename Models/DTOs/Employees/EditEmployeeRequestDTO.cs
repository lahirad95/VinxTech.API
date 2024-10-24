using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs.Employees
{
    public class EditEmployeeRequestDTO
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
        public DateTime? HireDate { get; set; }
      
        public DateTime? IdExpiryDate { get; set; }
        //[Required]
        //public Boolean IsActive { get; set; }
        [Required]
        public int Branch { get; set; }
        [Required]
        public int CretedBy { get; set; }
        public List<Int32> Services { get; set; }
        public string? Image { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
    }
}
