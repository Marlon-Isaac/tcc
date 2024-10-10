using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class perfil : Form
    {
        public perfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            perfil perfilForm = new perfil();
            perfilForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void perfil_Load(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(pictureBox1.Image);
            Bitmap circleImage = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(circleImage))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, circleImage.Width, circleImage.Height);

                g.SetClip(path);
                g.DrawImage(originalImage, 0, 0);

                pictureBox1.Image = circleImage;

               
            }
        }
    }
    }
