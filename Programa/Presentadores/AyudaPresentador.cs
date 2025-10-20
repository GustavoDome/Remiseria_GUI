using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Presentadores.CUPresentador;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Alta;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using Programa.Vistas.Modificacion;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Programa.Presentadores.CUPresentador.CUAyudaPresentador;

namespace Programa.Presentadores
{
    /// <summary>
    /// Presentador encargado de gestionar la vista de ayuda.
    /// Coordina la visualización, creación, modificación y eliminación de categorías, preguntas y respuestas.
    /// </summary>
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

        /// <summary>
        /// Identificador de la categoría actualmente seleccionada.
        /// </summary>
        public int? IdCategoriaSeleccionada { get; private set; }

        /// <summary>
        /// Identificador de la pregunta actualmente seleccionada.
        /// </summary>
        public int? IdPreguntaSeleccionada { get; private set; }

        /// <summary>
        /// Inicializa el presentador con la vista de ayuda, los repositorios y los datos del operador.
        /// </summary>
        public AyudaPresentador(IAyudaVista vista, ICategoriaRepositorio repositorioCategoria, IPreguntaRepositorio repositorioPregunta, IRespuestasRepositorio repositorioRespuesta, string rol, int id)
        {
            this.vista = vista;
            this.repositorioCategoria = repositorioCategoria;
            this.repositorioPregunta = repositorioPregunta;
            this.repositorioRespuesta = repositorioRespuesta;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();

            vista.ocultarBotones();
            // Cargar categorías y vincular eventos
            modeloCategoria = repositorioCategoria.ObtenerTodas().ToList();
            vista.SetCategoriaBindingSource(new BindingSource { DataSource = modeloCategoria });

            vista.ingresarPlanillasCosto += ingresar_planilla_costos;
            vista.agregarPregunta += agregar_pregunta;
            vista.modificarPregunta += modificar_pregunta;
            vista.eliminarPregunta += eliminar_pregunta;
            vista.agregarRespuesta += agregar_respuesta;
            vista.agregarCategoria += agregar_categoria;
            vista.modificarCategoria += modificar_categoria;
            vista.eliminarCategoria += eliminar_categoria;
            vista.volver += volver_menu;

            // Eventos internos de selección
            if (vista is AyudaVista vistaConEventos)
            {
                vistaConEventos.categoriaSeleccionada += cargar_preguntas;
                vistaConEventos.preguntaSeleccionada += cargar_respuestas;
                vistaConEventos.respuestaModificarSeleccionada += modificar_respuesta;
                vistaConEventos.respuestaEliminarSeleccionada += eliminar_respuesta;
            }
        }

        /// <summary>
        /// Refresca los modelos internos de categorías, preguntas y respuestas desde los repositorios.
        /// </summary>
        public void RefrescarModelos()
        {
            modeloCategoria = repositorioCategoria.ObtenerTodas().ToList();
            modeloPregunta = repositorioPregunta.MostrarTodo().ToList();
            modeloRespuesta = repositorioRespuesta.MostrarTodo().ToList();
        }

        /// <summary>
        /// Carga las preguntas asociadas a la categoría seleccionada.
        /// </summary>
        private void cargar_preguntas(int idCategoria)
        {
            IdCategoriaSeleccionada = idCategoria;

            var nombreCategoria = modeloCategoria.FirstOrDefault(c => c.IdCategoria == idCategoria)?.NombreCategoria;
            if (string.IsNullOrEmpty(nombreCategoria)) return;

            modeloPregunta = repositorioPregunta.MostrarTodo()
                .Where(p => p.IdCategoria == idCategoria)
                .ToList();

            vista.SetPreguntaBindingSource(new BindingSource { DataSource = modeloPregunta });
            vista.SetRespuestaBindingSource(new BindingSource()); // Limpia respuestas
        }

