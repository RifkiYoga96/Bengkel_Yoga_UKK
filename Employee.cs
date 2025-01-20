using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public static class DataSource
    {
        public static BindingList<Employee> Employees { get; set; } = new BindingList<Employee>
    {
        new Employee { ID = 1, Name = "John Doe", Department = "IT" },
        new Employee { ID = 2, Name = "Jane Smith", Department = "HR" }
    };
    }
}
