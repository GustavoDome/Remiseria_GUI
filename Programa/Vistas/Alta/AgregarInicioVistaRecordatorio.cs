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
    /// <summary>
    /// Vista de agregación para un nuevo recordatorio.
    /// Permite configurar fecha, hora, dirección y comentario, con validaciones contextuales.
    /// </summary>
    public partial class AgregarInicioVistaRecordatorio : Form, IAgregarInicioVistaRecordatorio
    {
        public AgregarInicioVistaRecordatorio()
        {
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            InitializeComponent();
            asociarPresentador();
        }

        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
            dtpFecha.MinDate = DateTime.Today;
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.ShowUpDown = true;
        }

        public void asociarPresentador() 
        {
            btnVolver.Click += delegate
            {
                volver?.Invoke(this, EventArgs.Empty);
            };

            btnAgregar.Click += delegate
            {
                agregar?.Invoke(this, EventArgs.Empty);
            };
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
        public event EventHandler agregar;

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
        public static AgregarInicioVistaRecordatorio ObtenerInstancia()
        {
            var instancia = new AgregarInicioVistaRecordatorio();
            return instancia;
        }
    }
}
