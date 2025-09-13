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
    public partial class PlanillaCostoVista : Form, IPlanillaCostoVista
    {
        public PlanillaCostoVista()
        {
            InitializeComponent();
            asociarPresentador();
        }

        public void asociarPresentador() 
        {
            btnPrecioCuadra.Click += delegate 
            {
                modificarCuadrasCosto?.Invoke(this, EventArgs.Empty);
            };
            btnPrecioCuadraMandado.Click += delegate 
            {
                modificarCuadrasCostoMandado?.Invoke(this, EventArgs.Empty);
            };
            btnPrecioCuadraEspera.Click += delegate 
            {
                modificarCuadrasEspera?.Invoke(this, EventArgs.Empty);
            };
            btnPrecioCiudad.Click += delegate 
            {
                modificarCiudadCosto?.Invoke(this, EventArgs.Empty); 
            };
            btnPrecioCiudadEspera.Click += delegate 
            {
                modificarCiudadEspera?.Invoke(this, EventArgs.Empty);
            };
            btnAgregarCiudad.Click += delegate 
            {
                agregarCiudad?.Invoke(this, EventArgs.Empty);
            };
            btnModificarCiudad.Click += delegate
            {
                modificarCiudad?.Invoke(this, EventArgs.Empty); 
            };
            btnEliminarCiudad.Click += delegate
            {
                eliminarCiudad?.Invoke(this, EventArgs.Empty); 
            };
            btnVolver.Click += delegate 
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler modificarCuadrasCosto;
        public event EventHandler modificarCuadrasCostoMandado;
        public event EventHandler modificarCuadrasEspera;
        public event EventHandler modificarCiudadCosto;
        public event EventHandler modificarCiudadEspera;
        public event EventHandler agregarCiudad;
        public event EventHandler modificarCiudad;
        public event EventHandler eliminarCiudad;
        public event EventHandler volver;
        public void SetCuadraBindingSource(BindingSource cuadras) { }
        public void SetCiudadBindingSource(BindingSource ciudades) { }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static PlanillaCostoVista instancia;

        // Metodo para el uso del Singleton
        public static PlanillaCostoVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new PlanillaCostoVista();
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
