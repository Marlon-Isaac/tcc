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
            bool senharesul;
            if (login.Length != 0 && senha.Length != 0)
            {
                banco banco = new banco();
                // string conexao = "Server=tcp:sapae.database.windows.net,1433;Initial Catalog=TCC1;Persist Security Info=False;User ID=sapae;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string conexao = banco.conexao;
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexao))
                    {
                        conn.Open();
                        String query = "SELECT COUNT(1) FROM Login WHERE Login = @login AND Senha = @senha";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.Parameters.AddWithValue("@senha", senha);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count == 1)
                            {
                                MessageBox.Show("Bem vindo");

                                Home homeForm = new Home();
                                homeForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("login incorreto");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no banco de dados" + ex.Message, "erro", MessageBoxButtons.OK);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            recuperar recuperar = new recuperar();
            recuperar.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
