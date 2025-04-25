namespace AlarmClockApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox timeInputTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headingLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeInputTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer();
            this.SuspendLayout();

            // headingLabel
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.headingLabel.Location = new System.Drawing.Point(120, 20);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(130, 30);
            this.headingLabel.TabIndex = 0;
            this.headingLabel.Text = "Alarm App";

            // timeLabel
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(30, 80);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(74, 15);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "Enter the time";

            // timeInputTextBox
            this.timeInputTextBox.Location = new System.Drawing.Point(120, 75);
            this.timeInputTextBox.Name = "timeInputTextBox";
            this.timeInputTextBox.Size = new System.Drawing.Size(120, 23);
            this.timeInputTextBox.TabIndex = 2;
            this.timeInputTextBox.PlaceholderText = "HH:MM:SS";

            // startButton
            this.startButton.Location = new System.Drawing.Point(260, 75);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

            // timer
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            // Form1
            this.ClientSize = new System.Drawing.Size(400, 160);
            this.Controls.Add(this.headingLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeInputTextBox);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Alarm Clock";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Center heading label at the top
            headingLabel.Location = new Point((formWidth - headingLabel.Width) / 2, (formHeight-headingLabel.Height)/2);

            
            int inputWidth = timeInputTextBox.Width;
            int spacing = 10;
            int controlsTotalWidth = timeLabel.Width + spacing + inputWidth + spacing + startButton.Width;

            int startX = (formWidth - controlsTotalWidth) / 2;
            int verticalY = headingLabel.Bottom + 30;

            timeLabel.Location = new Point(startX, verticalY);
            timeInputTextBox.Location = new Point(timeLabel.Right + spacing, verticalY);
            startButton.Location = new Point(timeInputTextBox.Right + spacing, verticalY);
        }

    }
}
