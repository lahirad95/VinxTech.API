using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.Domain
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string firstNameEn { get; set; }
        public string lastNameEn { get; set; }
        public string firstNameAr { get; set; }
        public string lastNameAr { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public long IdNumber { get; set; }
        public DateTime? IdExpiryDate { get; set; }
        public Int32 Breanch {  get; set; } 
        public int Role { get; set; }
        public DateTime? HireDate { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public string CretedBy { get; set; }
        public DateTime CreatedAt  {  get; set; }
        public DateTime UpdatedAt {  get; set; }
        
    }
}
