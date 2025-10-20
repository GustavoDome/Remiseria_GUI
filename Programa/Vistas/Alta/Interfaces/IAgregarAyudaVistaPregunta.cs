using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar una nueva pregunta en el módulo de ayuda.
    /// Permite ingresar el texto y confirmar la acción.
    /// </summary>
    public interface IAgregarAyudaVistaPregunta
    {
        string preguntatexto { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
