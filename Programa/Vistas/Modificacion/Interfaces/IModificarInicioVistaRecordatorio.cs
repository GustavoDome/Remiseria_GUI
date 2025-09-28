using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    public interface IModificarInicioVistaRecordatorio
    {
        event EventHandler volver;
        event EventHandler modificar;

        DateTime fecha { get; set; }
        DateTime hora { get; set; }
        string direccion { get; set; }
        string comentario { get; set; }
    }
}
