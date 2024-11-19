using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class tipo2
    {
        public string Tipoo()
        {
            if(tipo.TipoUsuario != null)
            {
                return(tipo.TipoUsuario);
            }
            else
            {
                return ("Erro, tipo do usuario nao foi salvo!");
            }
        }
    }
    public static class tipo
    {
        public static string TipoUsuario { get; set; }
    }
}
