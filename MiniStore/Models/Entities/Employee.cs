using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Models.Entities
{
    public class Employee : Person
    {
        public int? PermissionLevel { get; set; }
        public string? EmployeeJob { get; set; }
        public int? EmployeeSalary { get; set; }
    }
}
