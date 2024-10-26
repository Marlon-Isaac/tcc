using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        private void Button8_Click(object sender, EventArgs e) { }

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
            Login login = new();
            login.Show();
            this.Close();
        }

        private void DicasPost_Load(object sender, EventArgs e)
        {
            int usuarioLogadoId = SessaoUsuario.UsuarioLogadoId;
            string tipoUsuario = ObterTipoUsuario(usuarioLogadoId);

            // Condição para mostrar ou ocultar o botão com base no tipo de usuário
            if (tipoUsuario == "Profissional")
            {
                button8.Visible = true; // Oculta o botão se o usuário for Profissional
            }
            else
            {
                button8.Visible = false; // Mostra o botão para outros tipos de usuários
            }

            List<Comentario> comentarios = CarregarComentariosDoBanco();
            ExibirComentarios(comentarios);
        }

        private string ObterTipoUsuario(int usuarioId)
        {
            // Inicializa tipoUsuario como vazio para evitar referências nulas
            string tipoUsuario = string.Empty;

            if (usuarioId != 0)
            {
                try
                {
                    // Sua string de conexão
                    Banco banco = new();
                    string conexao = banco.conexao;

                    using SqlConnection conn = new(conexao);
                    conn.Open();

                    // Consulta SQL para buscar o tipo do usuário
                    string query = "SELECT Tipo FROM Login WHERE Id = @id";
                    using SqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@id", usuarioId);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tipoUsuario = reader["Tipo"]?.ToString() ?? string.Empty; // Retorna vazio se nulo
                    }
                    else
                    {
                        // Caso não encontre nenhum resultado, mantenha tipoUsuario como vazio
                        tipoUsuario = string.Empty; // Ou você pode definir um tipo padrão, se necessário
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }

            return tipoUsuario; // Retorna o tipo do usuário (ou vazio)
        }

        private void Button8_Click_1(object sender, EventArgs e)
        {
            DicasPost1 dicaspost = new();
            dicaspost.Show();
            this.Show();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e) { }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private static List<Comentario> CarregarComentariosDoBanco()
        {
            List<Comentario> comentarios = new();
            try
            {
                Banco banco = new();
                string conexaoString = banco.conexao;
                using SqlConnection conn = new(conexaoString);
                conn.Open();
                // Adicione o autor à consulta SQL
                string query = "SELECT TituloDica, ConteudoDica, FotoDica, AutorDica FROM Dicas";
                using SqlCommand comando = new(query, conn);
                using SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    // Inicializa as variáveis com valores padrão
                    string titulo = reader["TituloDica"]?.ToString() ?? string.Empty;
                    string conteudo = reader["ConteudoDica"]?.ToString() ?? string.Empty;
                    string autor = reader["AutorDica"]?.ToString() ?? string.Empty; // Obter o autor
                    Image? imagem = null;
                    // Converte imagem, se existir
                    if (reader["FotoDica"] is byte[] imagemBytes)
                    {
                        using MemoryStream ms = new(imagemBytes);
                        imagem = Image.FromStream(ms);
                    }
                    // Adiciona o comentário à lista
                    comentarios.Add(new Comentario
                    {
                        Titulo = titulo,
                        Conteudo = conteudo,
                        Autor = autor, // Armazenar o autor
                        Imagem = imagem ?? new Bitmap(1, 1)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar comentários: " + ex.Message);
            }
            return comentarios;
        }


        private void ExibirComentarios(List<Comentario> comentarios)
        {
            flowLayoutPanel1.Controls.Clear(); // Limpa os comentários antigos
            foreach (var comentario in comentarios)
            {
                // Cria um painel para cada comentário
                Panel comentarioPanel = new()
                {
                    Width = flowLayoutPanel1.Width - 25,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };
                // Título
                Label tituloLabel = new()
                {
                    Text = comentario.Titulo,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                comentarioPanel.Controls.Add(tituloLabel);
                // Conteúdo
                Label conteudoLabel = new()
                {
                    Text = comentario.Conteudo,
                    Font = new Font("Arial", 10),
                    AutoSize = false,
                    Width = comentarioPanel.Width - 120,
                    Height = 60,
                    Location = new Point(10, 40),
                    TextAlign = ContentAlignment.TopLeft
                };
                comentarioPanel.Controls.Add(conteudoLabel);
                // Autor
                Label autorLabel = new()
                {
                    Text = "Autor: " + comentario.Autor, // Exibir autor
                    Font = new Font("Arial", 9, FontStyle.Italic),
                    AutoSize = true,
                    Location = new Point(10, 100) // Posição do autor
                };
                comentarioPanel.Controls.Add(autorLabel);
                // Imagem (se houver)
                if (comentario.Imagem != null)
                {
                    PictureBox pictureBox = new()
                    {
                        Image = comentario.Imagem,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(comentarioPanel.Width - 110, 10),
                        Size = new Size(100, 100)
                    };
                    comentarioPanel.Controls.Add(pictureBox);
                }
                // Adiciona o painel com o comentário no FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(comentarioPanel);
            }
        }
    }
}
