using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar el importe de espera fuera de la ciudad.
    /// </summary>
    public interface IModificarPlanillaCostoVistaEsperaCiudad
    {
        int MontoEspera { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
