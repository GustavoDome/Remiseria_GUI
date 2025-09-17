using Programa.Presentadores;
using Programa.Repositorios;
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
    public partial class ViajesVista : Form, IViajesVista
    {
        public ViajesVista()
        {
            InitializeComponent();
            asociarPresentador();
        }

        public void ocultarBotones(string rol)
        {
            if(rol == "Usuario")
            {
                btnEliminar.Hide();
                btnSiguiente.Hide();
                btnAnterior.Hide();
                dtpFecha.Enabled = false;
            }
        }

        public void asociarPresentador() 
        {
            btnAgregar.Click += delegate 
            {
                agregarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate
            {
                modificarViaje?.Invoke(this, EventArgs.Empty); 
            };
            btnComentar.Click += delegate 
            {
                comentarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnEliminar.Click += delegate 
            { 
                eliminarViaje?.Invoke(this, EventArgs.Empty);
            };
            btnAnterior.Click += delegate 
            {
                retroceder?.Invoke(this, EventArgs.Empty);
            };
            btnSiguiente.Click += delegate 
            {
                adelantar?.Invoke(this, EventArgs.Empty);
            };
            btnVuelta.Click += delegate 
            {
                ingresarVuelta?.Invoke(this, EventArgs.Empty); 
            };
            btnVolver.Click += delegate
            {
                volver?.Invoke(this, EventArgs.Empty); 
            };
        }

        public event EventHandler agregarViaje;
        public event EventHandler modificarViaje;
        public event EventHandler comentarViaje;
        public event EventHandler eliminarViaje;
        public event EventHandler retroceder;
        public event EventHandler adelantar;
        public event EventHandler ingresarVuelta;
        public event EventHandler volver;

        public void SetViajesBindingSource(BindingSource viajes) 
        {
            dgvViajes.DataSource = viajes;
        }

        public void congelarVista() 
        {
            dgvViajes.Columns[0].Width = 40;
            dgvViajes.Columns[1].Width = 60;
            dgvViajes.Columns[2].Width = 200;
            dgvViajes.Columns[3].Width = 120;

            dgvViajes.Columns[0].Frozen = true;
            dgvViajes.Rows[1].Frozen = true;
            dgvViajes.Rows[2].Frozen = true;
        }

        public void RecargarDatos(string rol, int id)
        {
            var presentador = new ViajesPresentador(this, new ViajesRepositorio(),rol, id);
            presentador.cargar_datos();
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static ViajesVista instancia;

        // Metodo para el uso del Singleton
        public static ViajesVista ObtenerInstancia(string rol, int id)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ViajesVista();
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
                instancia.RecargarDatos(rol, id);
            }
            return instancia;
        }
    }
}
