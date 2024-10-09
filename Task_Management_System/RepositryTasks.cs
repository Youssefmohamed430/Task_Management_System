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
        public Employee Employees { get; set; }
        private RepositryTasks() { }
        private static RepositryTasks TaskInstance = null;
        public static RepositryTasks GetInstanceRepoTask()
        {
            if (TaskInstance == null)
                TaskInstance = new RepositryTasks();
            return TaskInstance;
        }
        public SortedDictionary<int, List<Task>> LoadTasks()
            => _tasks = new SortedDictionary<int, List<Task>>
            {
                { 101 , new List<Task> { new Task { _Title = "Customer Feedback", _Description = "Analyze customer feedback for product improvements", _status = Status.Completed } } },
                { 102 , new List<Task> { new Task { _Title = "Client Meeting", _Description = "Attend the meeting with the client to discuss project requirements", _status = Status.NotStarted } , new Task { _Title = "API Integration", _Description = "Integrate the new payment API into the system", _status = Status.InProgress } } },
                { 103 , new List<Task> { new Task { _Title = "Code Review", _Description = "Review the codebase for optimization opportunities", _status = Status.Completed } , new Task { _Title = "Research Competitors", _Description = "Conduct research on competitors' products and strategies", _status = Status.NotStarted } } },
                { 104 , new List<Task> { new Task { _Title = "Design Prototype", _Description = "Create a prototype for the new website design", _status = Status.InProgress } , new Task { _Title = "Content Creation", _Description = "Create content for the new marketing campaign", _status = Status.InProgress } , new Task { _Title = "Complete Report", _Description = "Prepare the monthly sales report", _status = Status.InProgress } } },
                { 106 , new List<Task> { new Task { _Title = "Test New Features", _Description = "Test the new features of the application for bugs", _status = Status.NotStarted }, new Task { _Title = "HR Policies Review", _Description = "Review the company's HR policies for updates", _status = Status.OnHold } } },
                { 109 , new List<Task> { new Task { _Title = "Security Audit", _Description = "Conduct a security audit for the server infrastructure", _status = Status.InProgress }, new Task { _Title = "Prepare Budget", _Description = "Prepare the budget proposal for the next quarter", _status = Status.NotStarted } } },
                { 110 , new List<Task> { new Task { _Title = "Deploy Update", _Description = "Deploy the latest update to the production environment", _status = Status.NotStarted }, new Task { _Title = "Launch Event Planning", _Description = "Plan the launch event for the new product release", _status = Status.OnHold } } },
                { 111 , new List<Task> { new Task { _Title = "Complete Report", _Description = "Prepare the monthly sales report", _status = Status.InProgress } } },
                { 115 , new List<Task> { new Task { _Title = "Fix UI Bugs", _Description = "Resolve reported issues in the user interface", _status = Status.Completed }, new Task { _Title = "User Testing", _Description = "Conduct user testing for the new mobile app", _status = Status.InProgress }  } },
                { 117 , new List<Task> { new Task { _Title = "Sort Numbers", _Description = "Sort Numbers With Methods", _status = Status.Completed } } },
                { 119 , new List<Task> { new Task { _Title = "SEO Optimization", _Description = "Optimize the company website for search engines", _status = Status.Completed } } },
            };
        public void IncreaseNumberOfTask()
        {
            Employees = new Employee();
            foreach(var  emp in  Employees.repo._employees)
            {
                int num = 0;
                if (_tasks.ContainsKey(emp._ID))
                {
                    foreach (var task in _tasks[emp._ID])
                    {
                        num++;
                        task.no_task = num;
                    }
                }
                else continue ;
            }
        }
    }
}
