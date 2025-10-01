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
        public DateTime fecha
        {
            get => dtpFecha.Value;
            set => dtpFecha.Value = value;
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => agregar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        // Singleton
        private static AgregarBasesVista instancia;
        public static AgregarBasesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarBasesVista();
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
