using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar una respuesta en el módulo de ayuda.
    /// Permite editar texto y contenido multimedia.
    /// </summary>
    public interface IModificarAyudaVistaRespuesta
    {
        string respuestatexto { get; set; }
        byte[] multimedia { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
