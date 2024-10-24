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

                            /*if (count != 0 || count != null)
                            {
                                try
                                {
                                    Random random = new Random();2atorio.a + "<br><br>Caso você não tenha pedido redefinição de senha ignore este email</center>";
                                    var gmail = new EnviarEmail("smtp.gmail.com", sapae.gmail, sapae.senha);
                                    gmail.Enviar(email, "Redefinição de senha", body);
                                    //aleatorio.b = email;
                                    //Confirmar confirmar = new Confirmar();
                                    //confirmar.Show();
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }


                            else
                            {
                                MessageBox.Show("Email incorreto");
                            }*/
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
    }
}
