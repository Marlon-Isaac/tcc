using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{

    public partial class Aceitar : Form
    {
        Banco Banco = new();
        private int totalRows; // total de registros na tabela 'registro'
        private int currentRow = 0; // índice do registro atual
        public Aceitar()
        {
            InitializeComponent();
            LoadData();
            CreateControls();
        }

        private void LoadData()
        {
            Banco banco = new();
            using (SqlConnection conn = new SqlConnection(banco.conexao))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM registro", conn);
                totalRows = (int)cmd.ExecuteScalar();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                throw new ArgumentException("O array de bytes está vazio ou nulo.");
            }

            try
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    // Garante que o ponteiro do MemoryStream está no início
                    ms.Seek(0, SeekOrigin.Begin);
                    return Image.FromStream(ms, true); // Opcional: `true` para validar dados
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Não foi possível converter o array de bytes para uma imagem. Verifique se o array de bytes contém uma imagem válida.", ex);
            }
        }

        private void CreateControls()
        {
            if (currentRow >= totalRows) {
                label1.Visible = true;
            }; // Se não há mais registros

            using (SqlConnection conn = new SqlConnection(Banco.conexao))
            {
                label1.Visible = false;
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    $"SELECT Id, Nome, Login, Senha, Tipo, Imagem FROM registro ORDER BY ID OFFSET {currentRow} ROWS FETCH NEXT 1 ROWS ONLY", conn
                );
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string id = reader["Id"].ToString();
                    string nome = reader["Nome"].ToString();
                    string login = reader["Login"].ToString();
                    string senha = reader["Senha"].ToString();
                    string tipo = reader["Tipo"].ToString();
                    byte[] imagem = reader["Imagem"] as byte[];

                    // Converte a imagem do banco de dados em um array de bytes



                    // Cria a PictureBox para exibir a imagem
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = ByteArrayToImage(imagem),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 1000,  // Defina a largura desejada
                        Height = 1000, // Defina a altura desejada
                        Top = 10,
                        Left = (panel2.Width - 40) / 2, // Centraliza a imagem no painel                    
                    };
                    panel2.Controls.Add(pictureBox);

                    // Cria o label para o nome
                    Label nameLabel = new Label
                    {
                        Text = nome,
                        Left = (panel2.Width - 100) / 2, // Centraliza o nome no painel
                        Top = pictureBox.Bottom + 10, // Abaixo da imagem
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("ComicSans", 15, FontStyle.Regular)
                    };
                    panel2.Controls.Add(nameLabel);

                    // Botão Aceitar
                    Button btnAccept = new Button
                    {
                        Text = "Aceitar",
                        Left = (panel2.Width - 150), // Centraliza no painel
                        Top = nameLabel.Bottom + 10,
                        Width = 70,
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(40, 50, 58)
                    };
                    btnAccept.Click += (sender, e) => HandleButtonClick(id, nome, login, senha, tipo, imagem, true);
                    panel2.Controls.Add(btnAccept);

                    // Botão Rejeitar
                    Button btnReject = new Button
                    {
                        Text = "Rejeitar",
                        Left = (panel2.Width - 70), // Centraliza no painel
                        Top = nameLabel.Bottom + 10,
                        Width = 70,
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(40, 50, 58)
                    };
                    btnReject.Click += (sender, e) => HandleButtonClick(id, nome, login, senha, tipo, imagem, false);
                    panel2.Controls.Add(btnReject);
                }
            }
        }

        private void HandleButtonClick(string id, string nome, string login, string senha, string tipo, byte[] imageBytes, bool accepted)
        {
            if (accepted)
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO login (Nome, Login, Senha, Tipo, Imagem) VALUES (@nome, @login, @senha, @tipo, @imagem)", conn
                    );
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@tipo", tipo);

                    // Adiciona a imagem como parâmetro, ou como DBNull.Value se não houver imagem
                    SqlParameter imageParameter = cmd.Parameters.Add("@imagem", SqlDbType.VarBinary);
                    imageParameter.Value = (imageBytes != null) ? imageBytes : (object)DBNull.Value;

                    cmd.ExecuteNonQuery();
                }

                using (SqlConnection conn = new(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else if (!accepted)
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Remove os controles atuais
            panel2.Controls.Clear();
            currentRow++;

            // Recria os próximos controles
            CreateControls();
        }

        private void Secretaria_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new();
            homeForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Perfil perfilForm = new();
            perfilForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login login = new();
            login.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