        /// <summary>
        /// Carga las respuestas asociadas a la pregunta seleccionada.
        /// </summary>
        private void cargar_respuestas(int idPregunta)
        {
            IdPreguntaSeleccionada = idPregunta;

            modeloRespuesta = repositorioRespuesta.MostrarTodo()
                .Where(r => r.IdPregunta == idPregunta)
                .ToList();

            vista.SetRespuestaBindingSource(new BindingSource { DataSource = modeloRespuesta });
        }

        /// <summary>
        /// Navega al módulo de planilla de costos desde la vista de ayuda.
        /// </summary>
        public void ingresar_planilla_costos(object sender, EventArgs e)
        {
            IPlanillaCostoVista planilla = PlanillaCostoVista.ObtenerInstancia();
            ICiudadRepositorio ciudad = new CiudadRepositorio();
            IImporteCiudadRepositorio importeCiudad = new ImporteCiudadRepositorio();
            IImporteCuadrasRepositorio importeCuadras = new ImporteCuadraRepositorio();
            new PlanillaCostoPresentador(planilla, ciudad, importeCuadras, importeCiudad, this.rol, this.id);
            ((Form)vista).Close();
        }

        /// <summary>
        /// Abre el formulario para agregar una nueva pregunta.
        /// </summary>
        public void agregar_pregunta(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una categoría antes de agregar una pregunta.");
                return;
            }

