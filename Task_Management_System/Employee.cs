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

        public Employee() => repo = new RepositryEmployee();   

        public void Add_Employee(string _name, int _id) => repo._employees.Add(new Employee { _ID = _id , _Name = _name});
        public void Remove_Employee(int _id) => repo._employees.Remove(this.search_employee(_id));

        public Employee search_employee(int _id)
        {
            RepositryEmployee repo = new RepositryEmployee();
            // linq =>  select
            var emp = repo._employees;
            int l = 0, r = (emp.Count) - 1, mid;
            // Binary Search
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (emp[mid].ID == _id)
                    return emp[mid];
                else if (emp[mid].ID > _id)
                    r = mid - 1;
                else 
                    l = mid + 1;
            }
            throw new Exception($"This employee {_id} is not found");
        }
    }
}
