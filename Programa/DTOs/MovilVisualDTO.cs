using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa un móvil con texto personalizado para visualización.
    /// </summary>
    public class MovilVisualDTO
    {
        /// <summary>
        /// Identificador único del móvil.
        /// </summary>
        public int IdMovil { get; set; }

        /// <summary>
        /// Texto descriptivo del móvil.
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Representación textual del móvil.
        /// </summary>
        public override string ToString()
        {
            return Texto;
        }
    }
}
