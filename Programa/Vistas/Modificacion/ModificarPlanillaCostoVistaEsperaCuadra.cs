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
    public partial class ModificarPlanillaCostoVistaEsperaCuadra : Form, IModificarPlanillaCostoVistaEsperaCuadra
    {
        public ModificarPlanillaCostoVistaEsperaCuadra()
        {
            InitializeComponent();
            asociarEventos();
        }

        public int MontoEsperaCuadra
        {
            get => int.TryParse(txtCuadrasEspera.Text, out int m) ? m : 0;
            set => txtCuadrasEspera.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarPlanillaCostoVistaEsperaCuadra instancia;
        public static ModificarPlanillaCostoVistaEsperaCuadra ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarPlanillaCostoVistaEsperaCuadra();
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
