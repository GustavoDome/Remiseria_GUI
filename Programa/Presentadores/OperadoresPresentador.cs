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
using static Programa.Presentadores.CUPresentador.CUOperadorPresentador;

namespace Programa.Presentadores
{
    /// <summary>
    /// Presentador encargado de gestionar la vista de operadores.
    /// Coordina la carga, modificación, eliminación y visualización de operadores activos.
    /// </summary>
    public class OperadoresPresentador
    {
        private readonly IOperadoresVista vista;
        private readonly IOperadorRepositorio repositorio;
        private readonly BindingSource filtrador;
        private readonly int id;

        /// <summary>
        /// Inicializa el presentador con la vista de operadores, el repositorio y el identificador del operador actual.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IOperadoresVista"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IOperadorRepositorio"/>.</param>
        /// <param name="id">Identificador del operador en sesión.</param>
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

        /// <summary>
        /// Carga todos los operadores activos desde el repositorio y los vincula al BindingSource de la vista.
        /// </summary>
        private void cargar_operadores()
        {
            var lista = repositorio.MostrarActivos().ToList(); // solo operadores activos
            filtrador.DataSource = lista;

            if (vista is OperadoresVista vistaConcreta)
            {
                vistaConcreta.configurarGrilla();
            }
        }

        /// <summary>
        /// Recarga la lista de operadores en la vista.
        /// </summary>
        public void Recargar()
        {
            cargar_operadores();
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo operador.
        /// </summary>
        private void agregar_operador(object sender, EventArgs e)
        {
            IAgregarOperadoresVista vistaAgregar = AgregarOperadoresVista.ObtenerInstancia();
            new CUOperadorPresentador.CUAgregarOperadorPresentador(vistaAgregar, repositorio, this);
            ((Form)vistaAgregar).ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para modificar el operador seleccionado, evitando que se modifique el operador en sesión.
        /// </summary>
        private void modificar_operador(object sender, EventArgs e)
        {
            int idOperador = vista.ObtenerIdOperadorSeleccionado();

            if (idOperador == this.id)
            {
                MessageBox.Show("No puede modificar el operador que está actualmente en uso.");
                return;
            }
            var operador = repositorio.ObtenerTodos().FirstOrDefault(o => o.IdOperador == idOperador);
            if (operador == null)
            {
                MessageBox.Show("Debe seleccionar un operador válido.");
                return;
            }

            IModificarOperadorVista vistaModificar = ModificarOperadorVista.ObtenerInstancia();
            new CUModificarOperadorPresentador(vistaModificar, repositorio, operador, this);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Elimina el operador seleccionado previa confirmación, evitando que se elimine el operador en sesión.
        /// </summary>
        private void eliminar_operador(object sender, EventArgs e)
        {
            int idOperador = vista.ObtenerIdOperadorSeleccionado();

            if (idOperador == this.id)
            {
                MessageBox.Show("No puede eliminar el operador que está actualmente en uso.");
                return;
            }

            var operador = repositorio.ObtenerTodos().FirstOrDefault(o => o.IdOperador == idOperador);
            var nombre = operador?.Nombre ?? "el operador seleccionado";

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar a {nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                repositorio.Eliminar(idOperador);
                cargar_operadores();
            }
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
