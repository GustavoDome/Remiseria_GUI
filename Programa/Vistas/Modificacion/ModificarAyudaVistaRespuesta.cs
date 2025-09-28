using Programa.Estilos;
using Programa.Modelos;
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
    public partial class ModificarAyudaVistaRespuesta : Form, IModificarAyudaVistaRespuesta
    {
        public ModificarAyudaVistaRespuesta()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarAyudaRespuestaVista_Load);
            asociarEventos();
        }
        private void ModificarAyudaRespuestaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        public string respuestatexto
        {
            get { return trbRespuesta.Text; }
            set { trbRespuesta.Text = value; }
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        // Singleton
        private static ModificarAyudaVistaRespuesta instancia;
        public static ModificarAyudaVistaRespuesta ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarAyudaVistaRespuesta();
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
