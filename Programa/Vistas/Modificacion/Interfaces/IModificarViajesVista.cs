using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    public interface IModificarViajesVista
    {
        string txtDirecciones { get; set; }
        string rtbComentario { get; set; }

        string obtenerOpcion();
        List<int> ObtenerMovilesSeleccionados();
        void SetComentario(string comentario);
        void CargarMoviles(List<MovilResumenDTO> moviles, List<int> seleccionados);

        event EventHandler modificar;
        event EventHandler volver;
    }
}
