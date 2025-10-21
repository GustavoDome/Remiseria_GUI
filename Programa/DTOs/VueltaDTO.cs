using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa una vuelta realizada por un móvil, asociada o no a un viaje.
    /// </summary>
    public class VueltaDTO
    {
        /// <summary>
        /// Identificador único de la vuelta.
        /// </summary>
        public int IdVuelta { get; set; }

        /// <summary>
        /// Identificador del viaje asociado (puede ser null si es manual).
        /// </summary>
        public int? IdViaje { get; set; }

        /// <summary>
        /// Identificador del móvil que realizó la vuelta.
        /// </summary>
        public int IdMovil { get; set; }

        /// <summary>
        /// Número de vuelta (orden del día).
        /// </summary>
        public int NumeroVuelta { get; set; }

        /// <summary>
        /// Fecha en la que se realizó la vuelta.
        /// </summary>
        public DateTime VueltaFecha { get; set; }

        /// <summary>
        /// Estado actual de la vuelta (por ejemplo: "X", "S", "R").
        /// </summary>
        public string EstadoVuelta { get; set; }
    }
}
