using Programa.Estilos;
using Programa.Vistas.Alta;
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
    /// <summary>
    /// Vista de modificación para una pregunta en el módulo de ayuda.
    /// Permite editar el texto y confirmar los cambios.
    /// </summary>

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

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        public string preguntatexto
        {
            get { return rtbPregunta.Text; }
            set { rtbPregunta.Text = value; }
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        public static ModificarAyudaVistaPregunta ObtenerInstancia()
        {
            var instancia = new ModificarAyudaVistaPregunta();
            return instancia;
        }
    }
}
