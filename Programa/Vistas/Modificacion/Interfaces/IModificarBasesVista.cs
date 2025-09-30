using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    public interface IModificarBasesVista
    {
        DateTime fecha { get; set; }
        string comentario { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
