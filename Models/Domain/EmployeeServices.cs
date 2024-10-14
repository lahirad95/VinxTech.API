using System.ComponentModel.DataAnnotations;

namespace VinxTech.API.Models.Domain
{
    public class EmployeeServices
    {
        [Key]
        public Guid Id { get; set; }
        public Int64 EmployeeId { get; set; }
        public int ServiceID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
