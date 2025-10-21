using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO utilizado para editar los datos de un viaje existente.
    /// </summary>
    public class ModificarViajeDTO
    {
        /// <summary>
        /// Identificador del viaje a modificar.
        /// </summary>
        public int IdViaje { get; set; }

        /// <summary>
        /// Dirección de destino del viaje.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Comentario adicional sobre el viaje.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Lista de identificadores de móviles asignados al viaje.
        /// </summary>
        public List<int> IdMoviles { get; set; }
    }
}
