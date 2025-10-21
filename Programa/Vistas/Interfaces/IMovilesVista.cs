using Programa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    /// <summary>
    /// Contrato de la vista de móviles.
    /// Permite gestionar móviles, configurar la grilla y obtener el móvil seleccionado.
    /// </summary>
    public interface IMovilesVista
    {
        event EventHandler agregarMovil;
        event EventHandler modificarMovil;
        event EventHandler eliminarMovil;
        event EventHandler OnMovilSeleccionado;
        event EventHandler volver;

        int ObtenerIdMovilSeleccionado();
        void SetMovilesBindingSource(BindingSource moviles);
        void configurarGrilla();
    }
}
