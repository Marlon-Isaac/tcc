using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Mensagem
    {
        public int Id { get; set; }
        public int UsuarioRemetenteId { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
    }

}
