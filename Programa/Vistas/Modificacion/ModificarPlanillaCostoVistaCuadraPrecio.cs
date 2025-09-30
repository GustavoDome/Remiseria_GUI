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
    public partial class ModificarPlanillaCostoVistaCuadraPrecio : Form, IModificarPlanillaCostoVistaCuadraPrecio
    {
        public ModificarPlanillaCostoVistaCuadraPrecio()
        {
            InitializeComponent();
            asociarEventos();
        }

        public int MontoMinimo
        {
            get => int.TryParse(txtCuadrasMinimo.Text, out int m) ? m : 0;
            set => txtCuadrasMinimo.Text = value.ToString();
        }

        public int MontoPorCuadra
        {
            get => int.TryParse(txtCuadrasMonto.Text, out int m) ? m : 0;
            set => txtCuadrasMonto.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarPlanillaCostoVistaCuadraPrecio instancia;
        public static ModificarPlanillaCostoVistaCuadraPrecio ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarPlanillaCostoVistaCuadraPrecio();
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
