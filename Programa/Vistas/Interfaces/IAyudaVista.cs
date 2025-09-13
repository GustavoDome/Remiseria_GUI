using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IAyudaVista
    {
        event EventHandler ingresarPlanillasCosto;
        event EventHandler agregarPregunta;
        event EventHandler modificarPregunta;
        event EventHandler eliminarPregunta;
        event EventHandler agregarRespuesta;
        event EventHandler modificarRespuesta;
        event EventHandler eliminarRespuesta;
        event EventHandler agregarCategoria;
        event EventHandler modificarCategoria;
        event EventHandler eliminarCategoria;
        event EventHandler volver;

        void ocultarBotones(string rol);
        void SetCategoriaBindingSource(BindingSource categorias);
        void SetPreguntaBindingSource(BindingSource preguntas);
        void SetRespuestaBindingSource(BindingSource respuestas);
    }
}
