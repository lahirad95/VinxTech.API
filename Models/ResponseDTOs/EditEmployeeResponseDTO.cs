using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace VinxTech.API.Models.ResponseDTOs
{
    public class EditEmployeeResponseDTO
    {
       
        public string firstNameEn { get; set; }
        public string lastNameEn { get; set; }
        public string firstNameAr { get; set; }
        public string lastNameAr { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public Int64 IdNumber { get; set; }

        public DateTime? HireDate { get; set; }
        public DateTime? IdExpiryDate { get; set; }
        public Boolean IsActive { get; set; }
        public List<Branch> Branch { get; set; }
        public int CretedBy { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public List<Service> Services { get; set; }
    }

    public class Service
    {
        public int Id { get; set; }
        public string ServiceNameEn { get; set; }
        public string ServiceNameAr { get; set; }
        public string ServiceDescriptionEn { get; set; }
        public string ServiceDescriptionAr { get; set; }

    }

    public class Branch
    {

        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public int Id { get; set; }
    }
}
