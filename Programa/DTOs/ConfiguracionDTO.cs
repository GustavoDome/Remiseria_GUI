using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO que encapsula la configuración visual y de alarma personalizada por operador.
    /// </summary>
    public class ConfiguracionDTO
    {
        /// <summary>
        /// Fuente tipográfica utilizada en la interfaz.
        /// </summary>
        public string Fuente { get; set; }

        /// <summary>
        /// Tamaño de fuente aplicado a los formularios.
        /// </summary>
        public int TamanoFuente { get; set; }

        /// <summary>
        /// Tema de color seleccionado por el operador.
        /// </summary>
        public string TemaColor { get; set; }

        /// <summary>
        /// Tipo de alarma sonora configurada.
        /// </summary>
        public string TipoAlarma { get; set; }
    }
}
