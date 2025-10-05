using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    public interface IModificarAyudaVistaRespuesta
    {
        string respuestatexto { get; set; }
        byte[] multimedia { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
