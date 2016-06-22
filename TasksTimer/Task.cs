using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksTimer
{
    class Task
    {
        DateTime startTime;
        DateTime endTime;
        TimeSpan commonTime;
        Boolean isActive;
        String comment;
        String url;
        Int32 id;

        public Int32 ID { get { return this.id; } set { this.id = value; } }
        public String Comment { get { return this.comment; } set { this.comment = value; } }
        public String Url { get { return this.url; } set { this.url = value; } }
        public Boolean IsActive { get { return this.isActive; } set { this.isActive = value; } }

        public Task(String comment, Int32 id)
        {
            this.commonTime = new TimeSpan();
            this.isActive = false;
            this.comment = comment;
            this.id = id;
            this.url = String.Empty;
        }
        public void Start()
        {
            if (!this.isActive)
            {
                this.startTime = DateTime.Now;
                this.isActive = true;
            }
        }
        public void Stop()
        {
            if (this.isActive)
            {
                this.isActive = false;
                this.endTime = DateTime.Now;
                this.commonTime = this.GetTimeElapsed();

                this.startTime = new DateTime();
                this.endTime = new DateTime();
            }
        }
        public void Reset()
        {
            this.commonTime = new TimeSpan();
            this.startTime = new DateTime();
            this.endTime = new DateTime();
        }
        protected TimeSpan GetTimeElapsed()
        {
            return ((this.isActive ? DateTime.Now : this.endTime) - this.startTime) + this.commonTime;
        }
        public double GetTimeMinutes()
        {
            return this.GetTimeElapsed().TotalMinutes;
            //return this.GetTimeElapsed().TotalSeconds;    //debug...
        }
    }
}
