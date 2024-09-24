using Microsoft.Win32;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
<<<<<<< HEAD
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
=======
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe

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
<<<<<<< HEAD
            Painelarredondado();


        }
        public void Painelarredondado()
        {
            int borderRadius = 30;
            // Crie um objeto GraphicsPath para desenhar os cantos arredondados
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // Adicione arcos para criar bordas arredondadas
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90); // canto superior esquerdo
            path.AddArc(new Rectangle(panel1.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90); // canto superior direito
            path.AddArc(new Rectangle(panel1.Width - borderRadius, panel1.Height - borderRadius, borderRadius, borderRadius), 0, 90); // canto inferior direito
            path.AddArc(new Rectangle(0, panel1.Height - borderRadius, borderRadius, borderRadius), 90, 90); // canto inferior esquerdo

            // Feche o caminho de desenho
            path.CloseAllFigures();

            // Defina a região do Panel para ter bordas arredondadas
            panel1.Region = new Region(path);
        }
=======

        }

>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
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
<<<<<<< HEAD

            if (login.Length != 0 && senha.Length != 0)
=======
            var tipo = comboBox1.SelectedItem.ToString();
            if (login.Length != 0 && senha.Length != 0 && comboBox1.SelectedIndex != -1)
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            {
                //string conexao = "Server=tcp:sapae.database.windows.net,1433;Initial Catalog=TCC1;Persist Security Info=False;User ID=sapae;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TCC;Integrated Security=True;Connect Timeout=30;Encrypt=False";
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    {
                        conn.Open();
<<<<<<< HEAD
                        String query = "SELECT COUNT(1) FROM Login WHERE email=@login AND Senha=@senha";
=======
                        String query = "SELECT COUNT(1) FROM Login WHERE email=@login AND Senha=@senha AND Tipo=@tipo";
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.Parameters.AddWithValue("@senha", senha);
<<<<<<< HEAD

                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count == 1)
                            {
                                
=======
                            cmd.Parameters.AddWithValue("@tipo", tipo);

                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count == 1) {
                                MessageBox.Show("bem vindo");
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
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
<<<<<<< HEAD
                    MessageBox.Show("Erro no banco de dados" + ex.Message, "erro", MessageBoxButtons.OK);
=======
                    MessageBox.Show("Erro no banco de dados"+ ex.Message, "erro", MessageBoxButtons.OK );
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
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

<<<<<<< HEAD
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            recuperar recuperar = new recuperar();
            recuperar.Show();
        }

        private void panel1_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();
        }
=======
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
    }
}