            IAgregarAyudaVistaPregunta vistaAgregar = AgregarAyudaVistaPregunta.ObtenerInstancia();
            new CUAyudaPresentador.CUAgregarPreguntaPresentador(this.repositorioPregunta, vistaAgregar, this.vista, IdCategoriaSeleccionada.Value, this);
            ((Form)vistaAgregar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar la pregunta seleccionada.
        /// </summary>
        public void modificar_pregunta(object sender, EventArgs e)
        {
            if (IdPreguntaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una pregunta para modificar.");
                return;
            }

            var preguntaDTO = modeloPregunta.FirstOrDefault(p => p.IdPregunta == IdPreguntaSeleccionada.Value);
            if (preguntaDTO == null)
            {
                MessageBox.Show("La pregunta seleccionada no existe.");
                return;
            }

            IModificarAyudaVistaPregunta vistaModificar = ModificarAyudaVistaPregunta.ObtenerInstancia();
            new CUAyudaPresentador.CUModificarPreguntaPresentador(this.repositorioPregunta, vistaModificar, this.vista, preguntaDTO, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Elimina la pregunta seleccionada junto con sus respuestas.
        /// </summary>
        public void eliminar_pregunta(object sender, EventArgs e)
        {
            if (IdPreguntaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una pregunta para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta pregunta y sus respuestas?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                var respuestas = this.repositorioRespuesta.MostrarTodo()
                    .Where(r => r.IdPregunta == IdPreguntaSeleccionada.Value)
                    .ToList();

                foreach (var respuesta in respuestas)
                    this.repositorioRespuesta.Eliminar(respuesta.IdRespuesta);

                this.repositorioPregunta.Eliminar(IdPreguntaSeleccionada.Value);

                modeloPregunta = this.repositorioPregunta.MostrarTodo()
                    .Where(p => p.IdCategoria == IdCategoriaSeleccionada)
                    .ToList();
                vista.SetPreguntaBindingSource(new BindingSource { DataSource = modeloPregunta });

                modeloRespuesta.Clear();
                vista.SetRespuestaBindingSource(new BindingSource());

                IdPreguntaSeleccionada = null;
                RefrescarModelos();
            }
        }

        /// <summary>
        /// Abre el formulario para agregar una nueva respuesta.
        /// </summary>
        public void agregar_respuesta(object sender, EventArgs e)
        {
            if (IdPreguntaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una pregunta antes de agregar una respuesta.");
                return;
            }

            IAgregarAyudaVistaRespuesta vistaAgregar = AgregarAyudaVistaRespuesta.ObtenerInstancia();
            new CUAyudaPresentador.CUAgregarRespuestaPresentador(this.repositorioRespuesta, vistaAgregar, this.vista, IdPreguntaSeleccionada.Value, this);
            ((Form)vistaAgregar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar la respuesta seleccionada.
        /// </summary>
        private void modificar_respuesta(int idRespuesta)
        {
            var dto = modeloRespuesta.FirstOrDefault(r => r.IdRespuesta == idRespuesta);
            if (dto == null)
            {
                MessageBox.Show("La respuesta seleccionada no existe.");
                return;
            }

            IModificarAyudaVistaRespuesta vistaModificar = ModificarAyudaVistaRespuesta.ObtenerInstancia();
            new CUAyudaPresentador.CUModificarRespuestaPresentador(this.repositorioRespuesta, vistaModificar, this.vista, dto, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Elimina la respuesta seleccionada.
        /// </summary>
        private void eliminar_respuesta(int idRespuesta)
        {
            var dto = modeloRespuesta.FirstOrDefault(r => r.IdRespuesta == idRespuesta);
            if (dto == null)
            {
                MessageBox.Show("La respuesta seleccionada no existe.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta respuesta?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                this.repositorioRespuesta.Eliminar(idRespuesta);

                var modeloActualizado = this.repositorioRespuesta.MostrarTodo()
                    .Where(r => r.IdPregunta == dto.IdPregunta)
                    .ToList();

                vista.SetRespuestaBindingSource(new BindingSource { DataSource = modeloActualizado });
                RefrescarModelos();
            }
        }

        /// <summary>
        /// Abre el formulario para agregar una nueva categoría.
        /// </summary>
        public void agregar_categoria(object sender, EventArgs e) 
        {
            IAgregarAyudaVistaCategoria agregarCategoria = AgregarAyudaVistaCategoria.ObtenerInstancia();
            new CUAgregarCategoriaPresentador(this.repositorioCategoria, agregarCategoria,this.vista, this, this.rol);
            ((Form)agregarCategoria).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar la categoría seleccionada.
        /// </summary>
        public void modificar_categoria(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una categoría para modificar.");
                return;
            }

            var categoriaDTO = modeloCategoria.FirstOrDefault(c => c.IdCategoria == IdCategoriaSeleccionada.Value);
            if (categoriaDTO == null)
            {
                MessageBox.Show("La categoría seleccionada no existe.");
                return;
            }

            IModificarAyudaVistaCategoria vistaModificar = ModificarAyudaVistaCategoria.ObtenerInstancia();
            new CUAyudaPresentador.CUModificarCategoriaPresentador(this.repositorioCategoria, vistaModificar, ayudavista: this.vista, categoriaDTO, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Elimina la categoría seleccionada junto con sus preguntas y respuestas.
        /// </summary>
        public void eliminar_categoria(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una categoría para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta categoría y todo su contenido?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                var preguntas = this.repositorioPregunta.MostrarTodo()
                    .Where(p => p.IdCategoria == IdCategoriaSeleccionada.Value)
                    .ToList();

                foreach (var pregunta in preguntas)
                {
                    var respuestas = this.repositorioRespuesta.MostrarTodo()
                        .Where(r => r.IdPregunta == pregunta.IdPregunta)
                        .ToList();

                    foreach (var respuesta in respuestas)
                        this.repositorioRespuesta.Eliminar(respuesta.IdRespuesta);

                    this.repositorioPregunta.Eliminar(pregunta.IdPregunta);
                }

                this.repositorioCategoria.Eliminar(IdCategoriaSeleccionada.Value);

                modeloCategoria = this.repositorioCategoria.ObtenerTodas().ToList();
                vista.SetCategoriaBindingSource(new BindingSource { DataSource = modeloCategoria });

                modeloPregunta.Clear();
                vista.SetPreguntaBindingSource(new BindingSource());

                modeloRespuesta.Clear();
                vista.SetRespuestaBindingSource(new BindingSource());

                IdCategoriaSeleccionada = null;
                IdPreguntaSeleccionada = null;
                RefrescarModelos();
            }
        }

        /// <summary>
        /// Cierra la vista actual y retorna al menú de inicio.
        /// </summary>
        public void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
