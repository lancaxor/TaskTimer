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
            this.tasker.CreateTask("", this.maxIndex++);
            this.maxTabStop = 9;
        }
        private int getIndexByName(String name)
        {
            int start = name.LastIndexOf('_');
            String number = name.Substring(start+1);
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
            TextBox newComment = new TextBox();
            newComment.Location = new Point(this.tbTask_0.Left, this.tbTask_0.Bottom + (this.maxIndex - 1) * this.tbTask_0.Height + this.maxIndex * 8);
            newComment.Size = this.tbTask_0.Size;
            newComment.Name = "tbTask_" + this.maxIndex;
            newComment.Leave += (s, e) => this.tbComment_Leave(s, e);
            newComment.TabIndex = ++this.maxTabStop;

            TextBox newTime = new TextBox();
            newTime.Location = new Point(this.tbTime_0.Left, this.tbTime_0.Bottom + (this.maxIndex - 1) * this.tbTime_0.Height + this.maxIndex * 8);     // height + difference in button and tb + space
            newTime.Size = this.tbTime_0.Size;
            newTime.Name = "tbTime_" + this.maxIndex;
            newTime.Text = "0.00 minutes";
            newTime.Enabled = false;

            CheckBox newActive = new CheckBox();
            newActive.Checked = false;
            newActive.Name = "cbActive_" + this.maxIndex;
            newActive.Location = new Point(this.cbDone_0.Left, this.cbDone_0.Bottom + (this.maxIndex - 1) * this.cbDone_0.Height + this.maxIndex * 14);
            newActive.Size = new System.Drawing.Size(15, 14);
            newActive.CheckedChanged += (s, e) => this.cbDone_CheckedChanged(s, e);
            newActive.TabIndex = ++this.maxTabStop;

            Button newStart = new Button();
            newStart.Location = new Point(this.btnStart_0.Left, this.btnStart_0.Bottom + (this.maxIndex - 1) * this.btnStart_0.Height + this.maxIndex * 5);
            newStart.Size = new System.Drawing.Size(75, 23);
            newStart.Name = "btnStart_" + this.maxIndex;
            newStart.Text = "Start";
            newStart.Click += (s, e) => this.btnStartStop_Click(s, e);
            newStart.TabIndex = ++this.maxTabStop;

            Button newOpenLink = new Button();
            newOpenLink.Location = new Point(this.btnOpenLink_0.Left, this.btnOpenLink_0.Bottom + (this.maxIndex - 1) * this.btnOpenLink_0.Height + this.maxIndex * 5);
            newOpenLink.Size = new System.Drawing.Size(75, 23);
            newOpenLink.Name = "btnOpenLink_" + this.maxIndex;
            newOpenLink.Text = "Open Task";
            newOpenLink.Click += (s, e) => this.btnOpenTask_Click(s, e);
            newOpenLink.TabIndex = ++this.maxTabStop;
            newOpenLink.Enabled = false;

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

            // so, we done with controls, now we need create a task
            this.tasker.CreateTask("", this.maxIndex);
            this.maxIndex++;
        }

        private void tbComment_Leave(object sender, EventArgs e)
        {
            int id = getIndexByName((sender as TextBox).Name);
            this.tasker.SetComment((sender as TextBox).Text, id);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            double sumTime = 0.0;
            for (int i = 0; i < this.maxIndex; i++ )
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

        private void cbDone_CheckedChanged(object sender, EventArgs e)
        {
            int id = getIndexByName((sender as CheckBox).Name);

            if (!this.tasker.IsActive(id))
            {
                this.panMain.Controls["tbTask_" + id].Enabled = false;
                this.panMain.Controls["btnStart_" + id].Enabled = false;
                (sender as CheckBox).Enabled = false;
            }
            else
            {
                (sender as CheckBox).Checked = false;
            }
        }
    }
}
