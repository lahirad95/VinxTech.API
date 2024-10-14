using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs
{
    public class UsersRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
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
        //[MinLength(0, ErrorMessage = ("Invalid Role"))]
        //[MaxLength(2 ,ErrorMessage = ("Invalid Role"))]
        public int Role { get; set; }
      
        public DateTime? HireDate { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public long IdNumber { get; set; }
        public DateTime? IdExpiryDate { get; set; }
        [Required]
        public Int32 Breanch { get; set; }
    }
}
