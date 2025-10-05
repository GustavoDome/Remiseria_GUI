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
    public partial class ModificarPlanillaCostoVistaEsperaCuadra : Form, IModificarPlanillaCostoVistaEsperaCuadra
    {
        public ModificarPlanillaCostoVistaEsperaCuadra()
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
        public int MontoEsperaCuadra
        {
            get => int.TryParse(txtCuadrasEspera.Text, out int m) ? m : 0;
            set => txtCuadrasEspera.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }
        public static ModificarPlanillaCostoVistaEsperaCuadra ObtenerInstancia()
        {
            var instancia = new ModificarPlanillaCostoVistaEsperaCuadra();
            return instancia;
        }
    }
}
