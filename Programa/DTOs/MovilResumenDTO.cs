using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa un móvil en formato reducido (solo ID y número).
    /// </summary>
    public class MovilResumenDTO
    {
        /// <summary>
        /// Identificador único del móvil.
        /// </summary>
        public int IdMovil { get; set; }

        /// <summary>
        /// Número asignado al móvil.
        /// </summary>
        public int NumeroMovil { get; set; }

        /// <summary>
        /// Representación textual del móvil.
        /// </summary>
        public override string ToString()
        {
            return $"Móvil {NumeroMovil}";
        }
    }
}
