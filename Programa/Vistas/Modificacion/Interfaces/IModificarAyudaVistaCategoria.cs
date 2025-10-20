using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar una categoría en el módulo de ayuda.
    /// </summary>
    public interface IModificarAyudaVistaCategoria
    {
        string categorianombre { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
