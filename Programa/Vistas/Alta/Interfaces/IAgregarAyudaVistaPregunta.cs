using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    public interface IAgregarAyudaVistaPregunta
    {
        string preguntatexto { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
