using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa un recordatorio programado por un operador.
    /// </summary>
    public class RecordatorioDTO
    {
        /// <summary>
        /// Identificador único del recordatorio.
        /// </summary>
        public int IdRecordatorio { get; set; }

        /// <summary>
        /// Dirección asociada al recordatorio.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Fecha del recordatorio (solo día).
        /// </summary>
        public DateTime? FechaDia { get; set; }

        /// <summary>
        /// Hora del recordatorio.
        /// </summary>
        public DateTime? FechaHora { get; set; }

        /// <summary>
        /// Comentario adicional del recordatorio.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Nombre del operador que lo registró.
        /// </summary>
        public string NombreOperador { get; set; }
    }
}
