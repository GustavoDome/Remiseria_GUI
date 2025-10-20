using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa una categoría de preguntas en el sistema.
    /// </summary>
    public class CategoriaDTO
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Nombre o descripción de la categoría.
        /// </summary>
        public string NombreCategoria { get; set; }
    }
}
