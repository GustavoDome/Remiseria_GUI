using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IBasesVista
    {
        event EventHandler agregarBase;
        event EventHandler modificarBase;
        event EventHandler comentarBase;
        event EventHandler eliminarBase;
        event EventHandler volver;
        event EventHandler OnMovilSeleccionado;

        int id_movil { get; set; }


        void ocultarBotones(string rol);
        void mostrarMoviles(BindingSource listaBase);
        void mostrarBases(BindingSource listaBase, int id);
    }
}
