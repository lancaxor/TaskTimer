using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksTimer
{
    class Tasker
    {
        List<Task> tasks;
        public Tasker()
        {
            tasks = new List<Task>();
        }
        public Tasker CreateTask(String comment, Int32 id)
        {
            Task newTask = new Task(comment, id);
            this.tasks.Add(newTask);
            return this;
        }
        public Tasker DropTask(int index)
        {
            var task = this.GetTaskById(index);
            this.tasks.Remove(task);
            return this;
        }
        public Tasker SetComment(String comment, Int32 id)
        {
            this.GetTaskById(id).Comment = comment;
            return this;
        }
        public Tasker SetUrl(String url, Int32 id)
        {
            this.GetTaskById(id).Url = url;
            return this;
        }
        public String GetUrl(Int32 id)
        {
            return this.GetTaskById(id).Url;
        }
        public Tasker StartTask(int index)
        {
            this.GetTaskById(index).Start();
            return this;
        }
        public Tasker StopTask(int index)
        {
            this.GetTaskById(index).Stop();
            return this;
        }
        public Tasker ResetTask(int index)
        {
            this.GetTaskById(index).Reset();
            return this;
        }
        public Tasker ResetAllTasks()
        {
            foreach (var t in this.tasks)
            {
                t.Reset();
            }
            return this;
        }
        public Boolean IsActive(int id)
        {
            return this.GetTaskById(id).IsActive;
        }
        public Task GetTaskById(int id)
        {
            var tasks = from t in this.tasks where t.ID == id select t;
            return tasks.Single<Task>();
        }
        public Double GetSummaryTime()
        {
            double result = 0.0;
            foreach (Task t in this.tasks)
            {
                result += t.GetTimeMinutes();
            }
            return result;
        }

        public Double GetTimeById(int id)
        {
            return this.GetTaskById(id).GetTimeMinutes();
        }
    }
}
