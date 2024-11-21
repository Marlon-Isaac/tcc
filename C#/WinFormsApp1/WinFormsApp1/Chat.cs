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
    public partial class Chat : Form
    {


        public Chat()
        {
            InitializeComponent();

        }


        private void Chat_Load(object sender, EventArgs e)
        {
            BancoC();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void BancoC()
        {
            while (true)
            {
                Banco banco = new Banco();
                using (SqlConnection conn = new SqlConnection(banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Chat", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                int remetente = Convert.ToInt32(reader["UsuarioRemetenteId"]);
                                int destinatario = Convert.ToInt32(reader["UsuarioDestinatarioId"]);
                                string mensagem = reader["Conteudo"].ToString();
                                string data = reader["DataEnvio"].ToString();
                                bool lida = Convert.ToBoolean(reader["Lida"]);

                            }
                        }
                    }
                }
            }
        }
        public void construir(int id, int remetente, int destinatario, string mensagem, string data, bool lida)
        {

        }

    }
}
