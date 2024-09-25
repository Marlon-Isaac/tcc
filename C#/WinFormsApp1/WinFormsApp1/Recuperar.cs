using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;




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
                banco banco = new banco();
                string conexao = banco.conexao;
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    {
                        string gmail;
                        string senha;
                        conn.Open();
                        String query = "SELECT COUNT(1) FROM Login WHERE email=@Login";
                        string query1 = "SELECT * FROM Gmail";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("email", email);

                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count == 1)
                            {
                                using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                                {
                                    using (SqlDataReader reader = cmd1.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                gmail = reader["Gmail"].ToString();
                                                senha = reader["Senha"].ToString();

                                                Random random = new Random();
                                                aleatorio aleatorio = new aleatorio(random.Next(100000, 1000000));
                                                // Configurações do servidor SMTP
                                                string smtpAddress = gmail; // Endereço do servidor SMTP
                                                int portNumber = 587; // Porta do servidor SMTP (ex: 587 para TLS, 465 para SSL)
                                                bool enableSSL = true; // Habilita ou desabilita SSL

                                                string emailFrom = gmail; // Seu e-mail
                                                string password = senha; // Sua senha de e-mail
                                                string emailTo = email; // E-mail do destinatário
                                                string subject = "Recuperação de senha - NÃO RESPONDA!"; // Assunto do e-mail
                                                string body = "o numero de recuperação é" + aleatorio.b; // Corpo do e-mail

                                                using (MailMessage mail = new MailMessage())
                                                {
                                                    mail.From = new MailAddress(emailFrom);
                                                    mail.To.Add(emailTo);
                                                    mail.Subject = subject;
                                                    mail.Body = body;
                                                    mail.IsBodyHtml = false; // Defina como true se o corpo for em HTML

                                                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                                                    {
                                                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                                                        smtp.EnableSsl = enableSSL;
                                                        try
                                                        {
                                                            smtp.Send(mail);
                                                            MessageBox.Show("E-mail enviado com sucesso!");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show($"Erro ao enviar e-mail: {ex.Message}");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
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
                    MessageBox.Show("Erro no banco de dados" + ex.Message, "erro", MessageBoxButtons.OK);
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
    }
}