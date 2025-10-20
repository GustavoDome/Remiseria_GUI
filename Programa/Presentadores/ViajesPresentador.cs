using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Alta;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using Programa.Vistas.Modificacion;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Programa.Presentadores.CUPresentador.CUViajesPresentador;

namespace Programa.Presentadores
{
    /// <summary>
    /// Presentador encargado de gestionar la vista de viajes.
    /// Coordina la visualización, creación, modificación, eliminación y navegación de viajes diarios.
    /// </summary>
    public class ViajesPresentador
    {
        private readonly IViajesVista vista;
        private readonly IViajesRepositorio repositorio;
        private readonly BindingSource filtrador;
        private DateTime fechaActual;
        private readonly string rol;
        private readonly int id;

        /// <summary>
        /// Inicializa el presentador con la vista de viajes, el repositorio, el rol y el identificador del operador.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IViajesVista"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IViajesRepositorio"/>.</param>
        /// <param name="rol">Rol del operador.</param>
        /// <param name="id">Identificador del operador.</param>
        public ViajesPresentador(IViajesVista vista, IViajesRepositorio repositorio, string rol, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();
            this.fechaActual = DateTime.Today;

            this.vista.ocultarBotones(this.rol);
            this.vista.SetViajesBindingSource(this.filtrador);
            this.vista.SetFecha(this.fechaActual);

            cargar_datos();

            this.vista.agregarViaje += agregar_viaje;
            this.vista.modificarViaje += modificar_viaje;
            this.vista.cambiarEstadoViaje += cambiar_estado_viaje;
            this.vista.eliminarViaje += eliminar_viaje;
            this.vista.retroceder += retroceder_dia;
            this.vista.adelantar += adelantar_dia;
            this.vista.ingresarVuelta += ingresar_vuelta;
            this.vista.volver += volver_menu;
            this.vista.recargar += cargar_datos;
        }

        /// <summary>
        /// Identificador del operador en sesión.
        /// </summary>
        public int IdOperador => id;

        /// <summary>
        /// Recarga la vista con los viajes del día actual.
        /// </summary>
        public void RecargarVista()
        {
            vista.SetFecha(fechaActual);
            var tabla = repositorio.MostrarTodo(fechaActual);
            filtrador.DataSource = tabla;
            vista.congelarVista();
            vista.OcultarIdViaje();
        }

        /// <summary>
        /// Carga los datos de viajes para la fecha actual.
        /// </summary>
        private void cargar_datos(object sender = null, EventArgs e = null)
        {
            var tabla = repositorio.MostrarTodo(fechaActual);
            filtrador.DataSource = tabla;
            vista.congelarVista();
            vista.OcultarIdViaje();
        }

        /// <summary>
        /// Calcula el siguiente número de viaje disponible para el día actual.
        /// </summary>
        /// <returns>Entero con el número de viaje siguiente.</returns>
        public int ObtenerSiguienteNumeroViaje()
        {
            var tabla = filtrador.DataSource as DataTable;
            if (tabla == null || tabla.Rows.Count == 0 || !tabla.Columns.Contains("N° Viaje"))
                return 1;

            var max = tabla.AsEnumerable()
                .Select(row =>
                {
                    var valor = row["N° Viaje"];
                    if (valor == DBNull.Value || valor == null) return 0;
                    if (int.TryParse(valor.ToString(), out int n)) return n;
                    return 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return max + 1;
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo viaje.
        /// </summary>
        private void agregar_viaje(object sender, EventArgs e)
        {
            int numeroViaje = ObtenerSiguienteNumeroViaje();
            IAgregarViajesVista agregarViajesVista = AgregarViajesVista.ObtenerInstancia(numeroViaje, this.id, this.rol);

            // Crear el presentador primero
            new CUAgregarViajePresentador(agregarViajesVista, this.repositorio, this.fechaActual, this);

            // Mostrar la vista como modal después
            ((Form)agregarViajesVista).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el viaje seleccionado.
        /// </summary>
        private void modificar_viaje(object sender, EventArgs e)
        {
            int idViaje = vista.ObtenerIdViajeSeleccionado();
            if (idViaje == 0)
            {
                MessageBox.Show("Debe seleccionar un viaje para modificar.");
                return;
            }

            IModificarViajesVista modificarVista = ModificarViajesVista.ObtenerInstancia();
            new CUModificarViajePresentador(modificarVista, this.repositorio, idViaje, this);
            ((Form)modificarVista).ShowDialog();
        }

        /// <summary>
        /// Cambia el estado del viaje seleccionado.
        /// </summary>
        private void cambiar_estado_viaje(object sender, EventArgs e)
        {
            int idViaje = vista.ObtenerIdViajeSeleccionado();
            if (idViaje == 0)
            {
                MessageBox.Show("Debe seleccionar un viaje para cambiar su estado.");
                return;
            }

            try
            {
                repositorio.CambiarEstado(idViaje);
                RecargarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado del viaje: " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina el viaje seleccionado previa confirmación.
        /// </summary>
        private void eliminar_viaje(object sender, EventArgs e)
        {
            int idViaje = vista.ObtenerIdViajeSeleccionado();
            if (idViaje == 0)
            {
                MessageBox.Show("Debe seleccionar un viaje para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este viaje?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            repositorio.Eliminar(idViaje);
            cargar_datos();
        }

        /// <summary>
        /// Retrocede un día en la vista de viajes.
        /// </summary>
        private void retroceder_dia(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(-1);
            vista.SetFecha(fechaActual);
            cargar_datos();
        }

        /// <summary>
        /// Avanza un día en la vista de viajes, evitando fechas futuras.
        /// </summary>
        private void adelantar_dia(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            if (fechaActual >= hoy)
            {
                MessageBox.Show("No se puede avanzar a días futuros.");
                return;
            }

            fechaActual = fechaActual.AddDays(1);
            vista.SetFecha(fechaActual);
            cargar_datos();
        }

        /// <summary>
        /// Navega al módulo de vueltas desde la vista de viajes.
        /// </summary>
        private void ingresar_vuelta(object sender, EventArgs e)
        {
            IVueltaVista vueltaVista = VueltaVista.ObtenerInstancia();
            IViajesRepositorio repo = new ViajesRepositorio();
            new VueltaPresentador(vueltaVista, repo, rol, id);
            ((Form)vista).Close();
        }

        /// <summary>
        /// Cierra la vista actual y retorna al menú de inicio.
        /// </summary>
        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
