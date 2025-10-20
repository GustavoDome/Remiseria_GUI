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
    /// <summary>
    /// Vista de agregación para un comentario asociado a una base.
    /// Permite ingresar texto y confirmar la acción.
    /// </summary>
    public partial class AgregarBasesVistaComentario : Form, IAgregarBasesVistaComentario
    {
        public AgregarBasesVistaComentario()
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

        public string comentario
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        public static AgregarBasesVistaComentario ObtenerInstancia()
        {
            var instancia = new AgregarBasesVistaComentario();
            return instancia;
        }
    }
}
