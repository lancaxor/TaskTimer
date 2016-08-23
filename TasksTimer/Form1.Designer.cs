namespace TasksTimer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbTime_0 = new System.Windows.Forms.TextBox();
            this.tbTask_0 = new System.Windows.Forms.TextBox();
            this.btnStart_0 = new System.Windows.Forms.Button();
            this.btnOpenLink_0 = new System.Windows.Forms.Button();
            this.btnCopyTime_0 = new System.Windows.Forms.Button();
            this.panMain = new System.Windows.Forms.Panel();
            this.btnEditUrl_0 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDone_0 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.cmsExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panMain.SuspendLayout();
            this.cmsExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTime_0
            // 
            this.tbTime_0.Enabled = false;
            this.tbTime_0.Location = new System.Drawing.Point(325, 25);
            this.tbTime_0.Name = "tbTime_0";
            this.tbTime_0.Size = new System.Drawing.Size(163, 20);
            this.tbTime_0.TabIndex = 0;
            this.tbTime_0.TabStop = false;
            this.tbTime_0.Text = "0.00 minutes";
            // 
            // tbTask_0
            // 
            this.tbTask_0.Location = new System.Drawing.Point(3, 25);
            this.tbTask_0.Name = "tbTask_0";
            this.tbTask_0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTask_0.Size = new System.Drawing.Size(316, 20);
            this.tbTask_0.TabIndex = 4;
            this.tbTask_0.Leave += new System.EventHandler(this.tbComment_Leave);
            // 
            // btnStart_0
            // 
            this.btnStart_0.Location = new System.Drawing.Point(515, 23);
            this.btnStart_0.Name = "btnStart_0";
            this.btnStart_0.Size = new System.Drawing.Size(75, 23);
            this.btnStart_0.TabIndex = 6;
            this.btnStart_0.Text = "Start";
            this.btnStart_0.UseVisualStyleBackColor = true;
            this.btnStart_0.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnOpenLink_0
            // 
            this.btnOpenLink_0.Enabled = false;
            this.btnOpenLink_0.Location = new System.Drawing.Point(596, 23);
            this.btnOpenLink_0.Name = "btnOpenLink_0";
            this.btnOpenLink_0.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLink_0.TabIndex = 7;
            this.btnOpenLink_0.Text = "Open Task";
            this.btnOpenLink_0.UseVisualStyleBackColor = true;
            this.btnOpenLink_0.Click += new System.EventHandler(this.btnOpenTask_Click);
            // 
            // btnCopyTime_0
            // 
            this.btnCopyTime_0.Location = new System.Drawing.Point(677, 23);
            this.btnCopyTime_0.Name = "btnCopyTime_0";
            this.btnCopyTime_0.Size = new System.Drawing.Size(75, 23);
            this.btnCopyTime_0.TabIndex = 8;
            this.btnCopyTime_0.Text = "Copy Time";
            this.btnCopyTime_0.UseVisualStyleBackColor = true;
            this.btnCopyTime_0.Click += new System.EventHandler(this.btnCopyTime_Click);
            // 
            // panMain
            // 
            this.panMain.AutoScroll = true;
            this.panMain.Controls.Add(this.btnEditUrl_0);
            this.panMain.Controls.Add(this.label4);
            this.panMain.Controls.Add(this.cbDone_0);
            this.panMain.Controls.Add(this.label2);
            this.panMain.Controls.Add(this.label1);
            this.panMain.Controls.Add(this.btnCopyTime_0);
            this.panMain.Controls.Add(this.tbTask_0);
            this.panMain.Controls.Add(this.btnStart_0);
            this.panMain.Controls.Add(this.tbTime_0);
            this.panMain.Controls.Add(this.btnOpenLink_0);
            this.panMain.Location = new System.Drawing.Point(16, 12);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(851, 411);
            this.panMain.TabIndex = 5;
            // 
            // btnEditUrl_0
            // 
            this.btnEditUrl_0.Location = new System.Drawing.Point(758, 23);
            this.btnEditUrl_0.Name = "btnEditUrl_0";
            this.btnEditUrl_0.Size = new System.Drawing.Size(75, 23);
            this.btnEditUrl_0.TabIndex = 9;
            this.btnEditUrl_0.Text = "Edit Url";
            this.btnEditUrl_0.UseVisualStyleBackColor = true;
            this.btnEditUrl_0.Click += new System.EventHandler(this.btnEditUrl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Done";
            // 
            // cbDone_0
            // 
            this.cbDone_0.AutoSize = true;
            this.cbDone_0.Location = new System.Drawing.Point(494, 28);
            this.cbDone_0.Name = "cbDone_0";
            this.cbDone_0.Size = new System.Drawing.Size(15, 14);
            this.cbDone_0.TabIndex = 5;
            this.cbDone_0.UseVisualStyleBackColor = true;
            this.cbDone_0.CheckedChanged += new System.EventHandler(this.cbDone_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time elapsed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Link to task";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(792, 429);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh All";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(711, 429);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Add New";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total time:";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(78, 434);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(52, 13);
            this.lblMinutes.TabIndex = 9;
            this.lblMinutes.Text = "0 minutes";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(630, 429);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asHTMLToolStripMenuItem,
            this.asTXTToolStripMenuItem});
            this.cmsExport.Name = "cmsExport";
            this.cmsExport.Size = new System.Drawing.Size(124, 48);
            // 
            // asHTMLToolStripMenuItem
            // 
            this.asHTMLToolStripMenuItem.Name = "asHTMLToolStripMenuItem";
            this.asHTMLToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.asHTMLToolStripMenuItem.Text = "As HTML";
            this.asHTMLToolStripMenuItem.Click += new System.EventHandler(this.asHTMLToolStripMenuItem_Click);
            // 
            // asTXTToolStripMenuItem
            // 
            this.asTXTToolStripMenuItem.Name = "asTXTToolStripMenuItem";
            this.asTXTToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.asTXTToolStripMenuItem.Text = "As TXT";
            this.asTXTToolStripMenuItem.Click += new System.EventHandler(this.asTXTToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 464);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tasks Timer";
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            this.cmsExport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTime_0;
        private System.Windows.Forms.TextBox tbTask_0;
        private System.Windows.Forms.Button btnStart_0;
        private System.Windows.Forms.Button btnOpenLink_0;
        private System.Windows.Forms.Button btnCopyTime_0;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbDone_0;
        private System.Windows.Forms.Button btnEditUrl_0;
        private System.Windows.Forms.ToolTip mainTooltip;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ContextMenuStrip cmsExport;
        private System.Windows.Forms.ToolStripMenuItem asHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTXTToolStripMenuItem;
    }
}

