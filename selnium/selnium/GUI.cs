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
        public IWebDriver driver { get; set; }
        public bool recording = false;
        
        public GUI()
        {
            InitializeComponent();
        }

        /*public void SetDriver(ref BetterChrome driverByRef)
        {
            // to avoid initializing two drivers, this driver is passed by reference
            driver = driverByRef;
        }*/

        private void exampleButton_Click(object sender, EventArgs e)
        {
            String jscript = @"$('body').prepend('<p style=\'background-color:yellow;\'>Example button has been clicked.</p>');";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript(jscript);
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            driver.Url = navigateToTextBox.Text;
            driver.Navigate();
        }

        private void RecordAndPauseButton_Click(object sender, EventArgs e)
        {
            // Turn on click intercept
            Button button = (Button)sender;
            recording = !recording;
            if (recording)
            {
                //driver.setupForRecording();
            }
            else
            {
                //driver.teardownRecording();
            }
        }

        private void StopRecordingButton_Click(object sender, EventArgs e)
        {
            // if recording
                // prompt user to save or discard recording
                // file save ui
            // else if playback
                // Program????.reloadUserActionsListFromBeginning()
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            PauseButton.Visible = true;
            PlayButton.Visible = false;
            PlayPauseLabel.Text = "Pause";
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            PlayButton.Visible = true;
            PauseButton.Visible = false;
            PlayPauseLabel.Text = "Play";
        }
    }
}
