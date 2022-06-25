using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityForm
{
    public partial class Form1 : Form
    {
        static Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0;
            Form2 f = new Form2();
            f.Text = "yOU";
            f.Show();

            Form2 f1 = new Form2();
            f1.Text = "cANT";
            f1.Show();

            Form2 f2 = new Form2();
            f2.Text = "cLOSE";
            f2.Show();

            Form2 f3 = new Form2();
            f3.Text = "mE";
            f3.Show();

            Form2 f4 = new Form2();
            f4.Text = ":)";
            f4.Show();
        }


        public static string RandomText()
        {
            string alphabet = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#[]ùàòè+é*ç°§-_.;:;ì'^?=)(/&%$£!\|";
            string newString = "";
            for (int i = 0; i < 1000; i++)
            {
                newString += alphabet[random.Next(0, alphabet.Length)];
            }
            return newString;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool success = false;
            if (!success)
                e.Cancel = true;
        }
    }
}
