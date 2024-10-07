using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    //public enum Status { NotStarted, InProgress, Completed, OnHold }
    public class Task
    {
        public RepositryTasks repo;
        private int No_Task;
        private string Title;
        private string Description;
        private DateTime Created;
        private Status status;
        public Status _status { get; set; }
        public string _Title { get; set; }
        public string _Description { get; set; }
        public DateTime _Created { get; set; }
        public int no_task { get; set; }

        public Task()
        {
            this.no_task = 0;
            this._Created = DateTime.Now;
            repo = RepositryTasks.GetInstanceRepoTask();
        }
        public void Assign_Task(int _id, string _title, string _description, Status _status = Status.NotStarted)
        {
            var temp = new Task { _Title = _title, _Description = _description, _status = _status };
            if (repo._tasks.ContainsKey(_id))
            {
                repo._tasks[_id].Add(temp);
                temp.no_task = repo._tasks[_id].Count;
            }
            else
            {
                repo._tasks.Add(_id, new List<Task>());
                repo._tasks[_id].Add(temp);
                temp.no_task = repo._tasks[_id].Count;
            }
        }
        public void Remove_Task(int _id, int no_task)
        {
            var temp = repo._tasks[_id][no_task];
            repo._tasks[_id].Remove(temp);
        }
        public bool IsValid(int _id, int no_task)
        {
            if (no_task > repo._tasks[_id].Count)
            {
                return false;
            }
            else return true;
        }
        public bool HasTask(int _id)
        {
            if (repo._tasks.ContainsKey(_id))
                return true;
            else return false;
        }
        public bool IsThere(int _id)
        {
            var emp1 = repo.Employees;
            if(emp1.repo._employees.Contains(emp1.search_employee(_id)))
            {
                return true;
            }
            else return false;
        }
        public void UpdateTaskStatus(int _id, int no_task, Status _status)
        {
            var temp = repo._tasks[_id][no_task];
            temp._status = _status;
        }
        public IEnumerable<IGrouping<Status, Task>> FilterStatus()
        {
            var query = repo._tasks.Select(x => x.Value);
            List<Task> TASKS = new List<Task>();
            foreach (var item in query)
            {
                foreach (var task in item)
                {
                    TASKS.Add(task);
                }
            }
            return TASKS.GroupBy(a => a._status);
        }
        public Employee ReturnEmp(Task A)
        {
            foreach (var item in repo._tasks)
            {
                for (var i = 0; i < item.Value.Count; i++)
                {
                    if (item.Value[i] == A)
                    {
                        return repo.Employees.repo._employees[item.Key - 101];
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
