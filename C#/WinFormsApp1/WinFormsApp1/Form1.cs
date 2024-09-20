using Microsoft.Win32;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var senha = textBox2.Text;
            var tipo = comboBox1.SelectedItem.ToString();
            if (login.Length != 0 && senha.Length != 0 && comboBox1.SelectedIndex != -1)
            {
                //string conexao = "Server=tcp:sapae.database.windows.net,1433;Initial Catalog=TCC1;Persist Security Info=False;User ID=sapae;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TCC;Integrated Security=True;Connect Timeout=30;Encrypt=False";
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    {
                        conn.Open();
                        String query = "SELECT COUNT(1) FROM Login WHERE email=@login AND Senha=@senha AND Tipo=@tipo";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.Parameters.AddWithValue("@senha", senha);
                            cmd.Parameters.AddWithValue("@tipo", tipo);

                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count == 1) {
                                MessageBox.Show("bem vindo");
                            }
                            else
                            {
                                MessageBox.Show("login ou senha incorreto");
                            }
                        }


                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro no banco de dados"+ ex.Message, "erro", MessageBoxButtons.OK );
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os itens", "Erro", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
