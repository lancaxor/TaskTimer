using System;
using System.Xml.Serialization;

namespace TasksTimer
{

    [Serializable]
    [XmlRoot(ElementName = "Task")]
    public class Task
    {
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan commonTime;
        private Boolean isActive;
        private Boolean isReady;    // done
        private String comment;
        private String url;
        private Int32 id;

        public Int32 ID { get { return this.id; } set { this.id = value; } }
        public String Comment { get { return this.comment; } set { this.comment = value; } }
        public String Url { get { return this.url; } set { this.url = value; } }
        public Boolean IsActive { get { return this.isActive; } set { this.isActive = value; } }
        public Boolean IsReady { get { return this.isReady; } set { this.isReady = value; } }

        [XmlIgnore]
        public TimeSpan CommonTime { get => commonTime; set => commonTime = value; }

        // Property for serialization instead of TimeStamp
        [XmlElement("CommonTicks")]
        public long CommonTicks { get => commonTime.Ticks; set => commonTime = new TimeSpan(value); }

        public DateTime EndTime { get => endTime; set => endTime = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }

        public Task()
        {
            this.commonTime = new TimeSpan();
            this.isActive = false;
            this.isReady = false;
            this.comment = "";
            this.id = 0;
            this.url = String.Empty;
        }

        public Task(String comment, Int32 id)
        {
            this.commonTime = new TimeSpan();
            this.isActive = false;
            this.isReady = false;
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

        public String formatTimeMunites()
        {
            return String.Format("{0: 0.00} minutes", this.GetTimeMinutes());
        }
    }
}
