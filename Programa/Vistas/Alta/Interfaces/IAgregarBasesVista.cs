using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar una nueva base.
    /// Permite seleccionar la fecha y confirmar la creación.
    /// </summary>
    public interface IAgregarBasesVista
    {
        DateTime fecha { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
