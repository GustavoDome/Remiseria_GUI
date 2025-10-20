using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa una respuesta a una pregunta, con posible contenido multimedia.
    /// </summary>
    public class RespuestaDTO
    {
        /// <summary>
        /// Identificador único de la respuesta.
        /// </summary>
        public int IdRespuesta { get; set; }

        /// <summary>
        /// Texto de la respuesta.
        /// </summary>
        public string TextoRespuesta { get; set; }

        /// <summary>
        /// Identificador de la pregunta asociada.
        /// </summary>
        public int IdPregunta { get; set; }

        /// <summary>
        /// Contenido multimedia (audio o video) asociado a la respuesta.
        /// </summary>
        public byte[] AudioVideo { get; set; }

        /// <summary>
        /// Indica si la respuesta contiene contenido multimedia.
        /// </summary>
        public bool TieneMultimedia => AudioVideo != null && AudioVideo.Length > 0;
    }
}
