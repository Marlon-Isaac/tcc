using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DicasPost : Form
    {
        public DicasPost()
        {
            InitializeComponent();
        }

        private void Button8_Click(object sender, EventArgs e)
        {

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

        private void Button3_Click(object sender, EventArgs e)
        {
            DicasPost dicasPostForm = new();
            dicasPostForm.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário Login está aberto
            foreach (Form form in Application.OpenForms)
            {
                if (form is Login loginForm)
                {
                    loginForm.FecharLogin();  // Chama o método para fechar o Login
                    break;
                }
            }
        }



        private void DicasPost_Load(object sender, EventArgs e)
        {

        }

        private void Button8_Click_1(object sender, EventArgs e)
        {

        }
    }
}
