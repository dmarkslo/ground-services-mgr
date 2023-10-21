namespace ground_services_mgr_pmdg
{
    partial class LiveryItem
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
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.liveryPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveryPB)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPicBox
            // 
            this.logoPicBox.Location = new System.Drawing.Point(0, 455);
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.Size = new System.Drawing.Size(200, 60);
            this.logoPicBox.TabIndex = 0;
            this.logoPicBox.TabStop = false;
            // 
            // liveryPB
            // 
            this.liveryPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.liveryPB.Location = new System.Drawing.Point(0, 0);
            this.liveryPB.Name = "liveryPB";
            this.liveryPB.Size = new System.Drawing.Size(200, 600);
            this.liveryPB.TabIndex = 1;
            this.liveryPB.TabStop = false;
            this.liveryPB.Click += new System.EventHandler(this.liveryPB_Click);
            this.liveryPB.MouseEnter += new System.EventHandler(this.liveryPictureBox_MouseEnter);
            this.liveryPB.MouseLeave += new System.EventHandler(this.liveryPictureBox_MouseLeave);
            // 
            // LiveryItem
            // 
            this.Controls.Add(this.logoPicBox);
            this.Controls.Add(this.liveryPB);
            this.Name = "LiveryItem";
            this.Size = new System.Drawing.Size(200, 600);
            this.Load += new System.EventHandler(this.Livery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveryPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox liveryPictureBox;
        private System.Windows.Forms.PictureBox logoPB;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.PictureBox liveryPB;
    }
}
