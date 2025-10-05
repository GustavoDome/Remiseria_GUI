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
    public partial class ModificarInicioVistaRecordatorio : Form, IModificarInicioVistaRecordatorio
    {
        public ModificarInicioVistaRecordatorio()
        {
            this.Load += new System.EventHandler(this.ModificarRecordatorioInicioVista_Load);
            InitializeComponent();
            asociarPresentador();
        }
        public void asociarPresentador()
        {
            btnVolver.Click += delegate
            {
                volver?.Invoke(this, EventArgs.Empty);
            };

            btnModificar.Click += delegate
            {
                modificar?.Invoke(this, EventArgs.Empty);
            };
        }

        private void ModificarRecordatorioInicioVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
            dtpFecha.MinDate = DateTime.Today;
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.ShowUpDown = true;
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFecha.Value.Date == DateTime.Today)
            {
                // Si la fecha es hoy, y la hora seleccionada es menor a la actual, la ajustamos
                if (dtpHora.Value.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    dtpHora.Value = DateTime.Now;
                }
            }
        }

        public event EventHandler volver;
        public event EventHandler modificar;

        public DateTime fecha
        {
            get { return dtpFecha.Value; }
            set { dtpFecha.Value = value; }
        }
        public DateTime hora
        {
            get { return dtpHora.Value; }
            set { dtpHora.Value = value; }
        }

        public string direccion
        {
            get { return txtDireccion.Text; }
            set { txtDireccion.Text = value; }
        }

        public string comentario
        {
            get { return rtbComentario.Text; }
            set { rtbComentario.Text = value; }
        }
        public static ModificarInicioVistaRecordatorio ObtenerInstancia()
        {
            var instancia = new ModificarInicioVistaRecordatorio();
            return instancia;
        }
    }
}
