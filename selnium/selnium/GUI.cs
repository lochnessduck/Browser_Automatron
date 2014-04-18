using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selnium
{
    public partial class GUI : Form
    {
        private IWebDriver driver { get; set; }
        
        public GUI()
        {
            InitializeComponent();
        }

        public void SetDriver(ref IWebDriver driverByRef)
        {
            // to avoid initializing two drivers, this driver is passed by reference
            driver = driverByRef;
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            String jscript = @"$('body').prepend('<p style=\'background-color:yellow;\'>Example button has been clicked.</p>');";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript(jscript);
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }
    }
}
