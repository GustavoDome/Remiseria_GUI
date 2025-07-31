using Programa.Vistas.Interfaces;
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
    public partial class ConfiguracionesVista : Form, IConfiguracionesVista
    {
        public ConfiguracionesVista()
        {
            InitializeComponent();
        }


        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static ConfiguracionesVista instancia;

        // Metodo para el uso del Singleton
        public static ConfiguracionesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ConfiguracionesVista();
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
