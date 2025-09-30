using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    public interface IAgregarPlanillaCostoVista
    {
        string NombreCiudad { get; set; }
        int Kilometros { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
