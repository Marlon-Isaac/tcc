using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class SessaoUsuario
    {
        public static int UsuarioLogadoId { get; set; }  // Armazena o ID do usuário logado
        public static string NomeUsuario { get; set; } = string.Empty; // Nome do usuário logado
        public static string TipoUsuario { get; set; } = string.Empty; // Tipo do usuário logado

    }

}
