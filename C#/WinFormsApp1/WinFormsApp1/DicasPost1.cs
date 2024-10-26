using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            // Lógica opcional para manipulação de DataTimePicker
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string autor = textBox2.Text;
            string conteudo = textBox3.Text;

            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(conteudo))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Verifica se uma imagem foi selecionada
            if (string.IsNullOrEmpty(caminhoImagemSelecionada))
            {
                MessageBox.Show("Por favor, selecione uma imagem para enviar.");
                return; // Não prossegue para salvar se a imagem não foi selecionada
            }

            // Lê a imagem em bytes
            byte[] imagemBytes = File.ReadAllBytes(caminhoImagemSelecionada);
            SalvarDicaNoBanco(titulo, autor, conteudo, imagemBytes);

            this.Close();
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

                    // Define o parâmetro de imagem de forma explícita
                    if (imagemBytes != null)
                    {
                        // Se houver imagem, passa como byte array
                        SqlParameter imagemParam = new SqlParameter("@Imagem", SqlDbType.VarBinary, -1) // -1 para indicar VARBINARY(MAX)
                        {
                            Value = imagemBytes
                        };
                        comando.Parameters.Add(imagemParam);
                    }
                    else
                    {
                        // Se não houver imagem, passa DBNull.Value
                        comando.Parameters.AddWithValue("@Imagem", DBNull.Value);
                    }

                    comando.ExecuteNonQuery();
                }
                MessageBox.Show("Dica salva com sucesso!, Por favor, Atualize a pagina!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dica: " + ex.Message);
            }
        }


    }
}
