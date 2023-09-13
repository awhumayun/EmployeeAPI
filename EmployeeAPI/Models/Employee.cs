using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid EmpID { get; set; }

        public string EmpFname { get; set; }

        public string EmpLname { get; set; }

        public string Department { get; set; }

        public Guid ProjectId { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }
    }
}
