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
            var dec = repo._tasks;
            var temp = repo._tasks[_id][no_task];
            repo._tasks[_id].Remove(temp);
            foreach (var item in dec[_id])
            {
                item.no_task = dec[_id].IndexOf(item) + 1;
            }
        }
        public bool IsValid(int _id, int no_task)
            => (no_task <= repo._tasks[_id].Count);
        public bool HasTask(int _id)
           => repo._tasks.ContainsKey(_id);
        public bool IsThere(int _id)
            => repo.Employees.repo._employees.Contains(repo.Employees.search_employee(_id));
        public bool IsStringValid(string s)
            => s.All(a => a >= 48 && a <= 57);
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
        public void ReplaceTask(int id1,int id2,int NumTask)
        {
            var temp = repo._tasks;
            var emp1Task = temp[id1][NumTask];
            Assign_Task(id2, emp1Task._Title, emp1Task._Description, emp1Task._status);
            emp1Task.no_task = temp[id2].Count;
            Remove_Task(id1,NumTask);
        }
        public Task SearchTask(string TiTlE)
        {
            var temp = repo._tasks;
            List<Task>element = null;
            foreach (var item in temp.Values)
            {
                element = item.Where(b => b._Title.ToLower() == TiTlE.ToLower()).ToList();
                if (element.Count > 0) break;
            }
            try { return element[0]; }
            catch { return null; }
        }
    }
}
