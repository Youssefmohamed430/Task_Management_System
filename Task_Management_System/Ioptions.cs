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
        private Ioptions()
        {
            empl = new DisplayEmployee();
        }
        public static Ioptions InstanceOption = null;
        public static Ioptions GetInstanceoption()
        {
            if(InstanceOption == null)
                InstanceOption = new Ioptions();
            return InstanceOption;
        }
        public Display Options()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter Your Options : ");
                Console.WriteLine("1.Employee Management || 2.Tasks Management");
                string op = Console.ReadLine();
                if (op == "1")
                {
                    return new DisplayEmployee();
                }
                else if (op == "2")
                {
                    return new DisplayTask();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[{op}] Invalid Answer");
                    Console.WriteLine("\nPress Enter key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
