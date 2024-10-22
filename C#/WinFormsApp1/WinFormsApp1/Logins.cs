using Microsoft.Win32;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp1
{
    public partial class Logins : Form
    {
        public Logins()
        {
            InitializeComponent();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Painelarredondado();
        }

        public void Painelarredondado()
        {
            int borderRadius = 30;
            System.Drawing.Drawing2D.GraphicsPath path = new();
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90); // canto superior esquerdo
            path.AddArc(new Rectangle(panel1.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90); // canto superior direito
            path.AddArc(new Rectangle(panel1.Width - borderRadius, panel1.Height - borderRadius, borderRadius, borderRadius), 0, 90); // canto inferior direito
            path.AddArc(new Rectangle(0, panel1.Height - borderRadius, borderRadius, borderRadius), 90, 90); // canto inferior esquerdo

            path.CloseAllFigures();
            panel1.Region = new Region(path);
        }






        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var senha = textBox2.Text;
            bool senharesul;
            if (login.Length != 0 && senha.Length != 0)
            {
                Banco banco = new();
                string conexao = banco.conexao;
                try
                {
                    using SqlConnection conn = new(conexao);
                    conn.Open();
                    String query = "SELECT COUNT(1) FROM Login WHERE Login = @login AND Senha = @senha";
                    using SqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Bem vindo");

                        Home homeForm = new();
                        homeForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("login incorreto");
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Registro registro = new();
            registro.Show();
            this.Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {
            Recuperar recuperar = new();
            recuperar.Show();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
