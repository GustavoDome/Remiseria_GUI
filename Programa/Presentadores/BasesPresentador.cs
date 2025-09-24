using Programa.DTOs;
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
        private readonly IBasesVista vista;
        private readonly IBasesRepositorio repositorio;
        private readonly BindingSource filtrador;
        private readonly BindingSource tablaBases;
        private readonly string rol;
        private readonly int id;

        public BasesPresentador(IBasesVista vista, IBasesRepositorio repositorio, string rol, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.rol = rol;
            this.id = id;
            this.filtrador = new BindingSource();
            this.tablaBases = new BindingSource();

            vista.ocultarBotones(rol);
            vista.mostrarMoviles(filtrador);
            cargarMoviles();

            vista.agregarBase += agregar_base;
            vista.modificarBase += modificar_base;
            vista.comentarBase += comentar_base;
            vista.eliminarBase += eliminar_base;
            vista.volver += volver_menu;
            vista.OnMovilSeleccionado += vista_OnMovilSeleccionado;
        }

        private void cargarMoviles()
        {
            var listaIds = repositorio.SeleccionarMovil().ToList();
            var dtOriginal = ConvertListToDataTable(listaIds);
            var dtTranspuesta = TransponerDataTable(dtOriginal);
            filtrador.DataSource = dtTranspuesta;
        }

        private void vista_OnMovilSeleccionado(object sender, EventArgs e)
        {
            int idMovil = vista.id_movil;
            var listaBases = repositorio.MostrarTodo(idMovil).ToList(); // ahora devuelve DTO
            tablaBases.DataSource = listaBases;
            vista.mostrarBases(tablaBases, idMovil);
        }

        private void agregar_base(object sender, EventArgs e)
        {
            // futuro: abrir vista de alta
        }

        private void modificar_base(object sender, EventArgs e)
        {
            // futuro: abrir vista de edición
        }

        private void comentar_base(object sender, EventArgs e)
        {
            // futuro: abrir vista de comentarios
        }

        private void eliminar_base(object sender, EventArgs e)
        {
            // futuro: aplicar borrado lógico
        }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }

        private DataTable ConvertListToDataTable(IEnumerable<MovilResumenDTO> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("numero_movil");
            foreach (var item in lista)
            {
                var row = dt.NewRow();
                row["numero_movil"] = item.NumeroMovil;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private DataTable TransponerDataTable(DataTable original)
        {
            DataTable transpuesta = new DataTable();
            transpuesta.Columns.Add("Propiedad");
            for (int i = 0; i < original.Rows.Count; i++)
                transpuesta.Columns.Add($"Valor {i + 1}");

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
