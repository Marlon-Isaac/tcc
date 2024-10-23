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
    public partial class Recuperar2 : Form
    {
        public Recuperar2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string senha = textBox1.Text;
            string senha2 = textBox2.Text;

            if (senha == senha2)
            {
                if(senha.Length >= 6)
                {
                    Banco banco = new Banco();
                    using SqlConnection conn = new SqlConnection(banco.conexao);
                    conn.Open();
                    Aleatorio aleatorio = new Aleatorio();
                    string query = "UPDATE Usuarios SET Senha = @senha WHERE Login = @Login";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@Login", aleatorio.b);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            DialogResult resul = MessageBox.Show("Senha atualizada com sucesso.", "", MessageBoxButtons.OK);
                            if(resul == DialogResult.OK)
                            {
                                aleatorio.b = null;
                                this.Close();
                            }
                            else if (resul == DialogResult.None)
                            {
                                aleatorio.b = null;
                                this.Close();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Erro ao atualizar a senha.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Senha muito insegura"); 
                }
            }
            else
            {
                MessageBox.Show("As duas senhas não estão iguais");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
