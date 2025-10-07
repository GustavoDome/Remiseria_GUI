using Programa.Commons;
using Programa.DTOs;
using Programa.Estilos;
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
    public partial class VueltaVista : Form, IVueltaVista
    {
        public VueltaVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            asociarPresentador();
        }

        public void ocultarBotones(string rol) 
        {
            if(rol== "Operador")
            {
                dateTimePicker1.Enabled = false;
                btnAnterior.Hide();
                btnSiguiente.Hide();
            }
            if (dgvVuelta.Columns.Contains("IdVuelta"))
                dgvVuelta.Columns["IdVuelta"].Visible = false;
        }
        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public void asociarPresentador() 
        {
            btnAgregarVuelta.Click += delegate
            {
                agregarVuelta?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate 
            {
                modificarVuelta?.Invoke(this, EventArgs.Empty);
            };
            btnEliminarVuelta.Click += delegate
            {
                eliminarVuelta?.Invoke(this, EventArgs.Empty);
            };
            btnAgregarMovil.Click += delegate
            {
                agregarMovil?.Invoke(this, EventArgs.Empty);
            };
            btnEliminarMovil.Click += delegate 
            {
                eliminarMovil?.Invoke(this, EventArgs.Empty); 
            };
            btnAnterior.Click += delegate 
            { 
                retroceder?.Invoke(this, EventArgs.Empty);
            };
            btnSiguiente.Click += delegate {
                adelantar?.Invoke(this, EventArgs.Empty);
            };
            btnViajes.Click += delegate 
            { 
                ingresarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            { 
                volver?.Invoke(this, EventArgs.Empty);
            };
            dgvVuelta.CellDoubleClick += (s, e) =>
            {
                var nombreColumna = dgvVuelta.Columns[e.ColumnIndex].Name;
                if (nombreColumna.StartsWith("Movil "))
                {
                    modificarVuelta?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public event EventHandler agregarVuelta;
        public event EventHandler modificarVuelta;
        public event EventHandler eliminarVuelta;
        public event EventHandler agregarMovil;
        public event EventHandler eliminarMovil;
        public event EventHandler retroceder;
        public event EventHandler adelantar;
        public event EventHandler ingresarViaje;
        public event EventHandler volver;

        public void SetViajesBindingSource(BindingSource viajes) 
        {
            dgvVuelta.DataSource = viajes;
        }
        public void SetFecha(DateTime fecha)
        {
            dateTimePicker1.Value = fecha;
        }

        private List<MovilResumenDTO> movilesResumen;
        public void ConfigurarMoviles(List<MovilResumenDTO> lista)
        {
            movilesResumen = lista;
        }
        public int ObtenerIdMovilSeleccionado()
        {
            if (dgvVuelta.CurrentCell == null || movilesResumen == null)
                return 0;

            string columna = dgvVuelta.Columns[dgvVuelta.CurrentCell.ColumnIndex].HeaderText;
            if (!columna.StartsWith("Movil ")) return 0;

            if (int.TryParse(columna.Replace("Movil ", ""), out int numeroMovil))
            {
                var dto = movilesResumen.FirstOrDefault(m => m.NumeroMovil == numeroMovil);
                return dto?.IdMovil ?? 0;
            }

            return 0;
        }
        public int ObtenerNumeroMovilSeleccionado()
        {
            if (dgvVuelta.CurrentCell == null)
                return 0;

            string columna = dgvVuelta.Columns[dgvVuelta.CurrentCell.ColumnIndex].HeaderText;
            if (!columna.StartsWith("Movil ")) return 0;

            if (int.TryParse(columna.Replace("Movil ", ""), out int numeroMovil))
                return numeroMovil;

            return 0;
        }

        public int ObtenerNumeroVueltaSeleccionada()
        {
            if (dgvVuelta.CurrentRow == null)
                return 0;

            var valor = dgvVuelta.CurrentRow.Cells["Vuelta"].Value;
            if (valor == null) return 0;

            if (int.TryParse(valor.ToString(), out int numero))
                return numero;

            return 0;
        }
        public int ObtenerIdVueltaSeleccionada()
        {
            if (dgvVuelta.CurrentCell == null)
                return 0;

            var celda = dgvVuelta.CurrentCell;
            string nombreColumna = celda.OwningColumn.Name;

            if (!nombreColumna.StartsWith("Movil "))
                return 0;

            string numeroMovil = nombreColumna.Replace("Movil ", "");
            string columnaId = $"IdVuelta {numeroMovil}";

            if (!dgvVuelta.Columns.Contains(columnaId))
                return 0;

            var fila = celda.OwningRow;
            var celdaId = fila.Cells[columnaId];

            if (celdaId == null || celdaId.Value == null)
                return 0;

            if (int.TryParse(celdaId.Value.ToString(), out int idVuelta))
                return idVuelta;

            return 0;
        }
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        // Variable que llamaran los otros forms para el comportamiento Singleton
        public static VueltaVista instancia;

        // Metodo para el uso del Singleton
        public static VueltaVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new VueltaVista();
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
