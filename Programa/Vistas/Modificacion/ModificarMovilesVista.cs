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
    public partial class ModificarMovilesVista : Form, IModificarMovilesVista
    {
        public ModificarMovilesVista()
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
        public int NumeroMovil
        {
            get => int.TryParse(txtNumeroMovil.Text, out int n) ? n : 0;
            set => txtNumeroMovil.Text = value.ToString();
        }

        public string Marca
        {
            get => txtMarcaAuto.Text;
            set => txtMarcaAuto.Text = value;
        }

        public string Modelo
        {
            get => txtModeloAuto.Text;
            set => txtModeloAuto.Text = value;
        }

        public string Anio
        {
            get => txtAnioAuto.Text;
            set => txtAnioAuto.Text = value;
        }

        public string Color
        {
            get => txtColorAuto.Text;
            set => txtColorAuto.Text = value;
        }

        public string NombreDueno
        {
            get => txtNombreRemisero.Text;
            set => txtNombreRemisero.Text = value;
        }

        public string ApellidoDueno
        {
            get => txtApellidoRemisero.Text;
            set => txtApellidoRemisero.Text = value;
        }

        public string TelefonoDueno
        {
            get => txtTelefonoRemisero.Text;
            set => txtTelefonoRemisero.Text = value;
        }

        public bool EsChofer => rbtnDueno.Checked;

        public event EventHandler modificar;
        public event EventHandler volver;

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        private static ModificarMovilesVista instancia;
        public static ModificarMovilesVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new ModificarMovilesVista();
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
