using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Confirmar : Form
    {
        public Confirmar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;
            if (codigo.Length == 6)
            {
                Aleatorio aleatorio = new Aleatorio();
                if (codigo == Convert.ToString(aleatorio.a))
                {
                    Recuperar2 recuperar2 = new Recuperar2();
                    recuperar2.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Codigo errado", "Erro", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Codigo invalido", "Erro", MessageBoxButtons.OK);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
