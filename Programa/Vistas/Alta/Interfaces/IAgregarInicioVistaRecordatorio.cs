using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar un nuevo recordatorio.
    /// Permite configurar fecha, hora, dirección y comentario.
    /// </summary>
    public interface IAgregarInicioVistaRecordatorio
    {
        event EventHandler volver;
        event EventHandler agregar;

        DateTime fecha {  get; set; }
        DateTime hora { get; set; }
        string direccion { get; set; }
        string comentario { get; set; }
    }
}
