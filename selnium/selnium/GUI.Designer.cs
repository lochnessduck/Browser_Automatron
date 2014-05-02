namespace selnium
{
    partial class GUI
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
            this.exampleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.navigateToTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GoButton = new System.Windows.Forms.Button();
            this.RecordPauseLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RecordingGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveRecordingButton = new System.Windows.Forms.Button();
            this.StopRecordingButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.PauseRecordingButton = new System.Windows.Forms.Button();
            this.PlaybackGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayPauseLabel = new System.Windows.Forms.Label();
            this.RecordingGroupBox.SuspendLayout();
            this.PlaybackGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // exampleButton
            // 
            this.exampleButton.Location = new System.Drawing.Point(235, 311);
            this.exampleButton.Name = "exampleButton";
            this.exampleButton.Size = new System.Drawing.Size(75, 25);
            this.exampleButton.TabIndex = 0;
            this.exampleButton.Text = ":D";
            this.exampleButton.UseVisualStyleBackColor = true;
            this.exampleButton.Click += new System.EventHandler(this.exampleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Happy button is happy";
            // 
            // navigateToTextBox
            // 
            this.navigateToTextBox.Location = new System.Drawing.Point(6, 47);
            this.navigateToTextBox.Name = "navigateToTextBox";
            this.navigateToTextBox.Size = new System.Drawing.Size(226, 20);
            this.navigateToTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Navigate to URL";
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(238, 47);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(42, 20);
            this.GoButton.TabIndex = 4;
            this.GoButton.Text = "GO!!";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // RecordPauseLabel
            // 
            this.RecordPauseLabel.AutoSize = true;
            this.RecordPauseLabel.Location = new System.Drawing.Point(30, 140);
            this.RecordPauseLabel.Name = "RecordPauseLabel";
            this.RecordPauseLabel.Size = new System.Drawing.Size(42, 13);
            this.RecordPauseLabel.TabIndex = 8;
            this.RecordPauseLabel.Text = "Record";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stop";
            // 
            // RecordingGroupBox
            // 
            this.RecordingGroupBox.Controls.Add(this.navigateToTextBox);
            this.RecordingGroupBox.Controls.Add(this.SaveRecordingButton);
            this.RecordingGroupBox.Controls.Add(this.StopRecordingButton);
            this.RecordingGroupBox.Controls.Add(this.GoButton);
            this.RecordingGroupBox.Controls.Add(this.label2);
            this.RecordingGroupBox.Controls.Add(this.label4);
            this.RecordingGroupBox.Controls.Add(this.RecordButton);
            this.RecordingGroupBox.Controls.Add(this.PauseRecordingButton);
            this.RecordingGroupBox.Controls.Add(this.RecordPauseLabel);
            this.RecordingGroupBox.Location = new System.Drawing.Point(12, 12);
            this.RecordingGroupBox.Name = "RecordingGroupBox";
            this.RecordingGroupBox.Size = new System.Drawing.Size(339, 215);
            this.RecordingGroupBox.TabIndex = 9;
            this.RecordingGroupBox.TabStop = false;
            this.RecordingGroupBox.Text = "Record";
            // 
            // SaveRecordingButton
            // 
            this.SaveRecordingButton.Location = new System.Drawing.Point(6, 186);
            this.SaveRecordingButton.Name = "SaveRecordingButton";
            this.SaveRecordingButton.Size = new System.Drawing.Size(75, 23);
            this.SaveRecordingButton.TabIndex = 9;
            this.SaveRecordingButton.Text = "Save";
            this.SaveRecordingButton.UseVisualStyleBackColor = true;
            this.SaveRecordingButton.Visible = false;
            this.SaveRecordingButton.Click += new System.EventHandler(this.SaveRecordingButton_Click);
            // 
            // StopRecordingButton
            // 
            this.StopRecordingButton.BackColor = System.Drawing.SystemColors.Control;
            this.StopRecordingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopRecordingButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.StopRecordingButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.StopRecordingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopRecordingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopRecordingButton.ForeColor = System.Drawing.SystemColors.Control;
            this.StopRecordingButton.Image = global::selnium.Properties.Resources.stop;
            this.StopRecordingButton.Location = new System.Drawing.Point(98, 102);
            this.StopRecordingButton.Name = "StopRecordingButton";
            this.StopRecordingButton.Size = new System.Drawing.Size(35, 35);
            this.StopRecordingButton.TabIndex = 6;
            this.StopRecordingButton.UseVisualStyleBackColor = false;
            this.StopRecordingButton.Click += new System.EventHandler(this.StopRecordingButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.BackColor = System.Drawing.SystemColors.Control;
            this.RecordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecordButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.RecordButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.RecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RecordButton.Image = global::selnium.Properties.Resources.record;
            this.RecordButton.Location = new System.Drawing.Point(34, 102);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(35, 35);
            this.RecordButton.TabIndex = 5;
            this.RecordButton.UseVisualStyleBackColor = false;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // PauseRecordingButton
            // 
            this.PauseRecordingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseRecordingButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PauseRecordingButton.Image = global::selnium.Properties.Resources.pause_recording;
            this.PauseRecordingButton.Location = new System.Drawing.Point(34, 102);
            this.PauseRecordingButton.Name = "PauseRecordingButton";
            this.PauseRecordingButton.Size = new System.Drawing.Size(35, 35);
            this.PauseRecordingButton.TabIndex = 10;
            this.PauseRecordingButton.UseVisualStyleBackColor = true;
            this.PauseRecordingButton.Click += new System.EventHandler(this.PauseRecordingButton_Click);
            // 
            // PlaybackGroupBox
            // 
            this.PlaybackGroupBox.Controls.Add(this.button1);
            this.PlaybackGroupBox.Controls.Add(this.LoadButton);
            this.PlaybackGroupBox.Controls.Add(this.PlayButton);
            this.PlaybackGroupBox.Controls.Add(this.label6);
            this.PlaybackGroupBox.Controls.Add(this.PauseButton);
            this.PlaybackGroupBox.Controls.Add(this.PlayPauseLabel);
            this.PlaybackGroupBox.Location = new System.Drawing.Point(12, 233);
            this.PlaybackGroupBox.Name = "PlaybackGroupBox";
            this.PlaybackGroupBox.Size = new System.Drawing.Size(167, 148);
            this.PlaybackGroupBox.TabIndex = 10;
            this.PlaybackGroupBox.TabStop = false;
            this.PlaybackGroupBox.Text = "Playback";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::selnium.Properties.Resources.stop;
            this.button1.Location = new System.Drawing.Point(98, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(6, 119);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 9;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.SystemColors.Control;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PlayButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayButton.Image = global::selnium.Properties.Resources.play;
            this.PlayButton.Location = new System.Drawing.Point(34, 40);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(35, 35);
            this.PlayButton.TabIndex = 6;
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Stop";
            // 
            // PauseButton
            // 
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PauseButton.Image = global::selnium.Properties.Resources.pause;
            this.PauseButton.Location = new System.Drawing.Point(34, 40);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(35, 35);
            this.PauseButton.TabIndex = 7;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayPauseLabel
            // 
            this.PlayPauseLabel.AutoSize = true;
            this.PlayPauseLabel.Location = new System.Drawing.Point(33, 78);
            this.PlayPauseLabel.Name = "PlayPauseLabel";
            this.PlayPauseLabel.Size = new System.Drawing.Size(27, 13);
            this.PlayPauseLabel.TabIndex = 8;
            this.PlayPauseLabel.Text = "Play";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(363, 390);
            this.Controls.Add(this.PlaybackGroupBox);
            this.Controls.Add(this.RecordingGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exampleButton);
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.RecordingGroupBox.ResumeLayout(false);
            this.RecordingGroupBox.PerformLayout();
            this.PlaybackGroupBox.ResumeLayout(false);
            this.PlaybackGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exampleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox navigateToTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button StopRecordingButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label RecordPauseLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox RecordingGroupBox;
        private System.Windows.Forms.Button SaveRecordingButton;
        private System.Windows.Forms.GroupBox PlaybackGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label PlayPauseLabel;
        private System.Windows.Forms.Button PauseRecordingButton;
    }
}