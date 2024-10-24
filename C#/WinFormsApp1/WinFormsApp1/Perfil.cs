using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoImagem = openFileDialog.FileName;

                // Exibir a imagem selecionada no PictureBox
                pictureBox1.Image = Image.FromFile(caminhoImagem);

                // Salvar a imagem no banco de dados
                int usuarioLogadoId = SessaoUsuario.UsuarioLogadoId;
                SalvarImagemNoBanco(caminhoImagem, usuarioLogadoId);
            }
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            using Bitmap originalImage = new(pictureBox1.Image);
            Bitmap circleImage = new(originalImage.Width, originalImage.Height);

            using Graphics g = Graphics.FromImage(circleImage);
            GraphicsPath path = new();
            path.AddEllipse(0, 0, circleImage.Width, circleImage.Height);

            g.SetClip(path);
            g.DrawImage(originalImage, 0, 0);

            pictureBox1.Image = circleImage;

            // Carregar informações do usuário logado
            CarregarInformacoesUsuario();

            // Carregar imagem de perfil do banco
            int usuarioLogadoId = SessaoUsuario.UsuarioLogadoId;
            if (usuarioLogadoId != 0)
            {
                CarregarImagemDoBanco(usuarioLogadoId);
            }
        }

        private void CarregarInformacoesUsuario()
        {
            // ID do usuário logado armazenado na sessão
            int usuarioLogadoId = SessaoUsuario.UsuarioLogadoId;

            if (usuarioLogadoId != 0)
            {
                try
                {
                    // Sua string de conexão
                    Banco banco = new();
                    string conexao = banco.conexao;

                    using SqlConnection conn = new(conexao);
                    conn.Open();

                    // Consulta SQL para buscar Nome, Email (Login) e Tipo do usuário
                    string query = "SELECT Nome, Login AS Email, Tipo FROM Login WHERE Id = @id";

                    using SqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@id", usuarioLogadoId);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Preencher as labels com as informações do banco de dados
                        label6.Text = reader["Nome"].ToString();
                        label7.Text = reader["Email"].ToString();
                        label5.Text = reader["Tipo"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível carregar os dados do perfil.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ID do usuário não encontrado.");
            }
        }

        private static void SalvarImagemNoBanco(string caminhoImagem, int idUsuario)
        {
            try
            {
                // Usando a classe banco para obter a string de conexão
                Banco banco = new();
                string conexao = banco.conexao;

                // Conectando ao banco de dados com a string de conexão
                using (SqlConnection conexaoDb = new(conexao))
                {
                    conexaoDb.Open();

                    // Lendo a imagem do caminho especificado
                    byte[] imagemBytes = File.ReadAllBytes(caminhoImagem);

                    // Query para inserir ou atualizar a imagem na tabela
                    string query = "UPDATE Login SET Imagem = @Imagem WHERE Id = @UsuarioId";

                    using SqlCommand comando = new(query, conexaoDb);
                    comando.Parameters.AddWithValue("@Imagem", imagemBytes);
                    comando.Parameters.AddWithValue("@UsuarioId", idUsuario);

                    comando.ExecuteNonQuery();
                }
                MessageBox.Show("Imagem salva com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar imagem: " + ex.Message);
            }
        }

        private void CarregarImagemDoBanco(int idUsuario)
        {
            try
            {
                // Usando a classe banco para obter a string de conexão
                Banco banco = new();
                string conexao = banco.conexao;

                // Conectando ao banco de dados com a string de conexão obtida da classe banco
                using SqlConnection conexaoDb = new(conexao);
                conexaoDb.Open();

                // Query para selecionar a imagem do banco
                string query = "SELECT Imagem FROM Login WHERE Id = @UsuarioId";

                using SqlCommand comando = new(query, conexaoDb);
                comando.Parameters.AddWithValue("@UsuarioId", idUsuario);

                using SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Imagem"] is byte[] imagemBytes)
                    {
                        using MemoryStream ms = new(imagemBytes);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma imagem encontrada para este usuário.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário Login está aberto
            foreach (Form form in Application.OpenForms)
            {
                if (form is Login loginForm)
                {
                    loginForm.FecharLogin();  // Chama o método para fechar o Login
                    break;
                }
            }
        }
    }
}
