using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar una nueva respuesta en el módulo de ayuda.
    /// Permite ingresar texto y adjuntar contenido multimedia.
    /// </summary>
    public interface IAgregarAyudaVistaRespuesta
    {
        string respuestatexto { get; set; }
        byte[] multimedia { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
