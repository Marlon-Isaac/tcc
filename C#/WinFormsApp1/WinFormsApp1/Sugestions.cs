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
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Sugestions : Form
    {
        public Sugestions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string telefone = textBox3.Text;
            string comentario = textBox4.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) ||
               string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(comentario))
            {
                MessageBox.Show("Preencha todos os campos antes de enviar.", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (!IsEmailValido(email))
            {
                MessageBox.Show("E-mail inválido. Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (!IsTelefoneValido(telefone))
            {
                MessageBox.Show("Telefone inválido. Por favor, insira um número de telefone válido.", "Erro", MessageBoxButtons.OK);
                return;
            }

            Banco banco = new();
            string conexaoString = banco.conexao;

            try
            {
                using (SqlConnection conn = new(conexaoString))
                {
                    conn.Open();

                    // Inserir os dados na tabela SugestoesReclamacoes
                    string query = "INSERT INTO SugestoesReclamacoes (Nome, Email, Telefone, Comentario) VALUES (@Nome, @Email, @Telefone, @Comentario)";

                    using (SqlCommand cmd = new(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@Comentario", comentario);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Sugestão/Reclamação enviada com sucesso!", "Sucesso", MessageBoxButtons.OK);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar a sugestão/reclamação: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void sugestions_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsEmailValido(string email)
        {
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private bool IsTelefoneValido(string telefone)
        {
            string padraoTelefone = @"^\d{10,11}$"; // Aceita 10 ou 11 dígitos
            return Regex.IsMatch(telefone, padraoTelefone);
        }
    }
}
