﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    internal class Program
    {
        static void Main()
        {
            Employee employee = new Employee();
            Task tasks =new Task();
            employee.repo.LoadEmployees();
            tasks.repo.LoadTasks();
            tasks.repo.IncreaseNumberOfTask();
            Ioptions options = Ioptions.GetInstanceoption();
            var opt = options.Options();
            opt.display();
        }
    }
}
