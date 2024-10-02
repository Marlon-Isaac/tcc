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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Nome = textBox1.Text;
            var Email = textBox2.Text;
            var senha = textBox3.Text;
            var tipo = comboBox1.SelectedItem.ToString();
            validar validar = new validar();

            if (Nome.Length != 0 && Email.Length != 0 && senha.Length != 0 && comboBox1.SelectedIndex != -1)
            {
                if (validar.ValidarEmail(Email))
                {
                    //string conexao = "Server=tcp:sapae.database.windows.net,1433;Initial Catalog=TCC1;Persist Security Info=False;User ID=sapae;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    banco banco = new banco();
                    string conexao = banco.conexao;


                    try
                    {

                        using (SqlConnection conn = new SqlConnection(conexao))
                        {
                            conn.Open();
                            String query = "INSERT INTO Registro (Nome, Login, Senha, Tipo) VALUES (@nome, @login, @senha, @tipo)";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@nome", Nome);
                                cmd.Parameters.AddWithValue("@login", Email);
                                cmd.Parameters.AddWithValue("@senha", senha);
                                cmd.Parameters.AddWithValue("@tipo", tipo);
                                cmd.ExecuteNonQuery();
                                DialogResult result = MessageBox.Show("Pedido de registro concluido!", "", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    Form1 form1 = new Form1();
                                    form1.Show();
                                    this.Close();
                                }
                                conn.Close();

                            }


                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no banco de dados" + ex.Message, "erro", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Email invalido");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os itens", "Erro", MessageBoxButtons.OK);
            }
        }
            
        
    }
}
