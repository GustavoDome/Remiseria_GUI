using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO utilizado para representar los datos detallados de una base registrada.
    /// Incluye información de fecha, estado, comentario y opcionalmente datos del operador que la registró.
    /// </summary>
    public class BaseDetalleDTO
    {
        /// <summary>
        /// Identificador único de la base.
        /// </summary>
        public int IdBase { get; set; }

        /// <summary>
        /// Fecha en la que se registró la base.
        /// </summary>
        public DateTime Fecha_base { get; set; }

        /// <summary>
        /// Estado actual de la base (activo/inactivo).
        /// </summary>
        public bool EstadoBase { get; set; }

        /// <summary>
        /// Comentario adicional asociado a la base.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Nombre del operador que registró la base (opcional).
        /// </summary>
        public string NombreOperador { get; set; }

        /// <summary>
        /// Rol del operador que registró la base (opcional).
        /// </summary>
        public string RolOperador { get; set; }
    }
}
