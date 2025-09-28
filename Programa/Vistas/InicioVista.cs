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
    public partial class InicioVista : Form, IInicioVista
    {
        public InicioVista()
        {
            InitializeComponent();
            asociacionPresentador();
            this.Load += new System.EventHandler(this.InicioVista_Load);
            this.FormClosed += (s, e) => Application.Exit();
        }

        public void ocultarBotones(string rol) 
        {
            if(rol == "Usuario") 
            {
                btnMoviles.Hide();
                btnOperadores.Hide();
                btnRecEliminar.Hide();
            }
        }
        private void InicioVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public void RefrescarEstilos()
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public void asociacionPresentador()
        {
            btnRecAgregar.Click += delegate 
            {
                agregarRecordatorio?.Invoke(this, EventArgs.Empty);
            };
            btnRecModificar.Click += delegate 
            {
                modificarRecordatorio?.Invoke(this, EventArgs.Empty);
            };
            btnRecEliminar.Click += delegate
            {
                eliminarRecordatorio?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
            btnAyuda.Click += delegate 
            {
                ingresarAyuda?.Invoke(this, EventArgs.Empty);
            };
            btnConfiguracion.Click += delegate
            {
                ingresarConfiguracion?.Invoke(this, EventArgs.Empty);
            };
            btnOperadores.Click += delegate 
            {
                ingresarOperadores?.Invoke(this, EventArgs.Empty);
            };
            btnMoviles.Click += delegate
            {
                ingresarMoviles?.Invoke(this, EventArgs.Empty);
            };
            btnViajes.Click += delegate
            {
                ingresarViajes?.Invoke(this, EventArgs.Empty);
            };
            btnVuelta.Click += delegate
            {
                ingresarVueltas?.Invoke(this, EventArgs.Empty);
            };
            btnBases.Click += delegate
            {
                ingresarBases?.Invoke(this, EventArgs.Empty);
            };
        }
        public void ConfigurarGrilla()
        {
            dgvRecordatorio.Columns["FechaDia"].HeaderText = "Fecha Día";
            dgvRecordatorio.Columns["FechaHora"].HeaderText = "Hora";
            dgvRecordatorio.Columns["Direccion"].HeaderText = "Dirección";
            dgvRecordatorio.Columns["NombreOperador"].HeaderText = "Operador";

            if (dgvRecordatorio.Columns.Contains("IdRecordatorio"))
            {
                dgvRecordatorio.Columns["IdRecordatorio"].Visible = false;
            }
            if (dgvRecordatorio.Columns.Contains("FechaDia"))
            {
                dgvRecordatorio.Columns["FechaDia"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvRecordatorio.Columns.Contains("FechaHora"))
            {
                dgvRecordatorio.Columns["FechaHora"].DefaultCellStyle.Format = "HH:mm";
            }
            foreach (DataGridViewColumn col in dgvRecordatorio.Columns)
            {
                if (col.Name == "Direccion") // ajustá al nombre real
                {
                    col.Width = 300; // ancho personalizado
                }
                else if (col.Visible)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.MinimumWidth = 150;
                }
            }
        }


        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static InicioVista instancia;

        public event EventHandler agregarRecordatorio;
        public event EventHandler eliminarRecordatorio;
        public event EventHandler modificarRecordatorio;
        public event EventHandler ingresarViajes;
        public event EventHandler ingresarBases;
        public event EventHandler ingresarVueltas;
        public event EventHandler ingresarMoviles;
        public event EventHandler ingresarAyuda;
        public event EventHandler ingresarOperadores;
        public event EventHandler ingresarConfiguracion;
        public event EventHandler volver;

        // Metodo para el uso del Singleton
        public static InicioVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new InicioVista();
                instancia.RefrescarEstilos();
                instancia.Show();
            }
            else
            {
                instancia.RefrescarEstilos();
                if (instancia.WindowState == FormWindowState.Minimized)
                {
                    instancia.WindowState = FormWindowState.Normal;
                }
                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }

        public void SetRecordatoriosBindingSource(BindingSource RecordatorioLista)
        {
            dgvRecordatorio.DataSource = RecordatorioLista;
        }

        public void Mostrar()
        {
            throw new NotImplementedException();
        }
    }
}
