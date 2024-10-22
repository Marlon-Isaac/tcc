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
    public partial class DicasPost1 : Form
    {
        private string caminhoImagemSelecionada = "";

        public DicasPost1()
        {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string autor = textBox2.Text;
            string conteudo = textBox3.Text;

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(conteudo))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            byte[]? imagemBytes = null;
            if (!string.IsNullOrEmpty(caminhoImagemSelecionada))
            {
                imagemBytes = File.ReadAllBytes(caminhoImagemSelecionada);
            }

            SalvarDicaNoBanco(titulo, autor, conteudo, imagemBytes);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Arquivos de Imagem (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoImagemSelecionada = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(caminhoImagemSelecionada);
            }
        }
        private static void SalvarDicaNoBanco(string titulo, string autor, string conteudo, byte[]? imagemBytes)
        {
            try
            {
                // Cria uma instância da classe banco para obter a string de conexão
                Banco banco = new();
                string conexaoString = banco.conexao;  // Assume que você tenha uma propriedade ou método para obter a string de conexão

                using (SqlConnection conn = new(conexaoString))
                {
                    conn.Open();
                    string query = "INSERT INTO Dicas (TituloDica, AutorDica, ConteudoDica, FotoDica) VALUES (@Titulo, @Autor, @Conteudo, @Imagem)";
                    using SqlCommand comando = new(query, conn);
                    comando.Parameters.AddWithValue("@Titulo", titulo);
                    comando.Parameters.AddWithValue("@Autor", autor);
                    comando.Parameters.AddWithValue("@Conteudo", conteudo);
                    // Verifica se imagemBytes é nulo antes de passar para o comando
                    _ = comando.Parameters.AddWithValue("@Imagem", imagemBytes as object ?? DBNull.Value);
                    comando.ExecuteNonQuery();
                }
                MessageBox.Show("Dica salva com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dica: " + ex.Message);
            }
        }
    }
}

