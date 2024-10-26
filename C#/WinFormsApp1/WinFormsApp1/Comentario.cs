using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Comentario
    {
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string Conteudo { get; set; }
        public required Image Imagem { get; set; }
    }


}
