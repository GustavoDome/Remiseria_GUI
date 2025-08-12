using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class RespuestaModelo
    {
        private int id_respuesta;
        private string respuesta_texto;
        private byte[] respuesta_audio_video;
        private int id_pregunta;

        public int Id_respuesta { get; set; }
        public string Respuesta_texto { get; set; }
        public byte[] Respuesta_audio_video { get; set; }
        public int Id_pregunta { get; set; }
    }
}
