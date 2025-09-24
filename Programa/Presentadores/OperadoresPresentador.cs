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
    public class OperadoresPresentador
    {
        private readonly IOperadoresVista vista;
        private readonly IOperadorRepositorio repositorio;
        private readonly BindingSource filtrador;
        private readonly int id;

        public OperadoresPresentador(IOperadoresVista vista, IOperadorRepositorio repositorio, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.id = id;
            this.filtrador = new BindingSource();

            vista.SetOperadoresBindingSource(filtrador);
            cargar_operadores();

            vista.agregarOperador += agregar_operador;
            vista.modificiarOperador += modificar_operador;
            vista.eliminarOperador += eliminar_operador;
            vista.volver += volver_menu;
        }

        private void cargar_operadores()
        {
            var lista = repositorio.MostrarActivos().ToList(); // solo operadores activos
            filtrador.DataSource = lista;
        }

        private void agregar_operador(object sender, EventArgs e)
        {
            //IAgregarOperadorVista agregarVista = AgregarOperadorVista.ObtenerInstancia(id);
            //new AgregarOperadorPresentador(agregarVista, repositorio, id);
        }

        private void modificar_operador(object sender, EventArgs e)
        {
            int idOperador = vista.ObtenerIdOperadorSeleccionado();
            //IModificarOperadorVista modificarVista = ModificarOperadorVista.ObtenerInstancia(idOperador);
            //new ModificarOperadorPresentador(modificarVista, repositorio, idOperador);
            //cargar_operadores();
        }

        private void eliminar_operador(object sender, EventArgs e)
        {
            int idOperador = vista.ObtenerIdOperadorSeleccionado();
            repositorio.Eliminar(idOperador);
            cargar_operadores();
        }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
