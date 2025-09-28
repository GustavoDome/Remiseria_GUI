using Programa.Estilos;
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
    public partial class ModificarAyudaVistaPregunta : Form, IModificarAyudaVistaPregunta
    {
        public ModificarAyudaVistaPregunta()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarAyudaVistaPreguntaVista_Load);
            asociarEventos();
        }
        private void ModificarAyudaVistaPreguntaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public string preguntatexto
        {
            get { return rtbPregunta.Text; }
            set { rtbPregunta.Text = value; }
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        // Singleton
        private static ModificarAyudaVistaPregunta instancia;
        public static ModificarAyudaVistaPregunta ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarAyudaVistaPregunta();
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
