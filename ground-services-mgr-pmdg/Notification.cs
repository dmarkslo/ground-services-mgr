using System;
using System.Drawing;
using System.Windows.Forms;

namespace ground_services_manager
{
    public partial class Notification : UserControl
    {
        public Notification(string Level)
        {
            InitializeComponent();
            this.level = Level;
            //this.text = Text;
        }

        public Notification(string Level, string Text, bool isImportant)
        {
            InitializeComponent();
            this.level = Level;
            this.text = Text;
            this.important = isImportant;
            //this.text = Text;
        }

        // Variables
        string level = "";
        string text = "";
        int notificationInstances = 0;
        bool important = false;

        // Properties
        public string TextMessage { get { return text; } }
        public string Level { get { return level; } }

        private void Notification_Load(object sender, EventArgs e)
        {
            // Center notification message label
            notificationMessage.Location = new Point(10, this.Height / 2 - notificationMessage.Height / 2);
            // Center exit label
            lbl_x.Location = new Point(this.Width - 40, this.Height / 2 - lbl_x.Height / 2);
            if (important)
                lbl_x.Visible = false;
            this.Visible = false;

            // Design Notification
            if (Level != "")
            {
                this.ForeColor = Color.White;
                switch (Level)
                {
                    case "Success":
                        this.BackColor = Color.Green;
                        break;
                    case "Warning":
                        this.BackColor = Color.Orange;
                        break;
                    case "Error":
                        this.BackColor = Color.Red;
                        break;
                    case "Important":
                        this.BackColor = Color.PaleVioletRed;
                        break;
                }
            }

            // Add Text to Notification bar after design
            if (text != "")
            {
                notificationMessage.Text = text;
            }

            // Location of notification bar, upper right corner. Coords X0,Y0
            this.Location = new Point(0, 0);

        }

        public void Push()
        {
            // Sets Notification to visible, from default not visible state.

            if (notificationInstances < 1)
            {
                this.BringToFront();
                this.Visible = true;
                notificationInstances++;
                timer1.Start();
            }

        }

        private void lbl_x_Click(object sender, EventArgs e)
        {
            notificationInstances--;
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!important) // If not important, then notification closes automatically.
            {
                this.Visible = false;
                this.Dispose();
            }

            timer1.Stop(); // Timer only needs to tick once to close the notification.

        }

        private void Notification_Click(object sender, EventArgs e)
        {

        }

    
    }
}
