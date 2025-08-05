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
            asociacionPresentador();
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

        public void SetTipoFuenteBindingSource(BindingSource tipoFuentes) { }
        public void SetTamanoFuenteBindingSource(BindingSource tamanoFuentes) { }
        public void SetTemaSistemaBindingSource(BindingSource temaSistemas) { }
        public void SetTipoAlarmaBindingSource(BindingSource tipoAlarmas) { }

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
