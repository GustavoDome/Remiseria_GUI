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
    public partial class OperadoresVista : Form, IOperadoresVista
    {
        public OperadoresVista()
        {
            InitializeComponent();
            asociacionPresentador();
        }

        public void asociacionPresentador() 
        {
            btnAgregar.Click += delegate 
            {
                agregarOperador?.Invoke(this, EventArgs.Empty);
            };
            btnModificar.Click += delegate 
            { modificiarOperador?.Invoke(this, EventArgs.Empty);
            };
            btnEliminar.Click += delegate 
            { eliminarOperador?.Invoke(this, EventArgs.Empty);
            };
            btnVolver.Click += delegate 
            { volver?.Invoke(this, EventArgs.Empty);
            };
        }

        // Variable que llamaran los otros forms para el comportamiento Singleton
        private static OperadoresVista instancia;

        public event EventHandler agregarOperador;
        public event EventHandler modificiarOperador;
        public event EventHandler eliminarOperador;
        public event EventHandler volver;
        public void SetOperadoresBindingSource(BindingSource operadores) 
        {
            dgvOperadores.DataSource = operadores;
        }
        public int ObtenerIdOperadorSeleccionado()
        {
            return Convert.ToInt32(dgvOperadores.CurrentRow.Cells["ID"].Value);
        }

        // Metodo para el uso del Singleton
        public static OperadoresVista ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new OperadoresVista();
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
