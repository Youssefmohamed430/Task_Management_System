using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public abstract class Display
    {
        protected Employee emp;
        protected Task task;
        public Display()
        {
            emp = new Employee();
            task = new Task();
        }
        public abstract void display();
    }
}
