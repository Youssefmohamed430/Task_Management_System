using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class RepositryEmployee
    {
        public Employee employee;
        public RepositryEmployee() {
            employee = new Employee();
            employee._employees = new SortedDictionary<int, string>
            {
                {101, "Ahmed"},{102, "Sara"},{103, "John"},
                {104, "Laila"},{105, "Omar"},{106, "Mona"},
                {107, "Khaled"},{108, "Zainab"},{109, "Youssef"},
                {110, "Fatma"},{111, "Mahmoud"},{112, "Nour"},
                {113, "Ali"},{114, "Aisha"},{115, "Mustafa"},
                {116, "Salma"},{117, "Tamer"},{118, "Hassan"},
                {119, "Nadia"},{120, "Rami"}
            };
            employee._EmployeesTasks = new SortedDictionary<int, List<string>>();    
            employee._EmployeesProjects = new SortedDictionary<int, List<string>>();    
        }
        public SortedDictionary<int, string> LoadEmployees() => employee._employees;
        public SortedDictionary<int, List<string>> LoadEmployeesTasks() => employee._EmployeesTasks;
        public SortedDictionary<int, List<string>> LoadEmployeesProjects() => employee._EmployeesProjects;
    }
}
