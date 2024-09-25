using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class RepositryTasks
    {
        private SortedDictionary<int, List<Task>> tasks;
        public SortedDictionary<int, List<Task>> _tasks { get; set; }
        public SortedDictionary<int, List<Task>> LoadTasks()
            => tasks = new SortedDictionary<int, List<Task>>
            {
                { 101 , new List<Task> { new Task { _Title = "Complete Report", _Description = "Prepare the monthly sales report", _status = Status.InProgress } } },
                { 102 , new List<Task> { new Task { _Title = "Client Meeting", _Description = "Attend the meeting with the client to discuss project requirements", _status = Status.NotStarted } } },
                { 103 , new List<Task> { new Task { _Title = "Code Review", _Description = "Review the codebase for optimization opportunities", _status = Status.Completed } } },
                { 104 , new List<Task> { new Task { _Title = "Design Prototype", _Description = "Create a prototype for the new website design", _status = Status.InProgress } } },
                { 105 , new List<Task> { new Task { _Title = "Database Backup", _Description = "Perform a full backup of the company database", _status = Status.Completed } } },
            };
    }
}
