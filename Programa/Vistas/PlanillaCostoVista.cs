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
    public partial class PlanillaCostoVista : Form, IPlanillaCostoVista
    {
        public PlanillaCostoVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.PlanillaCostoVistaVista_Load);
            asociarPresentador();
        }
        private void PlanillaCostoVistaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
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

        public void asociarPresentador()
        {
            btnPrecioCuadra.Click += (s, e) => modificarCuadrasCosto?.Invoke(this, EventArgs.Empty);
            btnPrecioCuadraMandado.Click += (s, e) => modificarCuadrasCostoMandado?.Invoke(this, EventArgs.Empty);
            btnPrecioCuadraEspera.Click += (s, e) => modificarCuadrasEspera?.Invoke(this, EventArgs.Empty);
            btnPrecioCiudad.Click += (s, e) => modificarCiudadCosto?.Invoke(this, EventArgs.Empty);
            btnPrecioCiudadEspera.Click += (s, e) => modificarCiudadEspera?.Invoke(this, EventArgs.Empty);
            btnAgregarCiudad.Click += (s, e) => agregarCiudad?.Invoke(this, EventArgs.Empty);
            btnModificarCiudad.Click += (s, e) => modificarCiudad?.Invoke(this, EventArgs.Empty);
            btnEliminarCiudad.Click += (s, e) => eliminarCiudad?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        public void SetCuadraBindingSource(BindingSource cuadras)
        {
            dgvCuadras.DataSource = cuadras;
        }

        public void SetCiudadBindingSource(BindingSource ciudades)
        {
            dgvCiudad.DataSource = ciudades;
        }

        public void MostrarImportesCuadras(int minimo, int espera, int mandado)
        {
            label3.Text = $"Monto de cuadras: {minimo}";
            label4.Text = $"Espera por 5m: {espera}";
            label5.Text = $"Monto por Mandado: {mandado}";
        }

        public void MostrarImportesCiudad(int kilometro, int espera)
        {
            label1.Text = $"Costo del KM: {kilometro}";
            label2.Text = $"Espera fuera de la ciudad: {espera}";
        }

        // Singleton
        private static PlanillaCostoVista instancia;
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
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
