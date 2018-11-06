using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace TasksTimer
{
    public partial class Form1 : Form
    {

        protected int maxIndex;
        protected int maxTabStop;
        Tasker tasker;

        public Form1()
        {
            InitializeComponent();
            this.maxIndex = 0;

            this.tasker = new Tasker();
            this.maxTabStop = 9;
        }
        private int getIndexByName(String name)
        {
            int start = name.LastIndexOf('_');
            String number = name.Substring(start + 1);
            return Int32.Parse(number);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            int index = getIndexByName((sender as Button).Name);

            if (this.tasker.IsActive(index))
            {
                this.tasker.StopTask(index);
                (sender as Button).Text = "Start";
                var timeElementId = "tbTime_" + index;
                this.panMain.Controls[timeElementId].Text = String.Format("{0:0.00} minutes", tasker.GetTimeById(index));
            }
            else
            {
                this.tasker.StartTask(index);
                (sender as Button).Text = "Stop";
            }
        }

        private void btnCopyTime_Click(object sender, EventArgs e)
        {
            int index = getIndexByName((sender as Button).Name);
            double result = this.tasker.GetTimeById(index);
            Clipboard.SetText(String.Format("{0:0.00}", result));
        }
        private void btnOpenTask_Click(object sender, EventArgs e)
        {

            int index = getIndexByName((sender as Button).Name);
            String url = this.tasker.GetUrl(index);

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = url;
            try
            {
                Process proc = Process.Start(start);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening URL: " + ex.Message);
            }

        }
        private void btnEditUrl_Click(object sender, EventArgs e)
        {
            int index = getIndexByName((sender as Button).Name);
            String url = String.Empty;
            Prompt prompt = new Prompt();
            String oldUrl = this.tasker.GetUrl(index);

            if (oldUrl != null && oldUrl != String.Empty)
            {
                prompt.SetUrl(oldUrl);
            }

            if (prompt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                url = prompt.GetUrl();
                this.tasker.SetUrl(url, index);
                this.panMain.Controls["btnOpenLink_" + index].Enabled = true;
                this.mainTooltip.SetToolTip(this.panMain.Controls["btnOpenLink_" + index], url);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs eventArgs)
        {
            this.createTaskControls();
            this.tasker.CreateTask("", this.maxIndex);
            this.maxIndex++;
        }

        private void createTaskControls() {
            this.createTaskControls(null);
        }

        private void createTaskControls(Task task)
        {
            TextBox newComment = new TextBox();
            newComment.Location = new Point(this.tbTask_0.Left, this.tbTask_0.Bottom + (this.maxIndex - 1) * this.tbTask_0.Height + this.maxIndex * 8);
            newComment.Size = this.tbTask_0.Size;
            newComment.Name = "tbTask_" + this.maxIndex;
            newComment.Leave += (s, e) => this.tbComment_Leave(s, e);
            newComment.TabIndex = ++this.maxTabStop;
            newComment.Text = (task == null ? "" : task.Comment);
            newComment.Enabled = (task == null || !task.IsReady);

            TextBox newTime = new TextBox();
            newTime.Location = new Point(this.tbTime_0.Left, this.tbTime_0.Bottom + (this.maxIndex - 1) * this.tbTime_0.Height + this.maxIndex * 8);     // height + difference in button and tb + space
            newTime.Size = this.tbTime_0.Size;
            newTime.Name = "tbTime_" + this.maxIndex;
            newTime.Text = (task == null ? "0.00 minutes" : task.formatTimeMunites());
            newTime.Enabled = false;

            // done
            CheckBox newActive = new CheckBox();
            newActive.Checked = (task != null && task.IsReady);
            newActive.Name = "cbActive_" + this.maxIndex;
            newActive.Location = new Point(this.cbDone_0.Left, this.cbDone_0.Bottom + (this.maxIndex - 1) * this.cbDone_0.Height + this.maxIndex * 14);
            newActive.Size = new System.Drawing.Size(15, 14);
            newActive.CheckedChanged += (s, e) => this.cbDone_CheckedChanged(s, e);
            newActive.TabIndex = ++this.maxTabStop;

            // the Start button
            Button newStart = new Button();
            newStart.Location = new Point(this.btnStart_0.Left, this.btnStart_0.Bottom + (this.maxIndex - 1) * this.btnStart_0.Height + this.maxIndex * 5);
            newStart.Size = new System.Drawing.Size(75, 23);
            newStart.Name = "btnStart_" + this.maxIndex;
            newStart.Text = ((task == null || !task.IsActive) ? "Start" : "Stop");
            newStart.Click += (s, e) => this.btnStartStop_Click(s, e);
            newStart.TabIndex = ++this.maxTabStop;
            newStart.Enabled = (task == null || !task.IsReady);

            // Open Url button
            Button newOpenLink = new Button();
            newOpenLink.Location = new Point(this.btnOpenLink_0.Left, this.btnOpenLink_0.Bottom + (this.maxIndex - 1) * this.btnOpenLink_0.Height + this.maxIndex * 5);
            newOpenLink.Size = new System.Drawing.Size(75, 23);
            newOpenLink.Name = "btnOpenLink_" + this.maxIndex;
            newOpenLink.Text = "Open Task";
            newOpenLink.Click += (s, e) => this.btnOpenTask_Click(s, e);
            newOpenLink.TabIndex = ++this.maxTabStop;
            if(task != null && task.Url != null && "" != task.Url)
            {
                this.mainTooltip.SetToolTip(newOpenLink, task.Url);
                newOpenLink.Enabled = true;
            } else
            {
                newOpenLink.Enabled = false;
            }

            Button newCopyTime = new Button();
            newCopyTime.Location = new Point(this.btnCopyTime_0.Left, this.btnCopyTime_0.Bottom + (this.maxIndex - 1) * this.btnCopyTime_0.Height + this.maxIndex * 5);
            newCopyTime.Size = new System.Drawing.Size(75, 23);
            newCopyTime.Name = "btnCopyTime_" + this.maxIndex;
            newCopyTime.Text = "Copy Time";
            newCopyTime.Click += (s, e) => this.btnCopyTime_Click(s, e);
            newCopyTime.TabIndex = ++this.maxTabStop;

            Button newEditLink = new Button();
            newEditLink.Location = new Point(this.btnEditUrl_0.Left, this.btnEditUrl_0.Bottom + (this.maxIndex - 1) * this.btnEditUrl_0.Height + this.maxIndex * 5);
            newEditLink.Size = new System.Drawing.Size(75, 23);
            newEditLink.Name = "btnEditUrl_" + this.maxIndex;
            newEditLink.Text = "Edit Url";
            newEditLink.Click += (s, e) => this.btnEditUrl_Click(s, e);
            newEditLink.TabIndex = ++this.maxTabStop;

            this.panMain.Controls.Add(newComment);
            this.panMain.Controls.Add(newTime);
            this.panMain.Controls.Add(newActive);
            this.panMain.Controls.Add(newStart);
            this.panMain.Controls.Add(newOpenLink);
            this.panMain.Controls.Add(newCopyTime);
            this.panMain.Controls.Add(newEditLink);
        }

        private void tbComment_Leave(object sender, EventArgs e)
        {
            int id = getIndexByName((sender as TextBox).Name);
            this.tasker.SetComment((sender as TextBox).Text, id);
        }

        /// <summary>
        /// Refresh all timers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            double sumTime = 0.0;
            for (int i = 0; i < this.maxIndex; i++)
            {
                var timeElementId = "tbTime_" + i;
                double currentTime = this.tasker.GetTimeById(i);
                this.panMain.Controls[timeElementId].Text = String.Format("{0: 0.00} minutes", this.tasker.GetTimeById(i));
                sumTime += currentTime;
            }

            this.lblMinutes.Text = String.Format("{0:0.00} minutes", sumTime);
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            this.tasker.ResetAllTasks();
            btnRefresh_Click(sender, e);
        }

        /// <summary>
        /// Check the "Changed" flag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDone_CheckedChanged(object sender, EventArgs e)
        {
            int id = getIndexByName((sender as CheckBox).Name);

            if (!this.tasker.IsActive(id))
            {
                this.panMain.Controls["tbTask_" + id].Enabled = false;
                this.panMain.Controls["btnStart_" + id].Enabled = false;
                (sender as CheckBox).Enabled = false;
                this.tasker.SetDone(id);
            }
            else
            {
                (sender as CheckBox).Checked = false;
            }
        }

        /// <summary>
        /// Export list of tasks as HTML document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void asHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tasker.GetCount() <= 0)
            {
                MessageBox.Show("Nothing to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Html files |*.html| All files |*.*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var tasks = this.tasker.GetAllTasks();
                var dateTime = DateTime.Now.ToString();
                StringBuilder builder = new StringBuilder("<!doctype html><head><title>" + dateTime + "</title><style>td,th {padding: 10px;}</style></head><body><p>" + dateTime + "</p><table border='1'><thead><tr><th>Title</th><th>Time</th><th>Done</th><th>Link</th></tr>");
                foreach (var task in tasks)
                {
                    builder.AppendLine();
                    builder.AppendFormat("<tr><td>{0}</td><td>{1: 0.00} minutes</td><td>{2}</td><td>", task.Comment, task.GetTimeMinutes(), task.IsReady ? "Yes" : "No");

                    if (task.Url.Length > 0)
                    {
                        builder.AppendFormat("<a href='{0}' target='_blank'>{0}</a>", task.Url);
                    }
                    else
                    {
                        builder.Append("&lt;no link&gt;");
                    }
                    builder.Append("</td></tr>");
                }

                builder.AppendLine("<table></body></html>");

                try
                {
                    StreamWriter writer = new StreamWriter(sfd.OpenFile(), Encoding.Unicode);
                    writer.Write(builder.ToString());
                    writer.Close();
                    MessageBox.Show("File saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving data to file: " + ex.Message);
                }
            }
        }

        private void asTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tasker.GetCount() <= 0)
            {
                MessageBox.Show("Nothing to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files |*.txt| All files |*.*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var tasks = this.tasker.GetAllTasks();
                StringBuilder builder = new StringBuilder(DateTime.Now.ToString());
                foreach (var task in tasks)
                {
                    builder.AppendLine();
                    builder.AppendFormat("{0}\t{1: 0.00} minutes", task.Comment, task.GetTimeMinutes());
                    if (task.IsReady)
                    {
                        builder.Append(" (task finished)");
                    }

                    if (task.Url.Length > 0)
                    {
                        builder.AppendFormat("\t({0})", task.Url);
                    }
                }

                try
                {
                    StreamWriter writer = new StreamWriter(sfd.OpenFile(), Encoding.Unicode);
                    writer.Write(builder.ToString());
                    writer.Close();
                    MessageBox.Show("File saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving data to file: " + ex.Message);
                }
            }
        }

        private void asXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tasker.GetCount() <= 0)
            {
                MessageBox.Show("Nothing to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files |*.ttp| All files |*.*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var tasks = this.tasker.GetAllTasks();

                var serializer = new XmlSerializer(typeof(List<Task>));
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                serializer.Serialize(sw, tasks);
                string xmlResult = sw.GetStringBuilder().ToString();

                try
                {
                    StreamWriter writer = new StreamWriter(sfd.OpenFile(), Encoding.Unicode);
                    writer.Write(sb.ToString());
                    writer.Close();
                    MessageBox.Show("File saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving data to file: " + ex.Message);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Point location = new Point(this.Left + (sender as Button).Left, this.Top + (sender as Button).Bottom - this.cmsExport.Height);
            this.cmsExport.Show(location);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files |*.ttp| All files |*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var readStream = ofd.OpenFile();
                var serializer = new XmlSerializer(typeof(List<Task>));
                List<Task> tasks = (List<Task>) serializer.Deserialize(readStream);
                readStream.Close();
                foreach(Task task in tasks)
                {
                    if(task.CommonTicks == 0 && (task.Comment == "" || task.Comment == null))
                    {
                        continue;
                    }
                    this.createTaskControls(task);
                    this.tasker.AddTask(task, this.maxIndex);
                    this.maxIndex++;
                }
            }
        }
    }
}