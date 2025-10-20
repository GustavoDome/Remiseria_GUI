using Programa.Estilos;
using Programa.Vistas.Alta;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Modificacion
{
    /// <summary>
    /// Vista de modificación para una ciudad en la planilla de costos.
    /// Permite editar nombre y distancia en kilómetros.
    /// </summary>
    public partial class ModificarPlanillaCostoVistaCiudad : Form, IModificarPlanillaCostoVistaCiudad
    {
        public ModificarPlanillaCostoVistaCiudad()
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
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            brnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
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

        public event EventHandler modificar;
        public event EventHandler volver;

        public static ModificarPlanillaCostoVistaCiudad ObtenerInstancia()
        {
            var instancia = new ModificarPlanillaCostoVistaCiudad();
            return instancia;
        }
    }
}
