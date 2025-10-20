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
    /// Vista de modificación para una base existente.
    /// Permite editar la fecha y el comentario asociado.
    /// </summary>
    public partial class ModificarBasesVista : Form, IModificarBasesVista
    {
        public ModificarBasesVista()
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
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        public DateTime fecha
        {
            get => dtpFecha.Value;
            set => dtpFecha.Value = value;
        }

        public string comentario
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        public static ModificarBasesVista ObtenerInstancia()
        {
            var instancia = new ModificarBasesVista();
            return instancia;
        }
    }
}
