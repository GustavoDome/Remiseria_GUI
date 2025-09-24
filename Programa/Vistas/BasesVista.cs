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
            dgvMoviles.DataSource = listaMoviles;
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

            dgvMoviles.SelectionChanged += (s, e) =>
            {
                if (dgvMoviles.CurrentRow != null && dgvMoviles.CurrentRow.Cells.Count > 1)
                {
                    var valor = dgvMoviles.CurrentRow.Cells[1].Value?.ToString();
                    if (int.TryParse(valor, out int idMovil))
                    {
                        id_movil = idMovil;
                        OnMovilSeleccionado?.Invoke(this, EventArgs.Empty);
                    }
                }
            };
        }
    }
}
