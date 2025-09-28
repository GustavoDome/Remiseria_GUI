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
    public partial class ConfiguracionesVista : Form, IConfiguracionesVista
    {
        public ConfiguracionesVista()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ConfiguracionVista_Load);
            tbTamanoFuente.TextChanged += tbTamanoFuente_TextChanged;
            asociacionPresentador();
        }
        private void tbTamanoFuente_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbTamanoFuente.Text, out int valor) || valor < 7 || valor > 13)
            {
                tbTamanoFuente.BackColor = Color.LightCoral;
            }
            else
            {
                var tema = GestorEstilosGlobal.Instance.ObtenerTemaActual();
                tbTamanoFuente.BackColor = tema == "oscuro" ? Color.DimGray : Color.White;
                tbTamanoFuente.ForeColor = tema == "oscuro" ? Color.White : Color.Black;
            }
        }

        private void ConfiguracionVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this); // ← esto ya invoca el método recursivo
        }
        public void RefrescarEstilos()
        {
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }
        public void asociacionPresentador() 
        {
            btnGuardar.Click += delegate 
            {
                guardar?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
        }

        public string tipoFuente 
        {
            get { return cbTipoFuente.Text; }
            set { cbTipoFuente.Text = value; }
        }
        public string tamanoFuente 
        {
            get { return tbTamanoFuente.Text; }
            set { tbTamanoFuente.Text = value; }
        }
        public string temaSistema 
        {
            get { return cbTema.Text; }
            set { cbTema.Text = value; }
        }
        public string tipoAlarma 
        {
            get { return cbAlarma.Text; }
            set { cbAlarma.Text = value; }
        }

        public event EventHandler volver;
        public event EventHandler guardar;

        public void SetTipoFuenteBindingSource(BindingSource tipoFuentes)
        {
            cbTipoFuente.DataSource = tipoFuentes;
        }

        public void SetTamanoFuenteBindingSource(BindingSource tamanoFuentes)
        {
            tbTamanoFuente.DataBindings.Clear();
            tbTamanoFuente.DataBindings.Add("Text", tamanoFuentes, "TamanoFuente");
        }

        public void SetTemaSistemaBindingSource(BindingSource temaSistemas)
        {
            cbTema.DataSource = temaSistemas;
        }

        public void SetTipoAlarmaBindingSource(BindingSource tipoAlarmas)
        {
            cbAlarma.DataSource = tipoAlarmas;
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
