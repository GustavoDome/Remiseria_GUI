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
    public partial class ViajesVista : Form, IViajesVista
    {
        public ViajesVista()
        {
            InitializeComponent();
        }

        public void asociarPresentador() 
        {
            btnAgregar.Click += delegate 
            {
                agregarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate
            {
                modificarViaje?.Invoke(this, EventArgs.Empty); 
            };
            btnComentar.Click += delegate 
            {
                comentarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnEliminar.Click += delegate 
            { 
                eliminarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnAnterior.Click += delegate 
            {
                retroceder?.Invoke(this, EventArgs.Empty);
            };
            btnSiguiente.Click += delegate 
            {
                adelantar?.Invoke(this, EventArgs.Empty);
            };
            btnVuelta.Click += delegate 
            {
                ingresarVuelta?.Invoke(this, EventArgs.Empty); 
            };
            btnVolver.Click += delegate
            {
                volver?.Invoke(this, EventArgs.Empty); 
            };
        }

        public event EventHandler agregarViaje;
        public event EventHandler modificarViaje;
        public event EventHandler comentarViaje;
        public event EventHandler eliminarViaje;
        public event EventHandler retroceder;
        public event EventHandler adelantar;
        public event EventHandler ingresarVuelta;
        public event EventHandler volver;

        public void SetViajesBindingSource(BindingSource viajes) { }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static ViajesVista instancia;

        // Metodo para el uso del Singleton
        public static ViajesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ViajesVista();
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
