using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar un comentario a una base.
    /// Permite ingresar texto y confirmar la acción.
    /// </summary>
    public interface IAgregarBasesVistaComentario
    {
        string comentario { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
