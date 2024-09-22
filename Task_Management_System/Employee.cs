using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class Employee
    {
        //-----------------------ID--Name------------------------                
        private SortedDictionary<int,string> employees;
        //-----------------------ID--List_of_tasks--------------                
        private SortedDictionary<int,List<string>> EmployeesTasks;
        //-----------------------ID--List_of_projects--------------                
        private SortedDictionary<int,List<string>> EmployeesProjects;
        public SortedDictionary<int, string> _employees {  get; set; }
        public SortedDictionary<int, List<string>> _EmployeesTasks {  get; set; } 
        public SortedDictionary<int, List<string>> _EmployeesProjects {  get; set; } 
        public void Add_Employee(string _name,int _id)
        {
            RepositryEmployee Repo = new RepositryEmployee();
            Repo.employee.employees.Add(_id, _name);
        }   
        public void Remove_Employee(int _id)
        {
            RepositryEmployee Repo = new RepositryEmployee();
            Repo.employee.employees.Remove(_id);
        }
        public void Search_Employee(int _id)
        {
            RepositryEmployee Repo = new RepositryEmployee();
             // LINQ =>  select
            var emp = Repo.LoadEmployees().Select(x => x.Key).ToList();
            int l = 0,r=(emp.Count())-1,mid;
            while(l <= r)
            {
                mid = (l + r) / 2;
                if (emp[mid] == _id) ; // Not Done
                
            }
        }
    }
}
