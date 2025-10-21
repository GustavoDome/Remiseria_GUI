using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa una pregunta registrada en el sistema.
    /// </summary>
    public class PreguntaDTO
    {
        /// <summary>
        /// Identificador único de la pregunta.
        /// </summary>
        public int IdPregunta { get; set; }

        /// <summary>
        /// Texto de la pregunta.
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Nombre de la categoría asociada.
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Identificador de la categoría.
        /// </summary>
        public int IdCategoria { get; set; }
    }
}
