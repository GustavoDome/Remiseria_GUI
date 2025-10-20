using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa los importes configurados por cuadras, mínimo, mandado y espera.
    /// </summary>
    public class CuadrasImporteDTO
    {
        /// <summary>
        /// Importe mínimo por trayecto.
        /// </summary>
        public int Minimo { get; set; }

        /// <summary>
        /// Importe por cantidad de cuadras recorridas.
        /// </summary>
        public int Cuadras { get; set; }

        /// <summary>
        /// Importe adicional por mandado.
        /// </summary>
        public int Mandado { get; set; }

        /// <summary>
        /// Importe por tiempo de espera.
        /// </summary>
        public int Espera { get; set; }
    }
}
