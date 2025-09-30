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
    public partial class AgregarBasesVistaComentario : Form, IAgregarBasesVistaComentario
    {
        public AgregarBasesVistaComentario()
        {
            this.Load += new System.EventHandler(this.ModificarBasesTemaVista_Load);
            InitializeComponent();
            asociarEventos();
        }
        private void ModificarBasesTemaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public string comentario
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => agregar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        // Singleton
        private static AgregarBasesVistaComentario instancia;
        public static AgregarBasesVistaComentario ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarBasesVistaComentario();
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
