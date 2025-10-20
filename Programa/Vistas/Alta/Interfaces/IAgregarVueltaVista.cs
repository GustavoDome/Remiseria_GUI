using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar móviles a una vuelta.
    /// Permite seleccionar móviles y cerrar la vista.
    /// </summary>
    public interface IAgregarVueltaVista
    {
        event EventHandler agregarMovil;
        event EventHandler volver;
        void SetMoviles(IEnumerable<MovilResumenDTO> moviles);
        List<int> ObtenerMovilesSeleccionados();
        void Cerrar();
    }
}
