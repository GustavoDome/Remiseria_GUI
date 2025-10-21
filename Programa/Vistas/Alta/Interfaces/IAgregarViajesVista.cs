using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar un nuevo viaje.
    /// Permite ingresar dirección, comentario contextual y móviles asignados.
    /// </summary>
    public interface IAgregarViajesVista
    {
        string txtDirecciones { get; set; }
        string rtbComentarios { get; set; }

        string obtenerOpcion(); // Devuelve el tipo de comentario seleccionado

        List<int> ObtenerMovilesSeleccionados(); // Devuelve los IDs de móviles seleccionados
        void CargarMoviles(List<MovilResumenDTO> moviles); // Carga los móviles en el CheckedListBox

        event EventHandler agregar;
        event EventHandler volver;
    }
}
