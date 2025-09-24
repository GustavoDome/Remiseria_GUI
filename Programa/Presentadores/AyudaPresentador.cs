using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Programa.Presentadores
{
    public class AyudaPresentador
    {
        private readonly ICategoriaRepositorio repositorioCategoria;
        private readonly IPreguntaRepositorio repositorioPregunta;
        private readonly IRespuestasRepositorio repositorioRespuesta;
        private readonly IAyudaVista vista;
        private readonly BindingSource filtrador;
        private readonly string rol;
        private readonly int id;

        private List<CategoriaDTO> modeloCategoria;
        private List<PreguntaDTO> modeloPregunta;
        private List<RespuestaDTO> modeloRespuesta;

        public AyudaPresentador(
            IAyudaVista vista,
            ICategoriaRepositorio repositorioCategoria,
            IPreguntaRepositorio repositorioPregunta,
            IRespuestasRepositorio repositorioRespuesta,
            string rol,
            int id)
        {
            this.vista = vista;
            this.repositorioCategoria = repositorioCategoria;
            this.repositorioPregunta = repositorioPregunta;
            this.repositorioRespuesta = repositorioRespuesta;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();

            vista.ocultarBotones(rol);

            // Cargar categorías y vincular eventos
            modeloCategoria = repositorioCategoria.ObtenerTodas().ToList();
            vista.SetCategoriaBindingSource(new BindingSource { DataSource = modeloCategoria });

            vista.ingresarPlanillasCosto += ingresar_planilla_costos;
            vista.agregarPregunta += agregar_pregunta;
            vista.modificarPregunta += modificar_pregunta;
            vista.eliminarPregunta += eliminar_pregunta;
            vista.agregarRespuesta += agregar_respuesta;
            vista.modificarRespuesta += modificar_respuesta;
            vista.eliminarRespuesta += eliminar_respuesta;
            vista.agregarCategoria += agregar_categoria;
            vista.modificarCategoria += modificar_categoria;
            vista.eliminarCategoria += eliminar_categoria;
            vista.volver += volver_menu;

            // Eventos internos de selección
            if (vista is AyudaVista vistaConEventos)
            {
                vistaConEventos.categoriaSeleccionada += cargar_preguntas;
                vistaConEventos.preguntaSeleccionada += cargar_respuestas;
            }
        }

        private void cargar_preguntas(int idCategoria)
        {
            var nombreCategoria = modeloCategoria.FirstOrDefault(c => c.IdCategoria == idCategoria)?.NombreCategoria;
            if (string.IsNullOrEmpty(nombreCategoria)) return;

            modeloPregunta = repositorioPregunta.MostrarTodo()
                .Where(p => p.IdCategoria == idCategoria)
                .ToList();

            vista.SetPreguntaBindingSource(new BindingSource { DataSource = modeloPregunta });
            vista.SetRespuestaBindingSource(new BindingSource()); // Limpia respuestas
        }

        private void cargar_respuestas(int idPregunta)
        {
            modeloRespuesta = repositorioRespuesta.MostrarTodo()
                .Where(r => r.IdPregunta == idPregunta)
                .ToList();

            vista.SetRespuestaBindingSource(new BindingSource { DataSource = modeloRespuesta });
        }

        public void ingresar_planilla_costos(object sender, EventArgs e)
        {
            IPlanillaCostoVista planilla = PlanillaCostoVista.ObtenerInstancia();
            ICiudadRepositorio ciudad = new CiudadRepositorio();
            IImporteCiudadRepositorio importeCiudad = new ImporteCiudadRepositorio();
            IImporteCuadrasRepositorio importeCuadras = new ImporteCuadraRepositorio();
            new PlanillaCostoPresentador(planilla, ciudad, importeCuadras, importeCiudad, this.rol, this.id);
            ((Form)vista).Close();
        }

        public void agregar_pregunta(object sender, EventArgs e) { }

        public void modificar_pregunta(object sender, EventArgs e) { }

        public void eliminar_pregunta(object sender, EventArgs e) { }

        public void agregar_respuesta(object sender, EventArgs e) { }

        public void modificar_respuesta(object sender, EventArgs e) { }

        public void eliminar_respuesta(object sender, EventArgs e) { }

        public void agregar_categoria(object sender, EventArgs e) { }

        public void modificar_categoria(object sender, EventArgs e) { }

        public void eliminar_categoria(object sender, EventArgs e) { }

        public void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
