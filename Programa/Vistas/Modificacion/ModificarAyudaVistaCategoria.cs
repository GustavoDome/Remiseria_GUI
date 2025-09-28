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
    public partial class ModificarAyudaVistaCategoria : Form, IModificarAyudaVistaCategoria
    {
        public ModificarAyudaVistaCategoria()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarAyudaVista_Load);
            asociarEventos();
        }
        private void ModificarAyudaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        // Propiedad para acceder al texto del TextBox
        public string categorianombre
        {
            get => txtCategoria.Text;
            set => txtCategoria.Text = value;
        }

        // Eventos que el presentador puede suscribirse
        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        // Singleton
        private static ModificarAyudaVistaCategoria instancia;
        public static ModificarAyudaVistaCategoria ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarAyudaVistaCategoria();
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
