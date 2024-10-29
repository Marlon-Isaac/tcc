using Microsoft.Win32;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Painelarredondado();

            int borderRadius = 30;

            // Botão 1
            GraphicsPath path1 = new GraphicsPath();
            path1.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path1.AddArc(new Rectangle(button1.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path1.AddArc(new Rectangle(button1.Width - borderRadius, button1.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path1.AddArc(new Rectangle(0, button1.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path1.CloseFigure();
            button1.Region = new Region(path1);

            // Botão 2
            GraphicsPath path2 = new GraphicsPath();
            path2.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path2.AddArc(new Rectangle(button2.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path2.AddArc(new Rectangle(button2.Width - borderRadius, button2.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path2.AddArc(new Rectangle(0, button2.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path2.CloseFigure();
            button2.Region = new Region(path2);
        }

        public void FecharLogin()
        {
            this.Close();
        }

        public void Painelarredondado()
        {
            int borderRadius = 30;
            System.Drawing.Drawing2D.GraphicsPath path = new();
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path.AddArc(new Rectangle(panel1.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path.AddArc(new Rectangle(panel1.Width - borderRadius, panel1.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path.AddArc(new Rectangle(0, panel1.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path.CloseAllFigures();
            panel1.Region = new Region(path);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var senha = textBox2.Text;

            if (login.Length != 0 && senha.Length != 0)
            {
                Banco banco = new Banco();
                string conexao = banco.conexao;

                try
                {
                    using SqlConnection conn = new(conexao);
                    conn.Open();

                    // Consulta para verificar o login e obter o ID do usuário, Nome e Tipo
                    string query = "SELECT Id, Nome, Tipo FROM Login WHERE Login = @login AND Senha = @senha";

                    using SqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using SqlDataReader reader = cmd.ExecuteReader(); // Inicializando o leitor

                    if (reader.Read())  // Se o login for bem-sucedido
                    {
                        // Obter as informações do usuário logado
                        int usuarioLogadoId = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                        string nomeUsuario = reader["Nome"]?.ToString() ?? "Usuário";

                        // Armazenar as informações do usuário na sessão
                        SessaoUsuario.UsuarioLogadoId = usuarioLogadoId;

                        MessageBox.Show("Bem-vindo " + nomeUsuario);

                        // Redireciona para o formulário Home
                        Home homeForm = new();
                        homeForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorretos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos", "Erro", MessageBoxButtons.OK);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Registro registro = new();
            registro.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Recuperar recuperar = new Recuperar();
            recuperar.Show();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
