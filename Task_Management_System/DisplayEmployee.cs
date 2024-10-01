using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal class DisplayEmployee : Display
    {
        public override void display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1.Info about Employees\n2.Add employee\n3.Remove Employee\n4.Search about employee");
            string op = Console.ReadLine();
            Console.Clear();
            if (op == "1")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t\t\t┌───────────────────────────────────────────────────────┐");
                Console.WriteLine("\t\t\t\t\t│              Info about Employee Tasks                │");
                Console.WriteLine("\t\t\t\t\t└───────────────────────────────────────────────────────┘");
                foreach (var i in emp.repo._employees)
                {
                    if (task.repo._tasks.ContainsKey(i._ID))
                        PrintWithTasks(i, task.repo._tasks);
                    else {
                        PrintWithoutTasks(i);
                    }
                }
            }
            else if (op == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Enter Employee Name : ");
                string name = Console.ReadLine();
                int newid = emp.repo._employees.Last()._ID;
                emp.Add_Employee(name,newid+1);
            }
            else if (op == "3")
            {
                Console.Write("Enter ID : ");
                int ch = Convert.ToInt32(Console.ReadLine());
                emp.Remove_Employee(ch);
            }
            else if (op == "4")
            {
                Console.Write("Enter ID : ");
                int ch = Convert.ToInt32(Console.ReadLine());
                var temp = emp.search_employee(ch);
                Console.Clear();
                if (temp != null)
                {
                    if (task.repo._tasks.ContainsKey(temp._ID))
                        PrintWithTasks(temp, task.repo._tasks);
                    else
                        PrintWithoutTasks(temp);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Founding\n");
                }
            }
            else Console.WriteLine("Invalid answer");
            AnotherOperation();
        }
        public void AnotherOperation()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you need any operations ? (yes/no)");
            string ans = Console.ReadLine();
            Ioptions opt = Ioptions.GetInstanceoption();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (ans.ToLower() == "yes")
            {
                Console.Clear();
                var obj = opt.Options();
                obj.display();
            }
            else Console.WriteLine("Thank You");
        }
        public void PrintWithoutTasks(Employee i)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Name : {i._Name} | ID : {i._ID}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t─────────────────────────────────────");
        }
        public void PrintWithTasks(Employee i,SortedDictionary<int,List<Task>>_task)
        {
            int numTask = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Name : {i._Name} | ID : {i._ID}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var T in _task[i._ID])
            {
                numTask++;
                T.no_task = numTask;
                 Console.ForegroundColor = ConsoleColor.White;
                 Console.WriteLine($"Task number : {T.no_task}" +
                       $"\nTask Title : {T._Title}" +
                       $"\nTask Description : {T._Description}");
                 Console.Write($"Task Status : ");
                if (T._status == Status.Completed)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (T._status == Status.NotStarted)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (T._status == Status.InProgress)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{T._status}");
                Console.ForegroundColor = ConsoleColor.White;
                  Console.WriteLine($"Task Create Date : {T._Created}");
                  Console.ForegroundColor = ConsoleColor.Blue;
                  Console.WriteLine("\t\t─────────────────────────────────────");
            }
             Console.ForegroundColor = ConsoleColor.Blue;
             Console.WriteLine("\t\t\t\t───────────────────────────────────────────────────────");
        }
    }
}
