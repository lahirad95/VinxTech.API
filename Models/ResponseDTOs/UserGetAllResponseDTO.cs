using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.ResponseDTOs
{
    public class UserGetAllResponseDTO
    {
        public string Username { get; set; }
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
        //public int Role { get; set; }
        public DateTime? HireDate { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public string CretedBy { get; set; }
        public string? Image { get; set; }
        public string BreanchAr { get; set; }
        public string BreanchEn { get; set; }
        //public Int32 BreanchId { get; set; }
        public string BreanchDescriptionEn{ get; set; }
        public string BreanchDescriptionAr { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public Int32 RoleId { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
    }
}
