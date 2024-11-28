using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
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
            string a = tipo.TipoUsuario;
            if (a == "Secretaria")
            {
                panelGeral.Visible = false;
                panelSecretaria.Visible = true;
            }
            else
            {
                panelGeral.Visible = true;
                panelSecretaria.Visible = false;
            }
            Banco banco = new();
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
                // Desativar o AutoScroll do Panel3
                panel3.AutoScroll = false;

                int yPosition = 10; // Posição vertical inicial
                ToolTip toolTip = new(); // Criar um ToolTip para mostrar o comentário completo

                // Definir a fonte de 7px (fora do loop, pois é a mesma para todos os labels)
                Font smallFont = new Font("Arial", 7);

                while (reader.Read())
                {
                    string nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? "Nome não disponível" : reader["Nome"].ToString();
                    string email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "Email não disponível" : reader["Email"].ToString();
                    string comentario = reader.IsDBNull(reader.GetOrdinal("Comentario")) ? "Sem comentário" : reader["Comentario"].ToString();

                    // Abreviar o comentário se ele for maior que um certo número de caracteres
                    string comentarioExibido = comentario.Length > 30 ? string.Concat(comentario.AsSpan(0, 30), "...") : comentario;

                    // Tamanho máximo permitido para os labels (por exemplo, 300px de largura)
                    Size maximumLabelSize = new Size(300, 0);

                    // Labels para Nome, Email e Comentário com fonte reduzida e limite de largura
                    Label labelNome = new()
                    {
                        Text = $"Nome: {nome}",
                        Font = smallFont, // Aplicar a fonte de 7px
                        Location = new Point(10, yPosition),
                        AutoSize = true,
                        MaximumSize = maximumLabelSize // Definir o tamanho máximo antes de quebrar linha
                    };

                    Label labelEmail = new()
                    {
                        Text = $"Email: {email}",
                        Font = smallFont, // Aplicar a fonte de 7px
                        Location = new Point(10, yPosition + 20), // Colocar logo abaixo do nome
                        AutoSize = true,
                        MaximumSize = maximumLabelSize // Definir o tamanho máximo antes de quebrar linha
                    };

                    Label labelComentario = new()
                    {
                        Text = $"Comentário: {comentarioExibido}",
                        Font = smallFont, // Aplicar a fonte de 7px
                        Location = new Point(10, yPosition + 40), // Colocar abaixo do email
                        AutoSize = true,
                        MaximumSize = maximumLabelSize // Definir o tamanho máximo antes de quebrar linha
                    };

                    // Adicionar um ToolTip ao label do comentário
                    toolTip.SetToolTip(labelComentario, comentario); // Exibir o comentário completo no ToolTip

                    // Adicionar os labels ao painel
                    panel3.Controls.Add(labelNome);
                    panel3.Controls.Add(labelEmail);
                    panel3.Controls.Add(labelComentario);

                    // Incrementar a posição vertical para o próximo conjunto de Labels
                    yPosition += 100; // Incremento suficiente para deixar espaço entre os conjuntos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<string> Notificacoes = carregar();
        }
        private static List<Notificacao> carregar()
        {
            List<Notificacao> notificacoes = new();
            try
            {
                Banco banco = new Banco();
                using (SqlConnection conn = new(banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM notificacoes WHERE Usuario = @tipo", conn))
                    {
                        if (tipo.TipoUsuario == "Secretaria")
                        {
                            cmd.Parameters.AddWithValue("@tipo", "Secretaria");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@tipo", "Geral");
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var notificacoes = new Notificacao
                                {
                                    texto = reader["Notificacao"].ToString(),
                                    data = reader["data"].ToString()
                                };

                                
                            }
                            
                        }
                    }
                    return notificacoes;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }


        }
        private void exibir(List<Notificacao> notificacoes)
        {

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
            Sugestions sug = new();
            sug.Show();


        }



        private void Button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new();
            homeForm.Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Perfil perfilForm = new();
            perfilForm.Show();
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DicasPost dicasPostForm = new();
            dicasPostForm.Show();
            this.Close();
        }





        private void button4_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();
            agenda.Show();
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil();
            perfil.Show();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Aceitar aceitar1 = new Aceitar();
            aceitar1.Show(); this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Agenda agenda1 = new Agenda();
            agenda1.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show(); this.Close();
            this.Close();
        }
    }
}
