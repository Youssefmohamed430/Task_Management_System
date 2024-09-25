using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal class DisplayEmployee : Display
    {
        public void display()
        {
            Console.Clear();    
            Console.WriteLine("1.Info about Employees\n2.Add employee\n3.Remove Employee\n3.Search about employee");
            string op = Console.ReadLine();
            if (op == "1")
            {
                var _emp = emp.repo.LoadEmployees();
                var _task = task.repo.LoadTasks();
                var JoinData = _emp.Join(_task,
                e => e._ID,ta => ta.Key
                ,(e , ta) => new
                {
                    Name = e._Name,
                    list = ta.Value
                });
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("┌───────────────────────────────────────────────────────┐");
                Console.WriteLine("│                   Info about Employee                 │");
                Console.WriteLine("└───────────────────────────────────────────────────────┘");
                foreach (var i in JoinData)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Name : {i.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var j in i.list)
                    {
                        Console.WriteLine($"Task number : {j.no_task}");
                        Console.WriteLine($"Task Title : {j._Title}" +
                            $"Task Description : {j._Description}" +
                            $"Task Status : {j._status}" +
                            $"Task Create Date : {j._Created}");
                        Console.WriteLine("\t\t─────────────────────────────────────");
                    }
                    Console.WriteLine("───────────────────────────────────────────────────────");
                }
            }
        }
    }
}
