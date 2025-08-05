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
    public partial class AyudaVista : Form, IAyudaVista
    {
        public AyudaVista()
        {
            InitializeComponent();
            asociarPresentador();
        }

        public void asociarPresentador() 
        {
            btnPlanillaCostos.Click += delegate 
            {
                ingresarPlanillasCosto?.Invoke(this, EventArgs.Empty);
            };
            btnAgregarPregunta.Click += delegate 
            {
                agregarPregunta?.Invoke(this, EventArgs.Empty);
            };
            btnModificarPregunta.Click += delegate 
            {
                modificarPregunta?.Invoke(this, EventArgs.Empty); 
            };
            btnEliminarPregunta.Click += delegate 
            {
                eliminarPregunta?.Invoke(this, EventArgs.Empty);
            };
            btnAgregarRespuesta.Click += delegate
            {
                agregarRespuesta?.Invoke(this, EventArgs.Empty);
            };
            btnModificarRespuesta.Click += delegate 
            {
                modificarRespuesta?.Invoke(this, EventArgs.Empty);
            };
            btnEliminarRespuesta.Click += delegate 
            {
                eliminarRespuesta?.Invoke(this, EventArgs.Empty); 
            };
            btnAgregarCategoria.Click += delegate 
            {
                agregarCategoria?.Invoke(this, EventArgs.Empty);
            };
            btnModificarCategoria.Click += delegate 
            {
                modificarCategoria?.Invoke(this, EventArgs.Empty);
            };
            btnEliminarCategoria.Click += delegate 
            {
                eliminarCategoria?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            {
                volver?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler ingresarPlanillasCosto;
        public event EventHandler agregarPregunta;
        public event EventHandler modificarPregunta;
        public event EventHandler eliminarPregunta;
        public event EventHandler agregarRespuesta;
        public event EventHandler modificarRespuesta;
        public event EventHandler eliminarRespuesta;
        public event EventHandler agregarCategoria;
        public event EventHandler modificarCategoria;
        public event EventHandler eliminarCategoria;
        public event EventHandler volver;

        public void SetCategoriaBindingSource(BindingSource categorias) { }
        public void SetPreguntaBindingSource(BindingSource preguntas) { }
        public void SetRespuestaBindingSource(BindingSource respuestas) { }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static AyudaVista instancia;

        // Metodo para el uso del Singleton
        public static AyudaVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AyudaVista();
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
