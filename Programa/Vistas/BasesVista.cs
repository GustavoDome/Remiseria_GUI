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
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static BasesVista instancia;

        public event EventHandler agregarBase;
        public event EventHandler modificarBase;
        public event EventHandler comentarBase;
        public event EventHandler eliminarBase;
        public event EventHandler seleccionarMovil;
        public event EventHandler volver;

        public void mostrarBases(BindingSource basesVista) 
        {
            dgvMoviles.DataSource = basesVista;
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
