using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar una nueva categoría en el módulo de ayuda.
    /// Permite ingresar el nombre y confirmar la acción.
    /// </summary>
    public interface IAgregarAyudaVistaCategoria
    {
        string categorianombre { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
