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
    
    public partial class Registro : Form
    {
        byte[] imagem;
        public Registro()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Login form = new();
            form.Show();
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Salva a imagem no MemoryStream no formato desejado (por exemplo, JPEG)
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Converte o MemoryStream em um array de bytes
                return ms.ToArray();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            imagem = ImageToByteArray(pictureBox1.Image);
            var Nome = textBox1.Text;
            var Email = textBox2.Text;
            var senha = textBox3.Text;
            string tipo = comboBox1.SelectedItem.ToString();
            _ = new Validar();

            if (Nome.Length != 0 && Email.Length != 0 && senha.Length != 0 && comboBox1.SelectedIndex != -1)
            {
                if (Validar.ValidarEmail(Email))
                {
                    //string conexao = "Server=tcp:sapae.database.windows.net,1433;Initial Catalog=TCC1;Persist Security Info=False;User ID=sapae;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    Banco banco = new();
                    string conexao = banco.conexao;


                    try
                    {

                        using SqlConnection conn = new(conexao);
                        conn.Open();
                        String query = "INSERT INTO Registro (Nome, Login, Senha, Tipo, Imagem) VALUES (@nome, @login, @senha, @tipo, @imagem)";
                        using SqlCommand cmd = new(query, conn);
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@login", Email);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        SqlParameter imageParameter = cmd.Parameters.Add("@imagem", SqlDbType.VarBinary);
                        imageParameter.Value = (imagem != null) ? imagem : DBNull.Value;
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.ExecuteNonQuery();
                        DialogResult result = MessageBox.Show("Pedido de registro concluido!", "", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            Login form1 = new();
                            form1.Show();
                            this.Close();
                        }
                        conn.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no banco de dados" + ex.Message, "erro", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Email invalido");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os itens", "Erro", MessageBoxButtons.OK);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login form = new();
            form.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Selecione uma imagem";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Carrega a imagem no PictureBox
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                    // Converte a imagem para um array de bytes para salvar no banco de dados
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        imagem = ms.ToArray();
                    }
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
