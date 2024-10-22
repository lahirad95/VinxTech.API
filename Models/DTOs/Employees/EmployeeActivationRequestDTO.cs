using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.DTOs.Employees
{
    public class EmployeeActivationRequestDTO
    {
            [Required]
            public long IdNumber { get; set; }
            [Required]
            public Boolean Status { get; set; }
    }
}
