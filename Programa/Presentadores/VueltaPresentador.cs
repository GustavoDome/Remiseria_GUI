using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Presentadores.CUPresentador;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Alta;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    /// <summary>
    /// Presentador encargado de gestionar la vista de vueltas.
    /// Coordina la visualización, creación, modificación y eliminación de vueltas manuales por móvil.
    /// </summary>
    public class VueltaPresentador
    {
        private readonly IVueltaVista vista;
        private readonly IViajesRepositorio repositorio;
        private readonly BindingSource filtrador;
        private DateTime fechaActual;
        private readonly string rol;
        private readonly int id;

        /// <summary>
        /// Inicializa el presentador con la vista de vueltas, el repositorio de viajes, el rol y el identificador del operador.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IVueltaVista"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IViajesRepositorio"/>.</param>
        /// <param name="rol">Rol del operador.</param>
        /// <param name="id">Identificador del operador.</param>
        public VueltaPresentador(IVueltaVista vista, IViajesRepositorio repositorio, string rol, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();
            this.fechaActual = DateTime.Today;

            vista.ocultarBotones(rol);
            vista.SetViajesBindingSource(filtrador);
            vista.SetFecha(fechaActual);

            cargar_vueltas();

            vista.agregarVuelta += agregar_vuelta;
            vista.modificarVuelta += modificar_vuelta;
            vista.eliminarVuelta += eliminar_vuelta;
            vista.agregarMovil += agregar_movil;
            vista.eliminarMovil += eliminar_movil;
            vista.retroceder += retroceder_dia;
            vista.adelantar += adelantar_dia;
            vista.ingresarViaje += ingresar_viaje;
            vista.volver += volver_menu;
        }

        /// <summary>
        /// Carga las vueltas registradas para la fecha actual y configura la grilla y los móviles disponibles.
        /// </summary>
        private void cargar_vueltas()
        {
            var tabla = repositorio.MostrarVuelta(fechaActual);

            if (tabla.Rows.Count == 0)
            {
                vista.MostrarMensaje("No hay vueltas registradas para esta fecha.");
            }

            filtrador.DataSource = tabla;
            if (vista is Form formulario)
            {
                var dgv = formulario.Controls.OfType<DataGridView>().FirstOrDefault(c => c.Name == "dgvVuelta");
                if (dgv != null)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.Name.StartsWith("IdVuelta "))
                            col.Visible = false;
                    }
                }
            }

            var moviles = repositorio.ObtenerMovilesDelDia(fechaActual);
            vista.ConfigurarMoviles(moviles);
        }

        /// <summary>
        /// Agrega una nueva vuelta manual para el móvil seleccionado.
        /// </summary>
        private void agregar_vuelta(object sender, EventArgs e)
        {
            int idMovil = vista.ObtenerIdMovilSeleccionado();
            vista.MostrarMensaje($"Móvil {idMovil}");

            if (idMovil == 0)
            {
                vista.MostrarMensaje("Debe seleccionar una celda de móvil para agregar vuelta.");
                return;
            }

            int numeroVuelta = repositorio.ObtenerProximoNumeroDeVuelta(idMovil, fechaActual);

            // Obtener el número visual del móvil para mostrarlo correctamente
            int numeroMovil = vista.ObtenerNumeroMovilSeleccionado(); // ← esta función debe devolver el número desde el encabezado

            if (repositorio.MovilYaTieneVuelta(idMovil, fechaActual, numeroVuelta))
            {
                vista.MostrarMensaje("El móvil ya tiene una vuelta en ese número.");
                return;
            }

            var dto = new VueltaDTO
            {
                IdViaje = 0,
                IdMovil = idMovil,
                NumeroVuelta = numeroVuelta,
                VueltaFecha = fechaActual,
                EstadoVuelta = "X"
            };

            try
            {
                repositorio.AgregarVueltaManual(dto);
                cargar_vueltas();
            }
            catch (Exception ex)
            {
                var inner = ex;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                MessageBox.Show("Error interno: " + inner.Message);
                throw;
            }
        }

        /// <summary>
        /// Modifica el estado de la vuelta seleccionada.
        /// </summary>
        private void modificar_vuelta(object sender, EventArgs e)
        {
            int idVuelta = vista.ObtenerIdVueltaSeleccionada();

            if (idVuelta == 0)
            {
                vista.MostrarMensaje("Debe seleccionar una vuelta válida para modificar.");
                return;
            }

            try
            {
                bool modificado = repositorio.CambiarEstadoVuelta(idVuelta);
                if (!modificado)
                {
                    vista.MostrarMensaje("No se pudo modificar el estado de la vuelta.");
                    return;
                }

                cargar_vueltas();
            }
            catch (Exception ex)
            {
                vista.MostrarMensaje("Error al modificar vuelta: " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina la última vuelta registrada del móvil seleccionado.
        /// </summary>
        private void eliminar_vuelta(object sender, EventArgs e)
        {
            int idMovil = vista.ObtenerIdMovilSeleccionado();
            if (idMovil == 0)
            {
                vista.MostrarMensaje("Debe seleccionar un móvil para eliminar su última vuelta.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar la última vuelta de este móvil?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                repositorio.EliminarUltimaVueltaDeMovil(idMovil, fechaActual);
                cargar_vueltas();
            }
            catch (Exception ex)
            {
                vista.MostrarMensaje("Error al eliminar última vuelta: " + ex.Message);
            }
        }

        /// <summary>
        /// Abre el formulario para agregar un móvil a la grilla de vueltas.
        /// </summary>
        private void agregar_movil(object sender, EventArgs e)
        {
            IAgregarVueltaVista popup = AgregarVueltaVista.ObtenerInstancia();
            var presentador = new CUVueltaPresentador(popup, this.repositorio, fechaActual, () => cargar_vueltas());

            ((Form)popup).ShowDialog();
        }

        /// <summary>
        /// Elimina la vuelta seleccionada previa confirmación.
        /// </summary>
        private void eliminar_movil(object sender, EventArgs e)
        {
            int idVuelta = vista.ObtenerIdVueltaSeleccionada();

            if (idVuelta == 0)
            {
                vista.MostrarMensaje("Debe seleccionar una vuelta válida para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar esta vuelta?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                repositorio.EliminarVuelta(idVuelta);
                cargar_vueltas();
            }
            catch (Exception ex)
            {
                vista.MostrarMensaje("Error al eliminar móvil de la vuelta: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrocede un día en la vista de vueltas.
        /// </summary>
        private void retroceder_dia(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(-1);
            vista.SetFecha(fechaActual);
            cargar_vueltas();
        }

        /// <summary>
        /// Avanza un día en la vista de vueltas, evitando fechas futuras.
        /// </summary>
        private void adelantar_dia(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            if (fechaActual >= hoy)
            {
                vista.MostrarMensaje("No se puede avanzar a días futuros.");
                return;
            }

            fechaActual = fechaActual.AddDays(1);
            vista.SetFecha(fechaActual);
            cargar_vueltas();
        }

        /// <summary>
        /// Navega al módulo de viajes desde la vista de vueltas.
        /// </summary>
        private void ingresar_viaje(object sender, EventArgs e)
        {
            IViajesVista viajesvista = ViajesVista.ObtenerInstancia(rol, id);
            IViajesRepositorio viajes = new ViajesRepositorio();
            new ViajesPresentador(viajesvista, viajes, rol, id);
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
