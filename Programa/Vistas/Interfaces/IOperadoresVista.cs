using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    /// <summary>
    /// Contrato de la vista de operadores.
    /// Permite gestionar operadores, configurar la grilla y obtener el operador seleccionado.
    /// </summary>
    public interface IOperadoresVista
    {
        event EventHandler agregarOperador;
        event EventHandler modificiarOperador;
        event EventHandler eliminarOperador;
        event EventHandler volver;

        int ObtenerIdOperadorSeleccionado();
        void SetOperadoresBindingSource(BindingSource operadores);
        void configurarGrilla();
    }
}
