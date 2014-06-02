using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace two_guis_running_prototype
{
    public partial class Form1 : Form
    {
        //public ThreadStart thread;
        public Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)//if (thread == null)
            {
                ClassRunningLoop loop = new ClassRunningLoop() { form1 = this };
                //loop.run();
                ThreadStart prethread = new ThreadStart(loop.run);
                thread = new Thread(prethread);
                thread.Start();
            }
            else
            {
                thread.Resume();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread.Abort();
            //thread.Suspend();
            //cancel
        }

        public void add_item(string item)
        {
            listBox1.Items.Add(new ListViewItem() { Text = "schmoop" });
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
