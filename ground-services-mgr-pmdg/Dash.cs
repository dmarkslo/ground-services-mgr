using ground_services_manager;
using ground_services_mgr_pmdg.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ground_services_mgr_pmdg
{
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
        }

        string communityPath = ""; // get from user input.
        string fileName = "community_path.txt";
        string pathRoot = "\\pmdg-aircraft-737\\SimObjects\\Misc";
        string storagePath = "skins";

        //Notifications 
        Notification notifCommunityPathNotFound = new Notification("Warning", "Community folder path NOT found. Please CLICK HERE to select!", true);
        Notification notifCommunityPathFound = new Notification("Success", "Path to Community folder is VALID. You are ready to go!", false);

        private void Dash_Load(object sender, EventArgs e)
        {
            // Test
           Console.WriteLine(GetAppVersion());

            // Generate a liveryItem for each directory in saved skins folder.
            string[] subdirs = GetDirNames(storagePath);
            foreach (string dir in subdirs)
            {
                Console.Write(dir);
                LiveryItem newLivery = new LiveryItem(dir);
                flowLayoutPanel1.Controls.Add(newLivery);
            }

            // Event Handler for notific click
            notifCommunityPathNotFound.Click += new EventHandler(notif_Click);
            // Add standby notifications to panel
            this.Controls.Add(notifCommunityPathNotFound);
            this.Controls.Add(notifCommunityPathFound);

            // If communityPath is empty, ask user for communityPath input.
            if (!CommunityPathExists())
                notifCommunityPathNotFound.Push();        

        }

        private void notif_Click(object sender, EventArgs e)
        {
            Notification notif = sender as Notification;

            //Show folder browser dialog
            DialogResult result = folderBrowserDialog1.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    communityPath = folderBrowserDialog1.SelectedPath + pathRoot;
                    Console.WriteLine(communityPath); // test
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        outputFile.WriteLine(communityPath);
                    }
                }
                notif.Dispose();
            }
            catch (Exception ex)
            {
                Notification exception = new Notification("Error", ex.Message, false);
                this.Controls.Add(exception);
                exception.Push();
            }

        }
        private void CreatePathSaveFile()
        {
            if (!File.Exists(fileName))
                File.Create(fileName);           
        }

        private bool CommunityPathExists()
        {
            bool exists = false;
            CreatePathSaveFile();
            {
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
            }
            return exists;
        }

        private string[] GetDirNames(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetDirectories(path)
                                .Select(Path.GetFileName)
                                .ToArray();
            }
            else
            {
                return new string[0]; // Empty array
            }
        }
        private string GetAppVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
