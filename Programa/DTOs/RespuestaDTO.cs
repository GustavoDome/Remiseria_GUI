using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class RespuestaDTO
    {
        public int IdRespuesta { get; set; }
        public string TextoRespuesta { get; set; }
        public int IdPregunta { get; set; }
        public byte[] AudioVideo { get; set; }

        public bool TieneMultimedia => AudioVideo != null && AudioVideo.Length > 0;
    }
}
