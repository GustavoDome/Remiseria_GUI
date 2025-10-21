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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    /// <summary>
    /// Presentador encargado de gestionar la lógica de interacción entre la vista de bases y el repositorio.
    /// Coordina eventos de la interfaz, operaciones CRUD y visualización de móviles.
    /// </summary>
    public class BasesPresentador
    {
        private readonly IBasesVista vista;
        private readonly IBasesRepositorio repositorio;
        private readonly BindingSource filtrador;
        private readonly BindingSource tablaBases;
        private readonly string rol;
        private readonly int id;
        public int id_movil;

        /// <summary>
        /// Inicializa el presentador con la vista, el repositorio, el rol del operador y su identificador.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IBasesVista"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IBasesRepositorio"/>.</param>
        /// <param name="rol">Rol del operador (por ejemplo: "Gerente").</param>
        /// <param name="id">Identificador del operador actual.</param>
        public BasesPresentador(IBasesVista vista, IBasesRepositorio repositorio, string rol, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();
            this.tablaBases = new BindingSource();
            id_movil = vista.id_movil;

            vista.ocultarBotones(rol);
            vista.mostrarMoviles(filtrador);
            cargarMoviles();

            if (vista.id_movil > 0)
                vista_OnMovilSeleccionado(this, EventArgs.Empty);

            vista.agregarBase += agregar_base;
            vista.modificarBase += modificar_base;
            vista.comentarBase += comentar_base;
            vista.eliminarBase += eliminar_base;
            vista.volver += volver_menu;
            vista.OnMovilSeleccionado += vista_OnMovilSeleccionado;
        }

        /// <summary>
        /// Carga los móviles disponibles y los muestra en formato transpuesto en la vista.
        /// </summary>
        private void cargarMoviles()
        {
            var listaIds = repositorio.SeleccionarMovil().ToList();
            var dtOriginal = ConvertListToDataTable(listaIds);
            var dtTranspuesta = TransponerDataTable(dtOriginal);
            filtrador.DataSource = dtTranspuesta;
            vista.mostrarMoviles(filtrador);
        }

        /// <summary>
        /// Evento que se dispara al seleccionar un móvil. Carga las bases asociadas.
        /// </summary>
        public void vista_OnMovilSeleccionado(object sender, EventArgs e)
        {
            var listaBases = repositorio.MostrarTodo(vista.id_movil).ToList();
            vista.mostrarBases(listaBases);
        }

        /// <summary>
        /// Lógica para agregar una nueva base. Verifica selección de móvil y abre el formulario correspondiente.
        /// </summary>
        private void agregar_base(object sender, EventArgs e)
        {
            if (vista.id_movil == 0)
            {
                MessageBox.Show("Debe seleccionar un móvil antes de agregar una base.");
                return;
            }

            IAgregarBasesVista vistaAgregar = AgregarBasesVista.ObtenerInstancia();
            new CUBasesPresentador.CUAgregarBasePresentador(repositorio, vistaAgregar, id, vista.id_movil, this, this.vista);
            ((Form)vistaAgregar).ShowDialog();
        }

        /// <summary>
        /// Lógica para modificar una base existente. Abre el formulario de edición con los datos seleccionados.
        /// </summary>
        private void modificar_base(object sender, EventArgs e)
        {
            var baseId = vista.ObtenerBaseSeleccionada();
            if (baseId == null)
            {
                MessageBox.Show("Debe seleccionar una base.");
                return;
            }

            var baseSeleccionada = repositorio.MostrarTodo(vista.id_movil).FirstOrDefault(b => b.IdBase == baseId.Value);
            IModificarBasesVista vistaModificar = ModificarBasesVista.ObtenerInstancia();
            new CUBasesPresentador.CUModificarBasePresentador(repositorio, vistaModificar, id, baseSeleccionada, this, vista.id_movil);
            ((Form)vistaModificar).ShowDialog();
        }

        /// <summary>
        /// Lógica para agregar un comentario a una base seleccionada.
        /// </summary>
        private void comentar_base(object sender, EventArgs e)
        {
            var baseId = vista.ObtenerBaseSeleccionada();
            if (baseId == null)
            {
                MessageBox.Show("Debe seleccionar una base.");
                return;
            }
            var baseSeleccionada = repositorio.MostrarTodo(vista.id_movil).FirstOrDefault(b => b.IdBase == baseId.Value);
            BaseDetalleDTO baseseleccion = baseSeleccionada;
            IAgregarBasesVistaComentario vistaComentario = AgregarBasesVistaComentario.ObtenerInstancia();
            new CUBasesPresentador.CUComentarioBasePresentador(repositorio, vistaComentario, baseseleccion, this);
            ((Form)vistaComentario).ShowDialog();
        }

        /// <summary>
        /// Lógica para eliminar una base seleccionada, con confirmación previa.
        /// </summary>
        private void eliminar_base(object sender, EventArgs e)
        {
            var baseId = vista.ObtenerBaseSeleccionada();
            if (baseId == null)
            {
                MessageBox.Show("Debe seleccionar una base.");
                return;
            }
            var baseSeleccionada = repositorio.MostrarTodo(id_movil).FirstOrDefault(b => b.IdBase == baseId.Value);
            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar esta base?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                repositorio.Eliminar(baseSeleccionada.IdBase);
                vista_OnMovilSeleccionado(this, EventArgs.Empty); // recarga la grilla
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

        /// <summary>
        /// Convierte una lista de móviles en un DataTable para visualización.
        /// </summary>
        /// <param name="lista">Lista de <see cref="MovilResumenDTO"/>.</param>
        /// <returns>DataTable con columnas IdMovil y NumeroMovil.</returns>
        private DataTable ConvertListToDataTable(IEnumerable<MovilResumenDTO> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("IdMovil", typeof(int));
            dt.Columns.Add("NumeroMovil", typeof(int));

            foreach (var item in lista)
            {
                var row = dt.NewRow();
                row["IdMovil"] = item.IdMovil;
                row["NumeroMovil"] = item.NumeroMovil;
                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// Transpone un DataTable para mostrar propiedades como filas y móviles como columnas.
        /// </summary>
        /// <param name="original">DataTable original.</param>
        /// <returns>DataTable transpuesto.</returns>
        private DataTable TransponerDataTable(DataTable original)
        {
            DataTable transpuesta = new DataTable();

            transpuesta.Columns.Add("Propiedad");
            for (int i = 0; i < original.Rows.Count; i++)
                transpuesta.Columns.Add($"Móvil {i + 1}");

            foreach (DataColumn col in original.Columns)
            {
                DataRow newRow = transpuesta.NewRow();
                newRow[0] = col.ColumnName;
                for (int i = 0; i < original.Rows.Count; i++)
                    newRow[i + 1] = original.Rows[i][col];
                transpuesta.Rows.Add(newRow);
            }

            return transpuesta;
        }
    }
}
