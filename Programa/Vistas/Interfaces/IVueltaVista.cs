using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IVueltaVista
    {
        event EventHandler agregarVuelta;
        event EventHandler modificarVuelta;
        event EventHandler eliminarVuelta;
        event EventHandler retroceder;
        event EventHandler adelantar;
        event EventHandler ingresarViaje;
        event EventHandler volver;

        void ocultarBotones(string rol);
        void SetViajesBindingSource(BindingSource viajes);
    }
}
