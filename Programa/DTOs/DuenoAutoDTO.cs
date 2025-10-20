using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa los datos básicos de un dueño de móvil.
    /// </summary>
    public class DuenoAutoDTO
    {
        /// <summary>
        /// Identificador único del dueño.
        /// </summary>
        public int IdDueno { get; set; }

        /// <summary>
        /// Nombre completo del dueño (composición de nombre y apellido).
        /// </summary>
        public string NombreCompleto => $"{Nombre} {Apellido}";

        /// <summary>
        /// Indica si el dueño también es chofer.
        /// </summary>
        public bool Chofer { get; set; }

        /// <summary>
        /// Teléfono de contacto del dueño.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Nombre del dueño.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del dueño.
        /// </summary>
        public string Apellido { get; set; }
    }
}
