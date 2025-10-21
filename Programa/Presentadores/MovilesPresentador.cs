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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Programa.Presentadores.CUPresentador.CUMovilesPresentador;

namespace Programa.Presentadores
{
    /// <summary>
    /// Presentador encargado de gestionar la vista de móviles.
    /// Coordina la carga, modificación, eliminación y visualización de móviles registrados.
    /// </summary>
    public class MovilesPresentador
    {
        private readonly IMovilesVista vista;
        private readonly IMovilRepositorio repositorio;
        private readonly BindingSource filtrador;
        private readonly int id;

        /// <summary>
        /// Inicializa el presentador con la vista de móviles, el repositorio y el identificador del operador.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IMovilesVista"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IMovilRepositorio"/>.</param>
        /// <param name="id">Identificador del operador actual.</param>
        public MovilesPresentador(IMovilesVista vista, IMovilRepositorio repositorio, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.id = id;
            this.filtrador = new BindingSource();

            vista.SetMovilesBindingSource(filtrador);
            cargar_moviles();

            vista.agregarMovil += agregar_movil;
            vista.modificarMovil += modificar_movil;
            vista.eliminarMovil += eliminar_movil;
            vista.volver += volver_menu;
        }

        /// <summary>
        /// Carga todos los móviles desde el repositorio y los vincula al BindingSource de la vista.
        /// </summary>
        private void cargar_moviles()
        {
            var lista = repositorio.ObtenerTodos().ToList(); // usa DTO
            filtrador.DataSource = lista;

            if (vista is MovilesVista vistaConcreta)
            {
                vistaConcreta.configurarGrilla();
            }
        }

        /// <summary>
        /// Recarga la lista de móviles en la vista.
        /// </summary>
        public void Recargar()
        {
            cargar_moviles();
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo móvil.
        /// </summary>
        private void agregar_movil(object sender, EventArgs e)
        {
            IAgregarMovilesVista vistaAgregar = AgregarMovilesVista.ObtenerInstancia();
            new CUMovilesPresentador.CUAgregarMovilesPresentador(vistaAgregar, repositorio, this);
            ((Form)vistaAgregar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el móvil seleccionado.
        /// </summary>
        private void modificar_movil(object sender, EventArgs e)
        {
            try 
            {
                int idMovil = vista.ObtenerIdMovilSeleccionado();
                var movilSeleccionado = repositorio.ObtenerTodos().FirstOrDefault(m => m.IdMovil == idMovil);
                if (idMovil == 0)
                {
                    MessageBox.Show("Debe seleccionar un móvil válido para modificar.");
                    return;
                }
                IModificarMovilesVista vistaModificar = ModificarMovilesVista.ObtenerInstancia();
                new CUModificarMovilPresentador(vistaModificar, repositorio, movilSeleccionado, this);
                ((Form)vistaModificar).ShowDialog();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                while (inner?.InnerException != null)
                    inner = inner.InnerException;

                MessageBox.Show("Error interno: " + (inner?.Message ?? ex.Message));
                throw;
            }
        }

        /// <summary>
        /// Elimina el móvil seleccionado previa confirmación del usuario.
        /// </summary>
        private void eliminar_movil(object sender, EventArgs e)
        {
            int idMovil = vista.ObtenerIdMovilSeleccionado();
            var movil = repositorio.ObtenerTodos().FirstOrDefault(m => m.IdMovil == idMovil);

            if (movil == null)
            {
                MessageBox.Show("Debe seleccionar un móvil válido para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar el móvil número {movil.NumeroMovil}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            repositorio.Eliminar(idMovil);
            cargar_moviles();
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
