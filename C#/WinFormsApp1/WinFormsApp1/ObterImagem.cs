using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ObterImagem
    {
        public byte[] Obter(int id)
        {
            byte[] imagem = null;
            Banco banco = new Banco();
            using (SqlConnection conn = new SqlConnection(banco.conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Imagem FROM Login WHERE Id = @id",conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        imagem = reader["Imagem"] as byte[];
                    }
                }
            }
            return(imagem);
        }
    }
}
