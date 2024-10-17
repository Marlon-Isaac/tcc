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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ArredondarBordasPanel4(); // Chame o método para arredondar bordas do panel4


            banco banco = new();
            string conexaoString = banco.conexao;

            try
            {
                using SqlConnection conn = new(conexaoString);
                conn.Open();
                string query = "SELECT Nome, Email, Telefone, Comentario FROM SugestoesReclamacoes";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                // Limpar o conteúdo atual do Panel3
                panel3.Controls.Clear();

                // Habilitar o AutoScroll para o Panel3
                panel3.AutoScroll = true;

                int yPosition = 10; // Posição vertical inicial

                while (reader.Read())
                {
                    string? nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? "Nome não disponível" : reader["Nome"].ToString();
                    string? email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "Email não disponível" : reader["Email"].ToString();
                    string? comentario = reader.IsDBNull(reader.GetOrdinal("Comentario")) ? "Sem comentário" : reader["Comentario"].ToString();

                    Label labelNome = new()
                    {
                        Text = $"Nome: {nome}",
                        AutoSize = true,
                        Location = new Point(10, yPosition)
                    };

                    Label labelEmail = new()
                    {
                        Text = $"Email: {email}",
                        AutoSize = true,
                        Location = new Point(10, yPosition + 20)
                    };

                    Label labelComentario = new()
                    {
                        Text = $"Comentário: {comentario}",
                        AutoSize = true,
                        Location = new Point(10, yPosition + 60)
                    };

                    panel3.Controls.Add(labelNome);
                    panel3.Controls.Add(labelEmail);
                    panel3.Controls.Add(labelComentario);

                    // Incrementar a posição vertical para o próximo conjunto de Labels
                    yPosition += 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void ArredondarBordasPanel4()
        {
            int borderRadius = 30; // Defina o raio da borda
            System.Drawing.Drawing2D.GraphicsPath path = new();

            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90); // canto superior esquerdo
            path.AddArc(new Rectangle(panel4.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90); // canto superior direito
            path.AddArc(new Rectangle(panel4.Width - borderRadius, panel4.Height - borderRadius, borderRadius, borderRadius), 0, 90); // canto inferior direito
            path.AddArc(new Rectangle(0, panel4.Height - borderRadius, borderRadius, borderRadius), 90, 90); // canto inferior esquerdo

            path.CloseAllFigures();

            panel4.Region = new Region(path); // Aplique a região ao panel4
        }



        private void Button8_Click(object sender, EventArgs e)
        {
            sugestions sug = new();
            sug.Show();


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

        private void Button7_Click(object sender, EventArgs e)
        {

        }
    }
}
