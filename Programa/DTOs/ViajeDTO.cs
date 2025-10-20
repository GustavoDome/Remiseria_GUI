using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa los datos generales de un viaje registrado.
    /// </summary>
    public class ViajeDTO
    {
        /// <summary>
        /// Identificador único del viaje.
        /// </summary>
        public int IdViaje { get; set; }

        /// <summary>
        /// Hora en la que se realiza el viaje.
        /// </summary>
        public TimeSpan HoraViaje { get; set; }

        /// <summary>
        /// Dirección de destino del viaje.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Estado actual del viaje.
        /// </summary>
        public string EstadoViaje { get; set; }

        /// <summary>
        /// Comentario adicional sobre el viaje.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Lista de identificadores de móviles asignados al viaje.
        /// </summary>
        public List<int> IdMoviles { get; set; }

        /// <summary>
        /// Texto concatenado con los móviles asignados (para visualización).
        /// </summary>
        public string MovilesConcatenados { get; set; }
    }
}
