using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace two_guis_running_prototype
{
    class ClassRunningLoop
    {
        public Form1 form1 { get; set; }
        public void run()
        {
            Form2 form = new Form2();
            form.Show();
            //Application.Run(form);  // BAD! Bad application, go sit in the corner
            while (true)
            {
                try
                {
                    form.listBox1.Items.Add(new ListViewItem() { Text = "schmoop for form 2" });
                    //form.listBox1;
                    Console.Write("sleeping....\n");
                    Thread.Sleep(1000); // sleep for 1 second, then check cancel condition.
                    form1.listBox1.Items.Add(new ListViewItem() { Text = "schmoop for form 1" });
                    //form1.Activate();
                    //form1.Update();
                    form.Update();
                    form.Activate();
                    form.Focus();
                }
                catch
                {
                }
                finally
                {
                }
            }
        }
    }
}
