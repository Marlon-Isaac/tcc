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
using System.Drawing;
using System.IO;


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

            if (tipoUsuario == "Profissional")
            {
                button8.Visible = true;
            }
            else
            {
                button8.Visible = false;
            }
            while (true)
            {
                List<Comentario> comentarios = CarregarComentariosDoBanco();
                ExibirComentarios(comentarios);
            }
        }

        private string ObterTipoUsuario(int usuarioId)
        {
            string tipoUsuario = string.Empty;
            if (usuarioId != 0)
            {
                try
                {
                    Banco banco = new();
                    string conexao = banco.conexao;
                    using SqlConnection conn = new(conexao);
                    conn.Open();

                    string query = "SELECT Tipo FROM Login WHERE Id = @id";
                    using SqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@id", usuarioId);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tipoUsuario = reader["Tipo"]?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        tipoUsuario = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }
            return tipoUsuario;
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

            List<Comentario> comentarios = new(); // Inicializando a lista corretamente
            try
            {
                Banco banco = new();
                string conexaoString = banco.conexao;
                using SqlConnection conn = new(conexaoString);
                conn.Open();
                string query = "SELECT Id, TituloDica, ConteudoDica, FotoDica, AutorDica, Curtidas, Descurtidas FROM Dicas";
                using SqlCommand comando = new(query, conn);
                using SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var comentario = new Comentario
                    {
                        Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                        Titulo = reader["TituloDica"]?.ToString() ?? string.Empty,
                        Conteudo = reader["ConteudoDica"]?.ToString() ?? string.Empty,
                        Autor = reader["AutorDica"]?.ToString() ?? string.Empty,
                        Curtidas = reader["Curtidas"] != DBNull.Value ? Convert.ToInt32(reader["Curtidas"]) : 0,
                        Descurtidas = reader["Descurtidas"] != DBNull.Value ? Convert.ToInt32(reader["Descurtidas"]) : 0,
                        Imagem = reader["FotoDica"] is byte[] imagemBytes
                                  ? Image.FromStream(new MemoryStream(imagemBytes))
                                  : new Bitmap(100, 100) // A imagem padrão de 100x100
                    };
                    comentarios.Add(comentario);
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
            flowLayoutPanel1.Controls.Clear();

            foreach (var comentario in comentarios)
            {
                Panel comentarioPanel = new()
                {
                    Width = flowLayoutPanel1.Width - 25,
                    Height = 180,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                Label tituloLabel = new()
                {
                    Text = comentario.Titulo,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                comentarioPanel.Controls.Add(tituloLabel);

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

                Label autorLabel = new()
                {
                    Text = "Autor: " + comentario.Autor,
                    Font = new Font("Arial", 9, FontStyle.Italic),
                    AutoSize = true,
                    Location = new Point(10, 100)
                };
                comentarioPanel.Controls.Add(autorLabel);

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

                Button likeButton = new()
                {
                    Text = "👍",
                    Location = new Point(10, 130),
                    Width = 30
                };
                likeButton.Click += (s, e) => AtualizarCurtida(comentario, true);
                comentarioPanel.Controls.Add(likeButton);

                Button dislikeButton = new()
                {
                    Text = "👎",
                    Location = new Point(50, 130),
                    Width = 30
                };
                dislikeButton.Click += (s, e) => AtualizarCurtida(comentario, false);
                comentarioPanel.Controls.Add(dislikeButton);

                Label mediaLabel = new()
                {
                    Text = $"Média de aprovação: {(comentario.Curtidas + comentario.Descurtidas > 0 ? (float)comentario.Curtidas / (comentario.Curtidas + comentario.Descurtidas) * 100 : 0):0.0}%",
                    Location = new Point(90, 130),
                    Font = new Font("Arial", 8, FontStyle.Regular),
                    AutoSize = true
                };
                comentarioPanel.Controls.Add(mediaLabel);

                flowLayoutPanel1.Controls.Add(comentarioPanel);
            }
        }

        private void AtualizarCurtida(Comentario comentario, bool isCurtida)
        {
            try
            {
                Banco banco = new();
                string conexaoString = banco.conexao;
                // Defina o usuário logado aqui
                int usuarioLogadoId = SessaoUsuario.UsuarioLogadoId; // Pegando o Id do usuário logado

                using SqlConnection conn = new(conexaoString);
                conn.Open();

                // Verifique se o usuário já votou na dica
                string checkVotoQuery = "SELECT COUNT(*) FROM Votos WHERE UsuarioId = @usuarioId AND DicaId = @dicaId";
                using SqlCommand checkCmd = new(checkVotoQuery, conn);
                checkCmd.Parameters.AddWithValue("@usuarioId", usuarioLogadoId);
                checkCmd.Parameters.AddWithValue("@dicaId", comentario.Id);
                int votoCount = (int)checkCmd.ExecuteScalar();

                if (votoCount > 0)
                {
                    MessageBox.Show("Você já votou nesta dica.");
                    return; // Não insere o voto novamente
                }

                // Se o usuário ainda não votou, insira o voto
                string votoTipo = isCurtida ? "Curtida" : "Descurtida"; // Define o tipo de voto
                string inserirVotoQuery = "INSERT INTO Votos (UsuarioId, DicaId, TipoVoto) VALUES (@usuarioId, @dicaId, @tipoVoto)";
                using SqlCommand inserirCmd = new(inserirVotoQuery, conn);
                inserirCmd.Parameters.AddWithValue("@usuarioId", usuarioLogadoId);
                inserirCmd.Parameters.AddWithValue("@dicaId", comentario.Id); // Usando o Id do comentario
                inserirCmd.Parameters.AddWithValue("@tipoVoto", votoTipo);
                inserirCmd.ExecuteNonQuery();

                // Atualiza a contagem de curtidas ou descurtidas
                string coluna = isCurtida ? "Curtidas" : "Descurtidas";
                string query = $"UPDATE Dicas SET {coluna} = {coluna} + 1 WHERE Id = @dicaId"; // Use Id para atualizar
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@dicaId", comentario.Id);
                cmd.ExecuteNonQuery();

                // Recarregar e exibir os comentários atualizados
                List<Comentario> comentariosAtualizados = CarregarComentariosDoBanco();
                ExibirComentarios(comentariosAtualizados);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar curtida/descurtida: " + ex.Message);
            }
        }




        private bool VerificarVoto(int usuarioId, int dicaId, string tipoVoto)
        {
            try
            {
                Banco banco = new();
                string conexaoString = banco.conexao;
                using SqlConnection conn = new(conexaoString);
                conn.Open();
                string query = "SELECT COUNT(*) FROM Votos WHERE UsuarioId = @usuarioId AND DicaId = @dicaId AND TipoVoto = @tipoVoto";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@dicaId", dicaId);
                cmd.Parameters.AddWithValue("@tipoVoto", tipoVoto);
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Retorna true se o voto já existe
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar voto: " + ex.Message);
                return false;
            }
        }
    }
}
 
