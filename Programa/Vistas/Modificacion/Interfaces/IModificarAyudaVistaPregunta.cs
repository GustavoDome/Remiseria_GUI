using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar una pregunta en el módulo de ayuda.
    /// </summary>
    public interface IModificarAyudaVistaPregunta
    {
        string preguntatexto { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
