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
        public int Obter(int id)
        {
            Banco banco = new Banco();
            using (SqlConnection conn = new SqlConnection(banco.conexao))
            {
                conn.Open();
            }
        }
    }
}
