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
                if (e.RowIndex >= 0)
                {
                    dgvMoviles.ClearSelection();
                    dgvMoviles.Rows[e.RowIndex].Selected = true;

                    var binding = dgvMoviles.DataSource as BindingSource;
                    var dt = binding?.DataSource as DataTable;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var idMovil = dt.Rows
                            .Cast<DataRow>()
                            .FirstOrDefault(r => r[0].ToString() == "IdMovil")?[e.ColumnIndex];

                        if (idMovil != null)
                        {
                            idMovil = Convert.ToInt32(idMovil);
                            OnMovilSeleccionado?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            };
            dgvMoviles.CellMouseDown += delegate (object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.RowIndex >= 0)
                    dgvMoviles.Rows[e.RowIndex].Selected = true;
            };
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        public static MovilesVista instancia;

        public event EventHandler agregarMovil;
        public event EventHandler modificarMovil;
        public event EventHandler eliminarMovil;
        public event EventHandler OnMovilSeleccionado;
        public event EventHandler volver;
        public void SetMovilesBindingSource(BindingSource moviles) 
        {
            dgvMoviles.DataSource = moviles;
        }
        public void configurarGrilla()
        {
            dgvMoviles.Columns["NumeroMovil"].HeaderText = "Movil";
            dgvMoviles.Columns["Ano"].HeaderText = "Año";
            dgvMoviles.Columns["NombreDueno"].HeaderText = "Remisero";
            dgvMoviles.Columns["ApellidoDueno"].HeaderText = "Apellido";
            dgvMoviles.Columns["TelefonoDueno"].HeaderText = "Telefono";
            dgvMoviles.Columns["EsChofer"].HeaderText = "¿Chofer?";

            if (dgvMoviles.Columns.Contains("IdMovil"))
            {
                dgvMoviles.Columns["IdMovil"].Visible = false;
            }
            if (dgvMoviles.Columns.Contains("IdDueno"))
            {
                dgvMoviles.Columns["IdDueno"].Visible = false;
            }
            foreach (DataGridViewColumn col in dgvMoviles.Columns)
            {
                if (col.Name == "Telefono") // ajustá al nombre real
                {
                    col.Width = 350; // ancho personalizado
                }
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.MinimumWidth = 200;
            }
        }
        public int ObtenerIdMovilSeleccionado()
        {
            if (dgvMoviles.SelectedRows.Count == 0 || !dgvMoviles.Columns.Contains("IdMovil"))
                return 0;

            var celda = dgvMoviles.SelectedRows[0].Cells["IdMovil"];
            if (celda?.Value == null)
                return 0;

            return int.TryParse(celda.Value.ToString(), out int idMovil) ? idMovil : 0;
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
