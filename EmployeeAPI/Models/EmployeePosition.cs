using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class EmployeePosition
    {
        [Key]
        public Guid EmpID { get; set; }

        public string EmpPosition { get; set; }

        public DateTime DateOfJoining { get; set; }

        public decimal Salary { get; set; }
    }
}
