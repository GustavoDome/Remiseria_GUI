using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar una base existente.
    /// Permite editar fecha y comentario asociado.
    /// </summary>
    public interface IModificarBasesVista
    {
        DateTime fecha { get; set; }
        string comentario { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
