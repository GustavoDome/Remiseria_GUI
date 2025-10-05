using Programa.DTOs;
using Programa.Estilos;
using Programa.Vistas.Alta.Interfaces;
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
    public partial class AgregarVueltaVista : Form, IAgregarVueltaVista
    {
        public event EventHandler agregarMovil;
        public event EventHandler volver;

        public AgregarVueltaVista()
        {
            InitializeComponent();
            this.Load += ModificarVista_Load;
            btnAgregar.Click += (s, e) => agregarMovil?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        public void SetMoviles(IEnumerable<MovilResumenDTO> moviles)
        {
            clbMoviles.Items.Clear();
            foreach (var m in moviles)
            {
                clbMoviles.Items.Add(m, false);
            }
        }

        public List<int> ObtenerMovilesSeleccionados()
        {
            return clbMoviles.CheckedItems
                .OfType<MovilResumenDTO>()
                .Select(m => m.IdMovil)
                .ToList();
        }

        public void Cerrar()
        {
            this.Close();
        }

        public static AgregarVueltaVista ObtenerInstancia()
        {
            return new AgregarVueltaVista();
        }
    }
}
