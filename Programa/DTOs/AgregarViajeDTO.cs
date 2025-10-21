using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO utilizado para agregar un nuevo viaje al sistema.
    /// Contiene los datos necesarios para crear el viaje y asociar vueltas.
    /// </summary>
    public class AgregarViajeDTO
    {
        /// <summary>
        /// Identificador del viaje (solo se utiliza en edición).
        /// </summary>
        public int IdViaje { get; set; }

        /// <summary>
        /// Número asignado al viaje.
        /// </summary>
        public int NumeroViaje { get; set; }

        /// <summary>
        /// Hora en la que se realiza el viaje.
        /// </summary>
        public TimeSpan HoraViaje { get; set; }

        /// <summary>
        /// Dirección de destino del viaje.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Identificador del operador que gestiona el viaje.
        /// </summary>
        public int IdOperador { get; set; }

        /// <summary>
        /// Estado actual del viaje (por ejemplo: "·", "L", "X").
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
        /// Lista de números de vuelta correspondientes a cada móvil.
        /// </summary>
        public List<int> Vueltas { get; set; }

        /// <summary>
        /// Fecha en la que se realizan las vueltas del viaje.
        /// </summary>
        public DateTime VueltaFecha { get; set; }

        /// <summary>
        /// Estado que se asignará a las vueltas (por ejemplo: "X").
        /// </summary>
        public string EstadoVuelta { get; set; }

        /// <summary>
        /// Lista de identificadores de vueltas que deben activarse y asociarse al viaje.
        /// </summary>
        public List<int> IdsVueltasActivadas { get; set; } = new List<int>();
    }
}
