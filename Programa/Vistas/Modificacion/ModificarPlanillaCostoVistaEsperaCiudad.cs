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
    public partial class ModificarPlanillaCostoVistaEsperaCiudad : Form, IModificarPlanillaCostoVistaEsperaCiudad
    {
        public ModificarPlanillaCostoVistaEsperaCiudad()
        {
            InitializeComponent();
            asociarEventos();
        }

        public int MontoEspera
        {
            get => int.TryParse(txtEsperaCiudad.Text, out int m) ? m : 0;
            set => txtEsperaCiudad.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarPlanillaCostoVistaEsperaCiudad instancia;
        public static ModificarPlanillaCostoVistaEsperaCiudad ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarPlanillaCostoVistaEsperaCiudad();
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
