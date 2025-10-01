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
    public partial class ModificarPlanillaCostoVistaCuadraMandado : Form, IModificarPlanillaCostoVistaCuadraMandado
    {
        public ModificarPlanillaCostoVistaCuadraMandado()
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
        public int MontoMandado
        {
            get => int.TryParse(txtCuadrasMandado.Text, out int m) ? m : 0;
            set => txtCuadrasMandado.Text = value.ToString();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarPlanillaCostoVistaCuadraMandado instancia;
        public static ModificarPlanillaCostoVistaCuadraMandado ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarPlanillaCostoVistaCuadraMandado();
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
