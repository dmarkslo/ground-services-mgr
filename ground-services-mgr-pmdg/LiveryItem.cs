using Bunifu.UI.WinForms;
using ground_services_mgr_pmdg.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ground_services_mgr_pmdg
{
    public partial class LiveryItem : UserControl
    {
        public LiveryItem(string title)
        {
            InitializeComponent();
            liveryTitle = title;
        }

        string liveryTitle;

        Image liveryImage;
        Image liveryImageHover;
        Image liveryLogo;     

        private void Livery_Load(object sender, EventArgs e)
        {
            // Load required images from Resources.
            string liveryname = liveryTitle.ToLower();
            liveryImage = GetImageFromResource(liveryname);
            liveryImageHover = GetImageFromResource(liveryname + "_selected");
            liveryLogo = GetImageFromResource(liveryname + "_logo");

            // Set images
            liveryPB.Image = liveryImage;
            logoPicBox.Image = liveryLogo;
            logoPicBox.Visible = false;
        }


        public static Image GetImageFromResource(string resourceName)
        {
            ResourceManager rm = new ResourceManager("ground_services_mgr_pmdg.Properties.Resources", Assembly.GetExecutingAssembly());
            object resourceObject = rm.GetObject(resourceName);

            if (resourceObject is Image image) 
                return image;
            else
                return null;
            
        }

        public string Title { get { return liveryTitle; }}

        private void Livery_MouseEnter(object sender, EventArgs e)
        {
        }

        private void Livery_MouseLeave(object sender, EventArgs e)
        {

        }

        private void liveryPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void liveryPictureBox_MouseEnter(object sender, EventArgs e)
        {
            liveryPB.Image = liveryImageHover;
            logoPicBox.Visible = true;
        }

        private void liveryPictureBox_MouseLeave(object sender, EventArgs e)
        {
            liveryPB.Image = liveryImage;
            logoPicBox.Visible = false;
        }

        private void liveryLogoPicturebox_Click(object sender, EventArgs e)
        {

        }

     
    }
}
