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
    public partial class ModificarPlanillaCostoVistaCiudad : Form, IModificarPlanillaCostoVistaCiudad
    {
        public ModificarPlanillaCostoVistaCiudad()
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
        public string NombreCiudad
        {
            get => txtCiudad.Text;
            set => txtCiudad.Text = value;
        }

        public int Kilometros
        {
            get => int.TryParse(txtKilometros.Text, out int km) ? km : 0;
            set => txtKilometros.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            brnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarPlanillaCostoVistaCiudad instancia;
        public static ModificarPlanillaCostoVistaCiudad ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarPlanillaCostoVistaCiudad();
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
