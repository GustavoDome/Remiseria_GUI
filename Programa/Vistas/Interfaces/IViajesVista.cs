using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IViajesVista
    {
        event EventHandler agregarViaje;
        event EventHandler modificarViaje;
        event EventHandler comentarViaje;
        event EventHandler eliminarViaje;
        event EventHandler retroceder;
        event EventHandler adelantar;
        event EventHandler ingresarVuelta;
        event EventHandler volver;

        void ocultarBotones(string rol);
        void SetViajesBindingSource(BindingSource viajes);
        void congelarVista();
    }
}
