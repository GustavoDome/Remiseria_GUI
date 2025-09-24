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
            asociacionPresentador();
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
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static MovilesVista instancia;

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
            return Convert.ToInt32(dgvMoviles.CurrentRow.Cells["IdMovil"].Value);
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
