using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa una ciudad y su importe asociado por distancia.
    /// </summary>
    public class CiudadDTO
    {
        /// <summary>
        /// Identificador único de la ciudad.
        /// </summary>
        public int IdCiudad { get; set; }

        /// <summary>
        /// Nombre de la ciudad.
        /// </summary>
        public string NombreCiudad { get; set; }

        /// <summary>
        /// Distancia en kilómetros asociada a la ciudad.
        /// </summary>
        public int Kilometros { get; set; }

        /// <summary>
        /// Importe correspondiente a la distancia.
        /// </summary>
        public int Importe { get; set; }
    }
}
