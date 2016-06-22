using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksTimer
{
    public partial class Prompt : Form
    {
        private String result = String.Empty;
        public Prompt()
        {
            InitializeComponent();
        }
        public void SetUrl(String url)
        {
            this.result = url;
            this.tbUrl.Text = url;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.result = this.tbUrl.Text;
        }
        public String GetUrl()
        {
            return this.result;
        }
    }
}
