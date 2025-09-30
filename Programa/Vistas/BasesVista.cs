using Programa.DTOs;
using Programa.Estilos;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas
{
    public partial class BasesVista : Form, IBasesVista
    {
        public BasesVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.BasesTemaVista_Load);
            asociacionPresentador();
            this.Load += BasesVista_Load;
        }

        private void BasesTemaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        // Singleton
        private static BasesVista instancia;
        public static BasesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new BasesVista();
                instancia.Show();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }

        // Eventos
        public event EventHandler agregarBase;
        public event EventHandler modificarBase;
        public event EventHandler comentarBase;
        public event EventHandler eliminarBase;
        public event EventHandler volver;
        public event EventHandler OnMovilSeleccionado;

        // Propiedades
        public int id_movil { get; set; }

        // Métodos
        public void ocultarBotones(string rol)
        {
            if (rol == "Usuario")
            {
                btnModificar.Hide();
                btnEliminar.Hide();
            }
        }

        public void mostrarMoviles(BindingSource listaMoviles)
        {
            dgvMoviles.AutoGenerateColumns = true;
            dgvMoviles.DataSource = listaMoviles;

            dgvMoviles.RowHeadersVisible = false;
            dgvMoviles.AllowUserToAddRows = false;
            dgvMoviles.AllowUserToDeleteRows = false;
            dgvMoviles.ReadOnly = true;

            // ✅ Ocultar la primera columna ("Propiedad")
            if (dgvMoviles.Columns.Count > 0)
                dgvMoviles.Columns[0].Visible = false;

            if (dgvMoviles.Rows.Count > 0)
                dgvMoviles.Rows[0].Visible = false;
        }

        public void mostrarBases(BindingSource listaBases, int idMovil)
        {
            dgvBases.DataSource = listaBases;
        }

        private void BasesVista_Load(object sender, EventArgs e)
        {
            dgvMoviles.ClearSelection();
            dgvBases.DataSource = null;
        }

        private void asociacionPresentador()
        {
            btnAgregar.Click += (s, e) => agregarBase?.Invoke(this, EventArgs.Empty);
            btnModificar.Click += (s, e) => modificarBase?.Invoke(this, EventArgs.Empty);
            btnComentar.Click += (s, e) => comentarBase?.Invoke(this, EventArgs.Empty);
            btnEliminar.Click += (s, e) => eliminarBase?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);

            dgvMoviles.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0) // ignorar columna "Propiedad"
                {
                    id_movil = e.ColumnIndex; // delegamos el índice de columna como identificador lógico
                    OnMovilSeleccionado?.Invoke(this, EventArgs.Empty);
                }
            };
        }
    }
}
