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
using Programa.Estilos;

namespace Programa.Vistas.Alta
{
    /// <summary>
    /// Vista de agregación para una nueva base.
    /// Permite seleccionar la fecha y confirmar la creación.
    /// </summary>
    public partial class AgregarBasesVista : Form, IAgregarBasesVista
    {
        public AgregarBasesVista()
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

        public DateTime fecha
        {
            get => dtpFecha.Value;
            set => dtpFecha.Value = value;
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        public static AgregarBasesVista ObtenerInstancia()
        {
            var instancia = new AgregarBasesVista();
            return instancia;
        }
    }
}
