using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    /// <summary>
    /// DTO utilizado para autenticar operadores en el sistema.
    /// </summary>
    public class OperadorLoginDTO
    {
        /// <summary>
        /// Identificador único del operador.
        /// </summary>
        public int IdOperador { get; set; }

        /// <summary>
        /// Nombre de usuario del operador.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Contraseña del operador.
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Rol asignado al operador (por ejemplo: "Gerente").
        /// </summary>
        public string RolUsuario { get; set; }
    }
}
