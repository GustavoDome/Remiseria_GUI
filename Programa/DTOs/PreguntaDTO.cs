using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class PreguntaDTO
    {
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        public string Categoria { get; set; }
        public int IdCategoria { get; set; }
    }
}
