using System;
using System.CodeDom;
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
        string nome;
        string login;
        string senha;
        string tipo;
        byte[] imagem;
        int id;
        Banco Banco = new();
        /*private int totalRows; // total de registros na tabela 'registro'
        private int currentRow = 0; // índice do registro atual*/
        public Aceitar()
        {
            InitializeComponent();
            // LoadData();
            A();
        }

        /*   private void LoadData()
           {
               Banco banco = new();
               using (SqlConnection conn = new SqlConnection(banco.conexao))
               {
                   conn.Open();
                   SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM registro", conn);
                   totalRows = (int)cmd.ExecuteScalar();
               }
           }
        */
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

        public void A()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Registro", conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            B();
                        }
                        else
                        {
                            label1.Visible = true;
                            label2.Visible = false;
                            label3.Visible = false;
                            pictureBox1.Visible = false;
                            pictureBox2.Visible = true;
                            button7.Visible = false;
                            button10.Visible = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        public void B()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registro", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["Id"]);
                                nome = reader["Nome"].ToString();
                                login = reader["Login"].ToString();
                                senha = reader["Senha"].ToString();
                                tipo = reader["Tipo"].ToString();
                                imagem = reader["Imagem"] as byte[];

                                pictureBox1.Image = ByteArrayToImage(imagem);
                                pictureBox1.Visible = true;
                                pictureBox2.Visible = false;
                                label3.Text = nome;
                                label3.Visible = true;
                                label1.Visible = false;
                                label2.Visible = true;
                                button10.Visible = true;
                                button7.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Login (Nome, Login, Senha, Tipo, Imagem) VALUES (@nome, @login, @senha, @tipo, @imagem)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@imagem", imagem);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
            A();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            A();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            A();
        }
    }
}
