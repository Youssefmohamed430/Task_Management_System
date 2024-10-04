using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public enum Status { NotStarted, InProgress, Completed, OnHold }
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
            this.no_task = 0 ;
            this._Created = DateTime.Now;
            repo = RepositryTasks.GetInstanceRepoTask();
        }
        public void Assign_Task(int _id, string _title, string _description, Status _status)
        {
            var temp  = new Task {_Title = _title,_Description = _description,_status =  _status};
            if (repo._tasks.ContainsKey(_id))
            {
                repo._tasks[_id].Add(temp);
                temp.No_Task = repo._tasks[_id].Count;
            }
            else
            {
                repo._tasks.Add(_id, new List<Task>());
                repo._tasks[_id].Add(temp);
                temp.No_Task = repo._tasks[_id].Count;
            }
        }
        public void Remove_Task(int _id,int no_task)
        {
            var temp = repo.LoadTasks()[_id][no_task];
            repo._tasks[_id].Remove(temp);
        }
        public void UpdateTaskStatus()
        {

        }

    }
}
