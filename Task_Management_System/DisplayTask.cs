﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal class DisplayTask : Display
    {
        public override void display()
        {
            bool continueOperations = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1.Assign Task To Employee\n" +
                "2.Remove Task From Employee\n" +
                "3.Update Task Status \n" +
                "4.Exit");
            string op = Console.ReadLine();
            int iD,NoTask;
            bool y;
            switch (op)
            {
                case "1" :
                    Console.Write("Enter ID : ");
                    iD = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Titel Of Task : ");
                    string TiTle = Console.ReadLine();
                    Console.Write("Enter Description Of Task : ");
                    string Descrip = Console.ReadLine();
                    base.task.Assign_Task(iD, TiTle, Descrip);
                    break;
                case "2" :
                    Console.Write("Enter ID : ");
                    iD = Convert.ToInt32(Console.ReadLine());
                    y = base.task.HasTask(iD);
                    if (!y)
                    {
                        Console.WriteLine("\nThis Employee has not any tasks\n");
                        break;
                    }
                    PrintTasks(base.emp.search_employee(iD));
                    Console.Write("Enter Number of Task : ");
                    NoTask = Convert.ToInt32(Console.ReadLine());
                    y = base.task.IsValid(iD,NoTask);
                    if (y)
                        base.task.Remove_Task(iD, NoTask - 1);
                    else
                    {
                        Console.WriteLine("\nInvalid Answer\n");
                        break;
                    }
                    break;
                case "3":
                    Console.Write("Enter ID : ");
                    iD = Convert.ToInt32(Console.ReadLine());
                    y = base.task.HasTask(iD);
                    if (!y)
                    {
                        Console.WriteLine("\nThis Employee has not any tasks\n");
                        break;
                    }
                    PrintTasks(base.emp.search_employee(iD));
                    Console.Write("Enter Number of Task : ");
                    NoTask = Convert.ToInt32(Console.ReadLine());
                    y = base.task.IsValid(iD, NoTask);
                    if (!y)
                    {
                        Console.WriteLine("\nInvalid Answer\n");
                        break;
                    }
                    StatusExtensions.DisplayStatusOptions();
                    Status x = StatusExtensions.ReadStatus();
                    base.task.UpdateTaskStatus(iD, NoTask-1,x);
                    break;
                case "4":
                continueOperations = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nExiting Employee Management. Thank you!\n");
                return;
            }
            if (continueOperations)
            {
                Console.WriteLine("\nPress Enter key to continue...");
                Console.ReadKey();
                var temp =  Ioptions.InstanceOption.Options();
                temp.display();
            }
        }
        public void PrintTasks(Employee i)
        {
            int numTask = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Name : {i._Name} | ID : {i._ID}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var T in  base.task.repo._tasks[i._ID])
            {
                numTask++;
                T.no_task = numTask;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Task number : {T.no_task}" +
                      $"\nTask Title : {T._Title}" +
                      $"\nTask Description : {T._Description}");
                Console.Write($"Task Status : ");
                StatusExtensions.PrintColoredStatus(T._status);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nTask Create Date : {T._Created}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t─────────────────────────────────────");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t───────────────────────────────────────────────────────");
        }
    }
}
