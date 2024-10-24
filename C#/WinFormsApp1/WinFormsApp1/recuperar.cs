using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Recuperar : Form
    {
        public Recuperar()
        {
            InitializeComponent();
        }
        string a;
        string b;
        private void button1_Click(object sender, EventArgs e)
        {
            var email = textBox1.Text;

            if (email.Length != 0)
            {
                //string conexao = "Server=tcp:sapae.database.windows.net,1433;Initial Catalog=TCC1;Persist Security Info=False;User ID=sapae;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                Banco banco = new Banco();
                try
                {
                    using (SqlConnection conn = new SqlConnection(banco.conexao))
                    {
                        conn.Open();
                        String query = "SELECT * FROM Login WHERE Login=@email";
                        Sapae sapae = new Sapae();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@email", email);

                            //int count = Convert.ToInt32(cmd.ExecuteScalar());
                            var result = cmd.ExecuteScalar();
                            int count = result != null ? Convert.ToInt32(result) : 0;

                            if (count != 0 || count != null)
                            {
                                try
                                {
                                    Random random = new Random();
                                    int numeroAleatorio = random.Next(100000, 1000000); // Gera um número de 6 dígitos aleatório
                                    a = Convert.ToString(numeroAleatorio);
                                    var body = "<center><br>Redefinição de senha<br><br>Use este codigo<br><br>" + a + "<br><br>Caso você não tenha pedido redefinição de senha ignore este email</center>";
                                    var gmail = new EnviarEmail("smtp.gmail.com", sapae.gmail, sapae.senha);
                                    gmail.Enviar(email, "Redefinição de senha", body);
                                    b = email;
                                    button1.Visible = false;
                                    button2.Visible = true;
                                    textBox1.Visible = false;
                                    textBox2.Visible = true;
                                    label2.Visible = false;
                                    label3.Visible = true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }


                            else
                            {
                                MessageBox.Show("Email incorreto");
                            }
                        }


                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro no banco de dados " + ex.Message, "erro", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os itens!", "Erro");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codigo = textBox2.Text;
            if (codigo.Length == 6)
            {
                MessageBox.Show(Convert.ToString(b));
                if (codigo == Convert.ToString(a))
                {
                    button2.Visible = false;
                    button3.Visible = true;
                    textBox2.Visible = false;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label3.Visible = false;
                    label4.Visible = true;
                    label5.Visible = true;

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

        private void button3_Click(object sender, EventArgs e)
        {
            string senha = textBox3.Text;
            string senha2 = textBox4.Text;

            if (senha == senha2)
            {
                if (senha.Length >= 6)
                {
                    Banco banco = new Banco();
                    using SqlConnection conn = new SqlConnection(banco.conexao);
                    conn.Open();
                    string query = "UPDATE Login SET Senha = @senha WHERE Login = @Login";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@Login", b);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            DialogResult resul = MessageBox.Show("Senha atualizada com sucesso.", "", MessageBoxButtons.OK);
                            if (resul == DialogResult.OK)
                            {
                                this.Close();
                            }
                            else if (resul == DialogResult.None)
                            {
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
    }
}
