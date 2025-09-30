using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Windows.Forms;

namespace Programa.Vistas.Modificacion
{
    public partial class ModificarOperadorVista : Form, IModificarOperadorVista
    {
        public ModificarOperadorVista()
        {
            InitializeComponent();
            asociarEventos();
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

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarOperadorVista instancia;
        public static ModificarOperadorVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarOperadorVista();
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
