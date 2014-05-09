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
        public Program program { get; set; }
        
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

        private void RecordButton_Click(object sender, EventArgs e)
        {
            PauseRecordingButton.Visible = true;
            RecordButton.Visible = false;
            RecordPauseLabel.Text = "Pause";
            this.program.isRecording = true;
            //driver.setupForRecording();
            SaveRecordingButton.Visible = true;
        }

        private void PauseRecordingButton_Click(object sender, EventArgs e)
        {
            PauseRecordingButton.Visible = false;
            RecordButton.Visible = true;
            RecordPauseLabel.Text = "Record";
            this.program.isRecording = false;
            //driver.teardownRecording();
        }

        private void StopRecordingButton_Click(object sender, EventArgs e)
        {
            this.program.isRecording = false;
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
            PauseButton.Focus();
            PlayPauseLabel.Text = "Pause";
            program.populateProgressListBox();
            program.Playback(2000);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            PauseButton.Visible = false;
            PlayButton.Visible = true;
            PlayButton.Focus();
            PlayPauseLabel.Text = "Play";
        }

        private void SaveRecordingButton_Click(object sender, EventArgs e)
        {
            this.RecordButton.PerformClick();
            RecordPauseLabel.Text = "Continue";
            program.saveUserInputs();
        }

        // see this stack overflow for allowing dragging and rearranging of the list items.
        //https://stackoverflow.com/questions/3350187/wpf-c-rearrange-items-in-listbox-via-drag-and-drop
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
