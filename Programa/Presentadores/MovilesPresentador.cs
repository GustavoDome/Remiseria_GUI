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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void agregar_movil(object sender, EventArgs e)
        {
            //IAgregarMovilVista agregarVista = AgregarMovilVista.ObtenerInstancia(id);
            //new AgregarMovilPresentador(agregarVista, repositorio, id);
        }

        private void modificar_movil(object sender, EventArgs e)
        {
            int idMovil = vista.ObtenerIdMovilSeleccionado();
            //IModificarMovilVista modificarVista = ModificarMovilVista.ObtenerInstancia(idMovil);
            //new ModificarMovilPresentador(modificarVista, repositorio, idMovil);
            cargar_moviles();
        }

        private void eliminar_movil(object sender, EventArgs e)
        {
            int idMovil = vista.ObtenerIdMovilSeleccionado();
            repositorio.Eliminar(idMovil); // si usás borrado lógico, ajustá aquí
            cargar_moviles();
        }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
