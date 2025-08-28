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
            asociacionPresentador();
            this.Load += BasesVista_Load;
        }

        public void asociacionPresentador() 
        {
            btnAgregar.Click += delegate
            {
                agregarBase?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate
            {
                modificarBase?.Invoke(this, EventArgs.Empty);
            };
            btnComentar.Click += delegate 
            {
                comentarBase?.Invoke(this, EventArgs.Empty);
            };
            btnEliminar.Click += delegate 
            {
                eliminarBase?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
            dgvMoviles.SelectionChanged += (s, e) =>
            {
                if (dgvMoviles.CurrentRow != null && dgvMoviles.CurrentRow.Cells.Count > 0)
                {
                    int idMovil;
                    // Asegurarse que el valor se puede parsear a int
                    if (int.TryParse(dgvMoviles.CurrentRow.Cells[1].Value?.ToString(), out idMovil))
                    {
                        id_movil = idMovil;
                        // Avisar al Presentador que se seleccionó un móvil
                        OnMovilSeleccionado?.Invoke(this, EventArgs.Empty);
                    }
                }
            };
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static BasesVista instancia;

        public event EventHandler agregarBase;
        public event EventHandler modificarBase;
        public event EventHandler comentarBase;
        public event EventHandler eliminarBase;
        public event EventHandler volver;
        public event EventHandler OnMovilSeleccionado;


        public int id_movil { get; set; }

        public void mostrarMoviles(BindingSource basesVista) 
        {
            dgvMoviles.DataSource = basesVista;
        }

        public void mostrarBases(BindingSource basesVista, int movil) 
        {
            dgvBases.DataSource = basesVista;
        }

        private void BasesVista_Load(object sender, EventArgs e)
        {
            dgvMoviles.ClearSelection(); // 🔑 Nada seleccionado
            dgvBases.DataSource = null;  // 🔑 Arranca vacío
        }


        // Metodo para el uso del Singleton
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
