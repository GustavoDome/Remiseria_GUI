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
    public partial class AgregarAyudaVistaCategoria : Form, IAgregarAyudaVistaCategoria
    {
        public AgregarAyudaVistaCategoria()
        {
            this.Load += new System.EventHandler(this.AyudaVista_Load);
            InitializeComponent();
            asociarPresentador();
        }
        private void AyudaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public void asociarPresentador()
        {
            btnAgregar.Click += delegate 
            {
                agregar?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
        }
        public string categorianombre
        {
            get { return txtCategoria.Text; }
            set { txtCategoria.Text = value; }
        }
        public event EventHandler agregar;
        public event EventHandler volver;
        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static AgregarAyudaVistaCategoria instancia;

        // Metodo para el uso del Singleton
        public static AgregarAyudaVistaCategoria ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarAyudaVistaCategoria();
                instancia.Show();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                {
                    instancia.WindowState = FormWindowState.Normal;
                }
                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
