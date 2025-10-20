using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar una nueva ciudad a la planilla de costos.
    /// Permite ingresar nombre y distancia en kilómetros.
    /// </summary>
    public interface IAgregarPlanillaCostoVista
    {
        string NombreCiudad { get; set; }
        int Kilometros { get; set; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
