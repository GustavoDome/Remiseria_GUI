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
    /// Vista de modificación para el importe por kilómetro en ciudad.
    /// Permite editar el valor y confirmar los cambios.
    /// </summary>
    public partial class ModificarPlanillaCostoVistaCiudadPrecio : Form, IModificarPlanillaCostoVistaCiudadPrecio
    {
        public ModificarPlanillaCostoVistaCiudadPrecio()
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
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        public int MontoKilometro
        {
            get => int.TryParse(txtMontoKilometro.Text, out int m) ? m : 0;
            set => txtMontoKilometro.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        public static ModificarPlanillaCostoVistaCiudadPrecio ObtenerInstancia()
        {
            var instancia = new ModificarPlanillaCostoVistaCiudadPrecio();
            return instancia;
        }
    }
}
