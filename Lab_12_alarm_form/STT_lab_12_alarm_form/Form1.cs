using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlarmClockApp
{
    public partial class Form1 : Form
    {
        private DateTime targetTime;

        public delegate void AlarmEventHandler();
        public event AlarmEventHandler raiseAlarm;

        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            this.raiseAlarm += Ring_alarm;

            this.Resize += Form1_Resize;
            this.Load += Form1_Resize;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(timeInputTextBox.Text, "HH:mm:ss", null,
                                       System.Globalization.DateTimeStyles.None, out targetTime))
            {
                timer.Start();
            }
            else
            {
                MessageBox.Show("Please enter time in HH:MM:SS format.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Change background color randomly
            int r = rand.Next(100, 256);
            int g = rand.Next(100, 256);
            int b = rand.Next(100, 256);
            this.BackColor = Color.FromArgb(r, g, b);

            // Check if time matches
            DateTime now = DateTime.Now;
            if (now.Hour >= targetTime.Hour &&
                now.Minute >= targetTime.Minute &&
                now.Second >= targetTime.Second)
            {
                timer.Stop();
                raiseAlarm?.Invoke();
            }
        }

        private void Ring_alarm()
        {
            MessageBox.Show("Alarm! Time up.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
