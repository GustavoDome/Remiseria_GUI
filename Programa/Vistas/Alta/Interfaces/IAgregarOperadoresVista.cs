using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar un nuevo operador.
    /// Permite ingresar datos personales, contraseña y rol asignado.
    /// </summary>
    public interface IAgregarOperadoresVista
    {
        string Nombre { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        string Contrasena { get; set; }
        string Rol { get; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
