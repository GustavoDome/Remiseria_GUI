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
    public partial class AgregarOperadoresVista : Form, IAgregarOperadoresVista
    {
        public AgregarOperadoresVista()
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
        public string Nombre
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }

        public string Direccion
        {
            get => txtDireccion.Text;
            set => txtDireccion.Text = value;
        }

        public string Telefono
        {
            get => txtTelefono.Text;
            set => txtTelefono.Text = value;
        }

        public string Contrasena
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public string Rol => rbtnGerente.Checked ? "Gerente" : "Operador";

        public event EventHandler agregar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => agregar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }
        public static AgregarOperadoresVista ObtenerInstancia()
        {
            var instancia = new AgregarOperadoresVista();
            return instancia;
        }
    }
}
