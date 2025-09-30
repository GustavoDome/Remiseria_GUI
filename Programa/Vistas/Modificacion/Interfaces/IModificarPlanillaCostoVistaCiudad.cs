using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    public interface IModificarPlanillaCostoVistaCiudad
    {
        string NombreCiudad { get; set; }
        int Kilometros { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
