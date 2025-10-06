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
    public class MovilesPresentador
    {
        private readonly IMovilesVista vista;
        private readonly IMovilRepositorio repositorio;
        private readonly BindingSource filtrador;
        private readonly int id;

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

        private void cargar_moviles()
        {
            var lista = repositorio.ObtenerTodos().ToList(); // usa DTO
            filtrador.DataSource = lista;

            if (vista is MovilesVista vistaConcreta)
            {
                vistaConcreta.configurarGrilla();
            }
        }
        public void Recargar()
        {
            cargar_moviles();
        }

        private void agregar_movil(object sender, EventArgs e)
        {
            IAgregarMovilesVista vistaAgregar = AgregarMovilesVista.ObtenerInstancia();
            new CUMovilesPresentador.CUAgregarMovilesPresentador(vistaAgregar, repositorio, this);
            ((Form)vistaAgregar).ShowDialog();
        }

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

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
