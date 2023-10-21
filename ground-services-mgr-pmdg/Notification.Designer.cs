namespace ground_services_manager
{
    partial class Notification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notificationMessage = new System.Windows.Forms.Label();
            this.lbl_x = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // notificationMessage
            // 
            this.notificationMessage.AutoSize = true;
            this.notificationMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notificationMessage.Location = new System.Drawing.Point(3, 7);
            this.notificationMessage.Name = "notificationMessage";
            this.notificationMessage.Size = new System.Drawing.Size(101, 13);
            this.notificationMessage.TabIndex = 0;
            this.notificationMessage.Text = "notificationMessage";
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_x.Location = new System.Drawing.Point(813, 0);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(20, 24);
            this.lbl_x.TabIndex = 1;
            this.lbl_x.Text = "x";
            this.lbl_x.Click += new System.EventHandler(this.lbl_x_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_x);
            this.Controls.Add(this.notificationMessage);
            this.Name = "Notification";
            this.Size = new System.Drawing.Size(873, 20);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Click += new System.EventHandler(this.Notification_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label notificationMessage;
        private System.Windows.Forms.Label lbl_x;
        private System.Windows.Forms.Timer timer1;
    }
}
