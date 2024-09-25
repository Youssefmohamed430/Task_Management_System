using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal class Ioptions 
     // Apply Dependency Inversion Principle
    {
        protected DisplayEmployee empl;
        public Ioptions()
        {
            empl = new DisplayEmployee();
        }
    }
}
