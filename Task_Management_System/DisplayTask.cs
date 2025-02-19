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
                "4.Filter Tasks Status\n" +
                "5.Replace Task\n" +
                "6.Search Task\n" +
                "7.Exit");
            string op = Console.ReadLine();
            string TiTle = "", Descrip= "";
            int iD = 0,NoTask = 0;
            bool y,Continue;
            switch (op)
            {
                case "1" :
                    Continue = true;
                    Console.Clear();
                    while (Continue)
                    { 
                        Console.Write("Enter ID : ");
                        try { iD = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIs Not Valid\n");
                            continue;
                        }
                        y = base.task.IsThere(iD);
                        if (!y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis Employee is not There\n");
                        }
                        else Continue = false;
                    }
                    Continue = true;
                    while (Continue)
                    {
                        Console.Write("Enter Titel Of Task : ");
                        TiTle = Console.ReadLine();
                        y = base.task.IsStringValid(TiTle);
                        if (y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis is Invalid Title\n");
                        }
                        else Continue = false;  
                    }
                    Continue = true;
                    while (Continue)
                    {
                        Console.Write("Enter Description Of Task : ");
                        Descrip = Console.ReadLine();
                        y = base.task.IsStringValid(Descrip);
                        if (y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis is Invalid Description\n");
                            break;
                        }
                        else Continue = false;
                    }
                    base.task.Assign_Task(iD, TiTle, Descrip);
                    break;
                case "2" :
                    Console.Clear();
                    Console.Write("Enter ID : ");
                    try { iD = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIs Not Valid\n" +
                            "\nPress Enter key to continue...");
                        Console.ReadKey();
                        display();
                    }
                    y = base.task.IsThere(iD);
                    if (!y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis Employee is not There\n");
                        break;
                    }
                    y = base.task.HasTask(iD);
                    if (!y)
                    {
                        Console.WriteLine("\nThis Employee has not any tasks\n");
                        break;
                    }
                    PrintTasks(base.emp.search_employee(iD));
                    Console.Write("Enter Number of Task : ");
                    try { NoTask = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIs Not Valid\n" +
                            "\nPress Enter key to continue...");
                        Console.ReadKey();
                        display();
                    }
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
                    Console.Clear();
                    Console.Write("Enter ID : ");
                    try { iD = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIs Not Valid\n" +
                            "\nPress Enter key to continue...");
                        Console.ReadKey();
                        display();
                    }
                    y = base.task.IsThere(iD);
                    if (!y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis Employee is not There\n");
                        break;
                    }
                    y = base.task.HasTask(iD);
                    if (!y)
                    {
                        Console.WriteLine("\nThis Employee has not any tasks\n");
                        break;
                    }
                    PrintTasks(base.emp.search_employee(iD));
                    Console.Write("Enter Number of Task : ");
                    try { NoTask = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIs Not Valid\n" +
                            "\nPress Enter key to continue...");
                        Console.ReadKey();
                        display();
                    }
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
                    Console.Clear();
                    var Groups = base.task.FilterStatus();
                    foreach (var Group in Groups) {
                        string key = Group.Key.ToString();
                        PrintFormat(key);
                        foreach (var item in Group) {
                            var emp1 = base.task.ReturnEmp(item);
                            PrintTasks(emp1,item);
                        }
                    }
                    break;
                case "5":
                    Console.Clear();
                    Continue = true;
                    int id1=0, id2=0;
                    while(Continue)
                    {
                        Console.WriteLine("Enter ID To first Employee : ");
                        try { id1 = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIs Not Valid\n");
                            continue;
                        }
                        y = base.task.IsThere(id1);
                        if (!y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis Employee is not There\n");
                            continue ;
                        }
                        y = base.task.HasTask(id1);
                        if(!y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis Employee has not any tasks\n");
                        }
                        else Continue = false;
                    } 
                    Continue = true;
                    while(Continue)
                    {
                        Console.WriteLine("Enter ID To Second Employee : ");
                        try { id2 = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIs Not Valid\n");
                            continue;
                        }
                        y = base.task.IsThere(id2);
                        if (!y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis Employee is not There\n");
                        }
                        else Continue = false;
                    } 
                    Continue = true;
                    while(Continue)
                    {
                        PrintTasks(base.emp.search_employee(id1));
                        Console.WriteLine("Enter Number Of Task : ");
                        try { NoTask = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIs Not Valid\n");
                            continue;
                        }
                        y = base.task.IsValid(id1,NoTask);
                        if (!y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Answer\n");
                        }
                        else Continue = false;
                    }
                    base.task.ReplaceTask(id1, id2, NoTask-1);
                    break;
                case "6":
                    Console.Clear();
                    Continue = true;
                    Task temptask = null;
                    while (Continue)
                    {
                        Console.WriteLine("Enter Title Of Task : ");
                        TiTle = Console.ReadLine();
                        temptask = base.task.SearchTask(TiTle);
                        if (temptask == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThis Task Is Not There\n");
                        }
                        else Continue = false;
                    }
                    var emp2 = base.task.ReturnEmp(temptask);
                    Console.Clear();
                    PrintTasks(emp2,temptask);
                    break;
                case "7":
                    Console.Clear();
                    continueOperations = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting Employee Management. Thank you!\n");
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[{op}] Invalid answer");
                    Console.WriteLine("\nPress Enter key to continue...");
                    Console.ReadKey();
                    display();
                    break;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Name : {i._Name} | ID : {i._ID}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var T in  base.task.repo._tasks[i._ID])
            {
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
        public void PrintTasks(Employee i,Task T)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Name : {i._Name} | ID : {i._ID}");
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
        public void PrintFormat(string key)
        {
            int boxWidth = Math.Max(40, key.Length + 10);
            int padding = (boxWidth - key.Length) / 2;
            string formattedKey = key.PadLeft(key.Length + padding).PadRight(boxWidth);
            Console.WriteLine($"\t\t\t\t\t┌{new string('─', boxWidth)}┐");
            Console.WriteLine($"\t\t\t\t\t│{formattedKey}│");
            Console.WriteLine($"\t\t\t\t\t└{new string('─', boxWidth)}┘");
        }
    }
}