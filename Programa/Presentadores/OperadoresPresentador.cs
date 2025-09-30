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
        public void Recargar()
        {
            cargar_operadores();
        }
        private void agregar_operador(object sender, EventArgs e)
        {
            IAgregarOperadoresVista vistaAgregar = AgregarOperadoresVista.ObtenerInstancia();
            new CUOperadorPresentador.CUAgregarOperadorPresentador(vistaAgregar, repositorio, this);
        }

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
        }

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

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
