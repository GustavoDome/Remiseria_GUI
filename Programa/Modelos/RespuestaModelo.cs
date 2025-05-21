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

        public int Id_respuesta
        {
            get { return id_respuesta; }
            set { id_respuesta = value; }
        }

        public string Respuesta_texto
        {
            get { return respuesta_texto; }
            set { respuesta_texto = value; }
        }

        public byte[] Respuesta_audio_video
        {
            get { return respuesta_audio_video; }
            set { respuesta_audio_video = value; }
        }

        public int Id_pregunta
        {
            get { return id_pregunta; }
            set { id_pregunta = value; }
        }
    }
}
