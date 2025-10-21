using Programa.DTOs;
using Programa.Estilos;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Presentadores;
using Programa.Repositorios;
using Programa.Vistas.Alta.Interfaces;
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

namespace Programa.Vistas.Alta
{
    /// <summary>
    /// Vista de agregación para registrar un nuevo viaje.
    /// Permite ingresar dirección, móviles asignados y comentarios según tipo de viaje.
    /// </summary>
    public partial class AgregarViajesVista : Form, IAgregarViajesVista
    {
        private int idViaje;
        private int idOperador;
        private string rol;

        public AgregarViajesVista(int idViaje, int idOperador, string rol)
        {
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            InitializeComponent();
            asociarPresentador();
            rbtnAfuera.Checked = false;
            rdbtnDerivado.Checked = false;
            rbtnDesignado.Checked = false;
            rbtnOtro.Checked = false;

            lblComentario.Visible = false;
            rtbComentario.Visible = false;

            this.idViaje = idViaje;
            this.idOperador = idOperador;
            this.rol = rol;
            rbtnAfuera.CheckedChanged += (s, e) =>
            {
                if (rbtnAfuera.Checked)
                    actualizarComentario("Escriba dónde es el viaje");
            };

            rdbtnDerivado.CheckedChanged += (s, e) =>
            {
                if (rdbtnDerivado.Checked)
                    actualizarComentario("Escriba de quién se deriva el viaje");
            };

            rbtnDesignado.CheckedChanged += (s, e) =>
            {
                if (rbtnDesignado.Checked)
                    actualizarComentario("Escriba quién designó el viaje");
            };

            rbtnOtro.CheckedChanged += (s, e) =>
            {
                if (rbtnOtro.Checked)
                    actualizarComentario("Escriba el comentario");
            };
        }

        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        public void asociarPresentador() 
        {
            btnAgregar.Click += delegate { agregar?.Invoke(this, EventArgs.Empty); };
            btnVolver.Click += delegate { volver?.Invoke(this, EventArgs.Empty); };
        }

        public string obtenerOpcion()
        {
            if (rbtnAfuera.Checked) return rtbComentario.Text;
            if (rbtnDesignado.Checked) return rtbComentario.Text;
            if (rdbtnDerivado.Checked) return rtbComentario.Text;
            if (rbtnOtro.Checked) return rtbComentario.Text;
            return null;
        }

        public List<int> ObtenerMovilesSeleccionados()
        {
            return clbMoviles.CheckedItems
                .Cast<MovilVisualDTO>()
                .Select(m => m.IdMovil)
                .ToList();
        }

        public void CargarMoviles(List<MovilResumenDTO> moviles)
        {
            clbMoviles.Items.Clear();
            clbMoviles.DataSource = null; // por si quedó algo asignado

            foreach (var movil in moviles)
            {
                var visual = new MovilVisualDTO
                {
                    IdMovil = movil.IdMovil,
                    Texto = $"Móvil {movil.NumeroMovil}"
                };

                clbMoviles.Items.Add(visual, false); // Ahora sí: objeto seguro + texto visible
            }
        }

        private void actualizarComentario(string textoLabel)
        {
            lblComentario.Text = textoLabel;
            lblComentario.Visible = true;

            rtbComentario.Text = string.Empty;
            rtbComentario.Visible = true;
        }

        // Propiedades
        public string txtDirecciones
        {
            get => txtDireccion.Text;
            set => txtDireccion.Text = value;
        }

        public string rtbComentarios
        {
            get => rtbComentario.Text;
            set => rtbComentario.Text = value;
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        public static AgregarViajesVista ObtenerInstancia(int idViaje, int idOperador, string rol)
        {
            var vista = new AgregarViajesVista(idViaje, idOperador, rol);
            return vista;
        }

    }
}
