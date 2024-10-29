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

        private void CreateControls()
        {
            Banco banco = new();
            if (currentRow >= totalRows) return; // Se não há mais registros

            using (SqlConnection conn = new SqlConnection(banco.conexao))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Id, Nome, Login, Senha, Tipo FROM registro ORDER BY ID OFFSET {currentRow} ROWS FETCH NEXT 1 ROWS ONLY", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string id = reader["Id"].ToString();
                    string nome = reader["Nome"].ToString();
                    string login = reader["Login"].ToString();
                    string senha = reader["Senha"].ToString();
                    string tipo = reader["Tipo"].ToString();

                    Label nameLabel = new Label
                    {
                        Text = nome,
                        Left = 10,
                        Top = 10 + (currentRow * 50),
                        AutoSize = true
                    };
                    panel2.Controls.Add(nameLabel);

                    Button btnAccept = new Button
                    {
                        Text = "Aceitar",
                        Left = panel2.Width - 150,
                        Top = 10 + (currentRow * 50),
                        Width = 70
                    };
                    btnAccept.Click += (sender, e) => HandleButtonClick( id, nome, login, senha, tipo, true);
                    panel2.Controls.Add(btnAccept);

                    Button btnReject = new Button
                    {
                        Text = "Rejeitar",
                        Left = panel2.Width - 70,
                        Top = 10 + (currentRow * 50),
                        Width = 70
                    };
                    btnReject.Click += (sender, e) => HandleButtonClick( id, nome, login, senha, tipo, false);
                    panel2.Controls.Add(btnReject);
                }
            }
        }

        private void HandleButtonClick(string id, string nome, string login, string senha, string tipo, bool accepted)
        {
            if (accepted)
            {
                using (SqlConnection conn = new SqlConnection(Banco.conexao))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO login (Nome, Login, Senha, Tipo) VALUES (@nome, @login, @senha, @tipo)", conn);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection conn = new(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE Id = @Id"))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                    }

                }

            }
            else if(accepted == false)
            {
                using (SqlConnection conn = new(Banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE Id = @Id"))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                        cmd.ExecuteNonQuery();
                        conn.Close();
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
