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
    public partial class VueltaVista : Form, IVueltaVista
    {
        public VueltaVista()
        {
            InitializeComponent();
            asociarPresentador();
        }

        public void ocultarBotones(string rol) 
        {
            if(rol== "Usuario")
            {
                dateTimePicker1.Enabled = false;
                btnEliminar.Hide();
                btnAnterior.Hide();
                btnSiguiente.Hide();
            }
        }
        public void asociarPresentador() 
        {
            btnAgregar.Click += delegate 
            {
                agregarVuelta?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate 
            {
                modificarVuelta?.Invoke(this, EventArgs.Empty);
            };
            btnEliminar.Click += delegate 
            { 
                eliminarVuelta?.Invoke(this, EventArgs.Empty); 
            };
            btnAnterior.Click += delegate 
            { 
                retroceder?.Invoke(this, EventArgs.Empty);
            };
            btnSiguiente.Click += delegate {
                adelantar?.Invoke(this, EventArgs.Empty);
            };
            btnViajes.Click += delegate 
            { 
                ingresarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            { 
                volver?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler agregarVuelta;
        public event EventHandler modificarVuelta;
        public event EventHandler eliminarVuelta;
        public event EventHandler retroceder;
        public event EventHandler adelantar;
        public event EventHandler ingresarViaje;
        public event EventHandler volver;

        public void SetViajesBindingSource(BindingSource viajes) 
        {
            dgvVuelta.DataSource = viajes;
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static VueltaVista instancia;

        // Metodo para el uso del Singleton
        public static VueltaVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new VueltaVista();
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
