using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que representa los datos completos de un móvil, incluyendo información del dueño.
    /// </summary>
    public class MovilDetalleDTO
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
        /// Marca del automóvil.
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Modelo del automóvil.
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Año del automóvil.
        /// </summary>
        public string Ano { get; set; }

        /// <summary>
        /// Color del automóvil.
        /// </summary>
        public string Color { get; set; }

        // Datos del dueño

        /// <summary>
        /// Identificador del dueño del móvil.
        /// </summary>
        public int IdDueno { get; set; }

        /// <summary>
        /// Nombre del dueño.
        /// </summary>
        public string NombreDueno { get; set; }

        /// <summary>
        /// Apellido del dueño.
        /// </summary>
        public string ApellidoDueno { get; set; }

        /// <summary>
        /// Teléfono de contacto del dueño.
        /// </summary>
        public string TelefonoDueno { get; set; }

        /// <summary>
        /// Indica si el dueño también es chofer.
        /// </summary>
        public bool EsChofer { get; set; }
    }
}
