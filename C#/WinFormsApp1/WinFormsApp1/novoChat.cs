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
    public partial class novoChat : Form
    {
        public novoChat()
        {
            InitializeComponent();
        }

        private void novoChat_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string remetente = textBox1.Text;
                if (!string.IsNullOrEmpty(remetente))
                {
                    Banco banco = new Banco();
                    using (SqlConnection connection = new SqlConnection(banco.conexao))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM login WHERE Login = @email", connection))
                        {
                            command.Parameters.AddWithValue("@email", remetente);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                int count = Convert.ToInt32(command.ExecuteScalar());
                                if (count > 0)
                                {
                                    Conversa conversa = new Conversa(id, 0, 0);
                                    conversa.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Rementente não encontrado", "Erro", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
