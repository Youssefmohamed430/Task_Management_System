using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal  class Display : Ioptions
    {
        protected Employee emp;
        protected Task task;
        public Display()
        {
            emp = new Employee();
            task = new Task();
        }
        public void Options()
        {
            Console.WriteLine("Enter Your Options : ");
            Console.WriteLine("1.Employee Department|| 2.Tasks Department");
            string op = Console.ReadLine();
            if (op == "1")
            {
                empl.display();
            }
            //else if (op == "2")
            //{
            //}
            else Console.WriteLine("Invalid Answer");
        }
    }
}
