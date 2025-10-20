using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar un operador registrado.
    /// Permite editar datos personales, contraseña y rol asignado.
    /// </summary>
    public interface IModificarOperadorVista
    {
        string Nombre { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        string Contrasena { get; set; }
        string Rol { get; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
