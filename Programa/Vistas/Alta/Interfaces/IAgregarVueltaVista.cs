using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    public interface IAgregarVueltaVista
    {
        event EventHandler agregarMovil;
        event EventHandler volver;
        void SetMoviles(IEnumerable<MovilResumenDTO> moviles);
        List<int> ObtenerMovilesSeleccionados();
        void Cerrar();
    }
}
