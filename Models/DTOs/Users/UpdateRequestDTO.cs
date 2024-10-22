using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs.Users
{
    public class UpdateRequestDTO
    {
            public string firstNameEn { get; set; }
            public string lastNameEn { get; set; }
            public string firstNameAr { get; set; }
            public string lastNameAr { get; set; }
            public string Email { get; set; }
            public string MobileNumber { get; set; }
            public DateTime DOB { get; set; }
            public long IdNumber { get; set; }
            public DateTime? IdExpiryDate { get; set; }
            public Int32 Breanch { get; set; }
            public int Role { get; set; }
            public DateTime? HireDate { get; set; }
            public Boolean IsActive { get; set; }
        public string? Image { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
    }
}
