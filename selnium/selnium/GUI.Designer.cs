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
            this.RecordAndPauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlayAndPauseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exampleButton
            // 
            this.exampleButton.Location = new System.Drawing.Point(98, 186);
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
            this.label1.Location = new System.Drawing.Point(86, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Happy button is happy";
            // 
            // navigateToTextBox
            // 
            this.navigateToTextBox.Location = new System.Drawing.Point(12, 29);
            this.navigateToTextBox.Name = "navigateToTextBox";
            this.navigateToTextBox.Size = new System.Drawing.Size(226, 20);
            this.navigateToTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Navigate to URL";
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(244, 29);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(38, 20);
            this.GoButton.TabIndex = 4;
            this.GoButton.Text = "GO!!";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // RecordAndPauseButton
            // 
            this.RecordAndPauseButton.BackColor = System.Drawing.Color.Transparent;
            this.RecordAndPauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordAndPauseButton.ForeColor = System.Drawing.Color.Red;
            this.RecordAndPauseButton.Location = new System.Drawing.Point(15, 79);
            this.RecordAndPauseButton.Name = "RecordAndPauseButton";
            this.RecordAndPauseButton.Size = new System.Drawing.Size(69, 63);
            this.RecordAndPauseButton.TabIndex = 5;
            this.RecordAndPauseButton.Text = "•";
            this.RecordAndPauseButton.UseVisualStyleBackColor = false;
            this.RecordAndPauseButton.Click += new System.EventHandler(this.RecordAndPauseButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Transparent;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.ForeColor = System.Drawing.Color.Red;
            this.StopButton.Location = new System.Drawing.Point(108, 79);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(69, 63);
            this.StopButton.TabIndex = 6;
            this.StopButton.Text = "■";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PlayAndPauseButton
            // 
            this.PlayAndPauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayAndPauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayAndPauseButton.ForeColor = System.Drawing.Color.Red;
            this.PlayAndPauseButton.Location = new System.Drawing.Point(201, 79);
            this.PlayAndPauseButton.Name = "PlayAndPauseButton";
            this.PlayAndPauseButton.Size = new System.Drawing.Size(69, 63);
            this.PlayAndPauseButton.TabIndex = 6;
            this.PlayAndPauseButton.Text = " ▶";
            this.PlayAndPauseButton.UseVisualStyleBackColor = false;
            this.PlayAndPauseButton.Click += new System.EventHandler(this.PlayAndPauseButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 242);
            this.Controls.Add(this.PlayAndPauseButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RecordAndPauseButton);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.navigateToTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exampleButton);
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exampleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox navigateToTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button RecordAndPauseButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PlayAndPauseButton;
    }
}