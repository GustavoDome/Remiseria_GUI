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
    /// Vista de agregación para una nueva pregunta en el módulo de ayuda.
    /// Permite ingresar el texto de la pregunta y gestionar eventos de navegación.
    /// </summary>
    public partial class AgregarAyudaVistaPregunta : Form, IAgregarAyudaVistaPregunta
    {
        public AgregarAyudaVistaPregunta()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarVista_Load);
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


        public string preguntatexto
        {
            get { return rtbPregunta.Text; }
            set { rtbPregunta.Text = value; }
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        public static AgregarAyudaVistaPregunta ObtenerInstancia()
        {
            var instancia = new AgregarAyudaVistaPregunta();
            return instancia;
        }
    }
}
