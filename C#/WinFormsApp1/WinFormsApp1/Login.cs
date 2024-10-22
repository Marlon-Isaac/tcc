using Microsoft.Win32;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

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
        }

        public void FecharLogin()
        {
            this.Close();  // Fecha o formulário Login
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

            if (login.Length != 0 && senha.Length != 0)
            {
                Banco banco = new();
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
