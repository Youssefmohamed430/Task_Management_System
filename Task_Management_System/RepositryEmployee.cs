using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_Management_System
{
    public class RepositryEmployee
    {
        private List<Employee> employees;
        public List<Employee> _employees { get; set; }
        public List<Employee> LoadEmployees() => _employees = new List<Employee>
        {
            new Employee{_ID = 101, _Name = "Ahmed"},
            new Employee{_ID = 102, _Name = "Sara"},
            new Employee{_ID = 103, _Name = "John"},
            new Employee{_ID = 104, _Name = "Laila"},
            new Employee{_ID = 105, _Name = "Omar"},
            new Employee{_ID = 106, _Name = "Mona"},
            new Employee{_ID = 107, _Name = "Khaled"},
            new Employee{_ID = 108, _Name = "Zainab"},
            new Employee{_ID = 109, _Name = "Youssef"},
            new Employee{_ID = 110, _Name = "Fatma"}
        };

    }
}
