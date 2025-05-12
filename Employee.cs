using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public string Role { get; set; }
        public string ProjectName { get; set; }
    }
}
