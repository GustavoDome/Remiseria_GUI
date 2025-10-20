using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa los importes por kilómetro y espera dentro de la ciudad.
    /// </summary>
    public class ImporteCiudadDTO
    {
        /// <summary>
        /// Importe por kilómetro recorrido.
        /// </summary>
        public int Kilometro { get; set; }

        /// <summary>
        /// Importe por tiempo de espera.
        /// </summary>
        public int Espera { get; set; }
    }
}
