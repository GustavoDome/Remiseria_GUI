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
    /// Contrato de la vista de bases.
    /// Permite visualizar bases y móviles, gestionar acciones sobre ellas y obtener la selección actual.
    /// </summary>
    public interface IBasesVista
    {
        // Eventos
        event EventHandler agregarBase;
        event EventHandler modificarBase;
        event EventHandler comentarBase;
        event EventHandler eliminarBase;
        event EventHandler volver;
        event EventHandler OnMovilSeleccionado;

        // Propiedades
        int id_movil { get; set; }

        // Métodos
        void ocultarBotones(string rol);
        void mostrarMoviles(BindingSource listaMoviles);
        void mostrarBases(List<BaseDetalleDTO> listaBases);
        int? ObtenerBaseSeleccionada();
    }
}
