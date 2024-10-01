using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_Management_System
{
    public class Employee
    {
        public RepositryEmployee repo;
        private int ID;
        private string Name;
        public int _ID {  get; set; }
        public string _Name{  get; set; }
        public Employee() => 
            repo = RepositryEmployee.GetInstanceRepo();

        public void Add_Employee(string _name,int NewId)
          =>  repo._employees.Add(new Employee { _ID = NewId , _Name = _name }); 
        public void Remove_Employee(int _id) =>
            repo._employees.Remove(this.search_employee(_id));

        public Employee search_employee(int _id)
        {
            var emp = repo._employees;
            int l = 0, r = (emp.Count) - 1, mid;
            // Binary Search
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (emp[mid]._ID == _id)
                    return emp[mid];
                else if (emp[mid]._ID > _id)
                    r = mid - 1;
                else 
                    l = mid + 1;
            }
            return null;
        }
    }
}
