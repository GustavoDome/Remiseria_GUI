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
    public partial class MovilesVista : Form, IMovilesVista
    {
        public MovilesVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            asociacionPresentador();
        }
        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public void asociacionPresentador()
        {
            btnAgregar.Click += delegate 
            {
                agregarMovil?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate 
            {
                modificarMovil?.Invoke(this, EventArgs.Empty);
            };
            btnEliminar.Click += delegate
            {
                eliminarMovil?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
            dgvMoviles.CellClick += delegate (object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0 && dgvMoviles.Columns.Contains("IdMovil"))
                {
                    dgvMoviles.CurrentCell = dgvMoviles.Rows[e.RowIndex].Cells["IdMovil"];
                }
            };
            dgvMoviles.CellMouseDown += delegate (object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    dgvMoviles.ClearSelection();
                    dgvMoviles.Rows[e.RowIndex].Selected = true;
                    dgvMoviles.CurrentCell = dgvMoviles.Rows[e.RowIndex].Cells["IdMovil"];
                }
            };
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        public static MovilesVista instancia;

        public event EventHandler agregarMovil;
        public event EventHandler modificarMovil;
        public event EventHandler eliminarMovil;
        public event EventHandler volver;
        public void SetMovilesBindingSource(BindingSource moviles) 
        {
            dgvMoviles.DataSource = moviles;
        }
        public int ObtenerIdMovilSeleccionado()
        {
            var fila = dgvMoviles.CurrentRow;
            if (fila == null || !dgvMoviles.Columns.Contains("IdMovil"))
                return 0;

            var celda = fila.Cells["IdMovil"];
            if (celda == null || celda.Value == null)
                return 0;

            if (int.TryParse(celda.Value.ToString(), out int idMovil))
                return idMovil;

            return 0;
        }
        // Metodo para el uso del Singleton
        public static MovilesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new MovilesVista();
                instancia.Show();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                {
                    instancia.WindowState = FormWindowState.Normal;
                }
                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
