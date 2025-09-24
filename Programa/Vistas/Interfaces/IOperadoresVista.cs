using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IOperadoresVista
    {
        event EventHandler agregarOperador;
        event EventHandler modificiarOperador;
        event EventHandler eliminarOperador;
        event EventHandler volver;

        int ObtenerIdOperadorSeleccionado();
        void SetOperadoresBindingSource(BindingSource operadores);
    }
}
