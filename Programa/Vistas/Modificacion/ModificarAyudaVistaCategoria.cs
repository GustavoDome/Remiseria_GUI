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
    public partial class ModificarAyudaVistaCategoria : Form
    {
        public ModificarAyudaVistaCategoria()
        {
            InitializeComponent();
        }


        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static ModificarAyudaVistaCategoria instancia;

        // Metodo para el uso del Singleton
        public static ModificarAyudaVistaCategoria ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarAyudaVistaCategoria();
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
