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
    public partial class AgregarOperadoresVista : Form
    {
        public AgregarOperadoresVista()
        {
            InitializeComponent();
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static AgregarOperadoresVista instancia;

        // Metodo para el uso del Singleton
        public static AgregarOperadoresVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarOperadoresVista();
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
