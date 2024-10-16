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
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new();
            homeForm.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Perfil perfilForm = new();
            perfilForm.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            using Bitmap originalImage = new(pictureBox1.Image);
            Bitmap circleImage = new(originalImage.Width, originalImage.Height);

            using Graphics g = Graphics.FromImage(circleImage);
            GraphicsPath path = new();
            path.AddEllipse(0, 0, circleImage.Width, circleImage.Height);

            g.SetClip(path);
            g.DrawImage(originalImage, 0, 0);

            pictureBox1.Image = circleImage;
        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }
    }
}
