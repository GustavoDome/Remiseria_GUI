using Programa.Estilos;
using Programa.Vistas.Alta.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Alta
{
    /// <summary>
    /// Vista de agregación para registrar una nueva ciudad en la planilla de costos.
    /// Permite ingresar nombre y distancia en kilómetros.
    /// </summary>
    public partial class AgregarPlanillaCostoVista : Form, IAgregarPlanillaCostoVista
    {
        public AgregarPlanillaCostoVista()
        {
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            InitializeComponent();
            asociarEventos();
        }

        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => agregar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        public string NombreCiudad
        {
            get => txtCiudad.Text;
            set => txtCiudad.Text = value;
        }

        public int Kilometros
        {
            get => int.TryParse(txtKilometros.Text, out int km) ? km : 0;
            set => txtKilometros.Text = value.ToString();
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        public static AgregarPlanillaCostoVista ObtenerInstancia()
        {
            var instancia = new AgregarPlanillaCostoVista();
            return instancia;
        }
    }
}
