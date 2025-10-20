using Programa.Estilos;
using Programa.Vistas.Alta;
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
    /// <summary>
    /// Vista de modificación para el importe mínimo y por cuadra.
    /// Permite editar ambos valores y confirmar los cambios.
    /// </summary>
    public partial class ModificarPlanillaCostoVistaCuadraPrecio : Form, IModificarPlanillaCostoVistaCuadraPrecio
    {
        public ModificarPlanillaCostoVistaCuadraPrecio()
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

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
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

        public static ModificarPlanillaCostoVistaCuadraPrecio ObtenerInstancia()
        {
            var instancia = new ModificarPlanillaCostoVistaCuadraPrecio();
            return instancia;
        }
    }
}
