using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Interfaces;
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
    public class BasesPresentador
    {
        private IBasesRepositorio repositorio;
        private IBasesVista vista;
        private IEnumerable<BasesModelo> movilModelos;
        private BindingSource filtrador;
        private BindingSource tablaMoviles;

        public BasesPresentador(IBasesVista vista, IBasesRepositorio repositorio)
        {
            this.filtrador = new BindingSource();
            this.tablaMoviles = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            this.vista.mostrarMoviles(this.filtrador);
            mostrarMoviles();

            this.vista.agregarBase += agregar_base;
            this.vista.modificarBase += modificar_base;
            this.vista.comentarBase += comentar_base;
            this.vista.eliminarBase += eliminar_base;
            this.vista.volver += voler_menu;
            this.vista.OnMovilSeleccionado += vista_OnMovilSeleccionado;

        }
        public DataTable ConvertListToDataTable(IEnumerable<MovilModeloId> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id_movil");

            foreach (var item in lista)
            {
                var row = dt.NewRow();
                row["Id_movil"] = item.Id_movil;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public DataTable TransponerDataTable(DataTable original)
        {
            DataTable transpuesta = new DataTable();

            // La primera columna es el nombre de la propiedad
            transpuesta.Columns.Add("Propiedad");

            // Cada fila del DataTable original será una columna en el nuevo DataTable
            for (int i = 0; i < original.Rows.Count; i++)
            {
                transpuesta.Columns.Add($"Valor {i + 1}");
            }

            // Por cada columna en original (solo 1 en este caso: "Id_movil")
            foreach (DataColumn col in original.Columns)
            {
                DataRow newRow = transpuesta.NewRow();
                newRow[0] = col.ColumnName;

                // Agregar el valor de cada fila original como columna en la fila transpuesta
                for (int i = 0; i < original.Rows.Count; i++)
                {
                    newRow[i + 1] = original.Rows[i][col];
                }

                transpuesta.Rows.Add(newRow);
            }

            return transpuesta;
        }

        private void mostrarMoviles()
        {
            var listaIds = this.repositorio.seleccionarMovil().ToList();
            DataTable dtOriginal = ConvertListToDataTable(listaIds);
            DataTable dtTranspuesta = TransponerDataTable(dtOriginal);
            this.filtrador.DataSource = dtTranspuesta;
        }
        private void vista_OnMovilSeleccionado(object sender, EventArgs e)
        {
            int id = vista.id_movil;
            var listaBases = this.repositorio.mostrarTodo(id).ToList();

            this.tablaMoviles.DataSource = null; // 🔑 Limpio primero
            this.tablaMoviles.DataSource = listaBases;
            this.vista.mostrarBases(this.tablaMoviles, id);
        }



        private void agregar_base(object sender, EventArgs e) { }
        private void modificar_base(object sender, EventArgs e) { }
        private void comentar_base(object sender, EventArgs e) { }
        private void eliminar_base(object sender, EventArgs e) { }
        private void voler_menu(object sender, EventArgs e) 
        {
            IRecordatorioRepositorio recordatorio = new RecordatorioRepositorio();
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            new InicioPresentador(inicio, recordatorio);
            ((Form)vista).Close();
        }
    }
}
