using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
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
