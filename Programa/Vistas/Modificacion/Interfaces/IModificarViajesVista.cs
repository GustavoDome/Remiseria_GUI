using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    /// <summary>
    /// Contrato de la vista para modificar un viaje existente.
    /// Permite editar dirección, móviles asignados y comentarios según tipo.
    /// </summary>
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
