using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar el importe de espera por cuadra.
    /// </summary>
    public interface IModificarPlanillaCostoVistaEsperaCuadra
    {
        int MontoEsperaCuadra { get; set; }

        event EventHandler modificar;
        event EventHandler volver;
    }
}
