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
    public partial class Form2 : Form
    {
        int cont=0;
        Random random = new Random();
        Image[] imgs =
        {
            Properties.Resources.adventure_time,
            Properties.Resources.billy_e_mandy,
            Properties.Resources.bambi,
            Properties.Resources.obama,
            Properties.Resources.doraemon,
            Properties.Resources.garfield,
            Properties.Resources.griffin,
            Properties.Resources.spongebob,
            Properties.Resources.spongebob2,
            Properties.Resources.sonic,
            Properties.Resources.shrek,
            Properties.Resources.pika,
            Properties.Resources.phineas,
            Properties.Resources.My_little_pny,
            Properties.Resources.mucca_e_pollo,
            Properties.Resources.miky,
            Properties.Resources.leone,
            Properties.Resources.super_mario,
            Properties.Resources.tom_e_jerry,
            Properties.Resources.topolino,
            Properties.Resources.winnie_the_pooh,
            Properties.Resources.winnie_the_pooh2,
            Properties.Resources.teletabbies,
            Properties.Resources.kermit,

        };

        public Form2()
        {
            InitializeComponent();
            try
            {
                Image crnt = imgs[random.Next(imgs.Length)];
                Bitmap bmp = new Bitmap(crnt);
                int x = bmp.Size.Width;
                int y = bmp.Size.Height;

                this.Size = new System.Drawing.Size(x, y);
                pictureBox1.Image = crnt;

                int x2 = random.Next(0, 1500);
                int y2 = random.Next(0, 1500);
                this.Location = new System.Drawing.Point(x2, y2);
            }
            catch (Exception ex) { }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 f = new Form2();
            f.Text = Form1.RandomText();
            f.Show();

            Form2 f2 = new Form2();
            f2.Text = Form1.RandomText();
            f2.Show();
            cont += 2;
        }
    }
}
