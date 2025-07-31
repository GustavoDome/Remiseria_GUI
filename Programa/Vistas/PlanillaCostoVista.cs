using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas
{
    public partial class PlanillaCostoVista : Form
    {
        public PlanillaCostoVista()
        {
            InitializeComponent();
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static PlanillaCostoVista instancia;

        // Metodo para el uso del Singleton
        public static PlanillaCostoVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new PlanillaCostoVista();
                instancia.Show();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                {
                    instancia.WindowState = FormWindowState.Normal;
                }
                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
