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
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            InitializeComponent();
            asociarPresentador();
        }
        private void ModificarVista_Load(object sender, EventArgs e)
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
        public static AgregarAyudaVistaCategoria ObtenerInstancia()
        {
            var instancia = new AgregarAyudaVistaCategoria();
            return instancia;
        }
    }
}
