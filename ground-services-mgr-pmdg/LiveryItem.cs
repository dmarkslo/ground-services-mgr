using Bunifu.UI.WinForms;
using ground_services_manager;
using ground_services_mgr_pmdg.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        string communityPath;
        string fileName = "community_path.txt";

        private void Livery_Load(object sender, EventArgs e)
        {
            // Load required images from Resources.
            string liveryname = liveryTitle.ToLower(); // save name to lowercase, as the resource names are in lowercase.
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

        private void liveryPB_Click(object sender, EventArgs e)
        {
            // Code that will execute the file swap needed to change skin in-game. 
            if (CommunityPathExists())
            {
                ResetCommunityToDefault();
                OverWriteCommunity();

                Notification successCopy = new Notification("Success", "Successfully replaced ground service textures. You can now start MSFS.", false);
                this.Parent.Controls.Add(successCopy);
                successCopy.Push();
            }
        }

        private bool CommunityPathExists()
        {
            bool exists = false;
                try
                {
                    // Read from file. Streamreader closes automatically.
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            communityPath = line;
                        }
                    }
                    if (communityPath != "" && communityPath != " ")
                    {
                        exists = true;
                    }
                }
                catch (Exception ex)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine(ex.Message);
                    exists = false;
                    return exists;
                }
            
            return exists;
        }


        private void ResetCommunityToDefault()
        {
            if (CommunityPathExists())
            {
                string dirPath = communityPath;
                DirectoryInfo di = new DirectoryInfo(dirPath);

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                string defaultDir = "skins\\PMDG";
                var allDirectories = Directory.GetDirectories(defaultDir, "*", SearchOption.AllDirectories);
                foreach (string dir in allDirectories)
                {
                    string dirToCreate = dir.Replace(defaultDir, dirPath);
                    Directory.CreateDirectory(dirToCreate);
                }
                var allFiles = Directory.GetFiles(defaultDir, "*.*", SearchOption.AllDirectories);
                foreach (string newPath in allFiles)
                {
                    File.Copy(newPath, newPath.Replace(defaultDir, dirPath), true);
                }
            }
        }

        private void OverWriteCommunity()
        {
            string sourceDir = "skins\\" + liveryTitle;
            string destDir = communityPath;
            var allDirectories = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);
            foreach (string dir in allDirectories)
            {
                string dirToCreate = dir.Replace(sourceDir, destDir);
                Directory.CreateDirectory(dirToCreate);
            }
            var allFiles = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
            foreach (string newPath in allFiles)
            {
                File.Copy(newPath, newPath.Replace(sourceDir, destDir), true);
            }
        }
    }
}
