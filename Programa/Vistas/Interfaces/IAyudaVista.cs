using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    /// <summary>
    /// Contrato de la vista de ayuda.
    /// Define eventos para gestionar categorías, preguntas y respuestas, y métodos para renderizar contenido dinámico.
    /// </summary>
    public interface IAyudaVista
    {
        event EventHandler ingresarPlanillasCosto;
        event EventHandler agregarPregunta;
        event EventHandler modificarPregunta;
        event EventHandler eliminarPregunta;
        event EventHandler agregarRespuesta;
        event EventHandler agregarCategoria;
        event EventHandler modificarCategoria;
        event EventHandler eliminarCategoria;
        event EventHandler volver;
        event Action<int> respuestaModificarSeleccionada;
        event Action<int> respuestaEliminarSeleccionada;

        void ocultarBotones();
        void SetCategoriaBindingSource(BindingSource categorias);
        void SetPreguntaBindingSource(BindingSource preguntas);
        void SetRespuestaBindingSource(BindingSource respuestas);
    }
}
