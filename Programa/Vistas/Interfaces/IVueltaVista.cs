using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    /// <summary>
    /// Contrato de la vista de vueltas.
    /// Permite gestionar vueltas por móvil y fecha, con navegación, selección y mensajes contextuales.
    /// </summary>
    public interface IVueltaVista
    {
        event EventHandler agregarVuelta;
        event EventHandler modificarVuelta;
        event EventHandler eliminarVuelta;
        event EventHandler agregarMovil;
        event EventHandler eliminarMovil;
        event EventHandler retroceder;
        event EventHandler adelantar;
        event EventHandler ingresarViaje;
        event EventHandler volver;

        void SetFecha(DateTime fecha);
        void ocultarBotones(string rol);
        void SetViajesBindingSource(BindingSource viajes);
        int ObtenerIdVueltaSeleccionada();
        int ObtenerIdMovilSeleccionado();
        int ObtenerNumeroMovilSeleccionado();
        void ConfigurarMoviles(List<MovilResumenDTO> lista);
        int ObtenerNumeroVueltaSeleccionada();
        void MostrarMensaje(string mensaje);
    }
}
