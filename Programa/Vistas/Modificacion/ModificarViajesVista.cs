using Programa.DTOs;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Programa.Vistas.Modificacion
{
    /// <summary>
    /// Vista de modificación para viajes existentes.
    /// Permite editar dirección, móviles asignados y comentarios según tipo de viaje.
    /// </summary>
    public partial class ModificarViajesVista : Form, IModificarViajesVista
    {
        public ModificarViajesVista()
        {
            this.Load += new EventHandler(ModificarVista_Load);
            InitializeComponent();
            asociarPresentador();

            rbtnAfuera.CheckedChanged += (s, e) => actualizarComentario("Escriba dónde es el viaje");
            rbtnDerivado.CheckedChanged += (s, e) => actualizarComentario("Escriba de quién se deriva el viaje");
            rbtnDesignado.CheckedChanged += (s, e) => actualizarComentario("Escriba quién designó el viaje");
            rbtnOtro.CheckedChanged += (s, e) => actualizarComentario("Escriba el comentario");
        }

        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        private void asociarPresentador()
        {
            btnAgregar.Click += delegate { modificar?.Invoke(this, EventArgs.Empty); };
            btnVolver.Click += delegate { volver?.Invoke(this, EventArgs.Empty); };
        }

        private void actualizarComentario(string textoLabel)
        {
            lblComentario.Text = textoLabel;
            lblComentario.Visible = true;
            rtbComentarios.Text = string.Empty;
            rtbComentarios.Visible = true;
        }

        public void SetComentario(string comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario))
            {
                rbtnAfuera.Checked = false;
                rbtnDerivado.Checked = false;
                rbtnDesignado.Checked = false;
                rbtnOtro.Checked = false;

                rtbComentarios.Text = string.Empty;
                lblComentario.Visible = false;
                rtbComentarios.Visible = false;
                return;
            }

            if (comentario.StartsWith("Escriba dónde"))
                rbtnAfuera.Checked = true;
            else if (comentario.StartsWith("Escriba de quién"))
                rbtnDerivado.Checked = true;
            else if (comentario.StartsWith("Escriba quién"))
                rbtnDesignado.Checked = true;
            else
                rbtnOtro.Checked = true;

            rtbComentarios.Text = comentario;
            lblComentario.Visible = true;
            rtbComentarios.Visible = true;
        }

        public string obtenerOpcion()
        {
            if (rbtnAfuera.Checked) return rtbComentarios.Text;
            if (rbtnDerivado.Checked) return rtbComentarios.Text;
            if (rbtnDesignado.Checked) return rtbComentarios.Text;
            if (rbtnOtro.Checked) return rtbComentarios.Text;
            return null;
        }

        public void CargarMoviles(List<MovilResumenDTO> moviles, List<int> seleccionados)
        {
            gbMoviles.Controls.Clear();
            var clb = new CheckedListBox
            {
                Name = "clbMoviles",
                Dock = DockStyle.Fill,
                CheckOnClick = true
            };

            foreach (var movil in moviles)
            {
                var visual = new MovilVisualDTO
                {
                    IdMovil = movil.IdMovil,
                    Texto = $"Móvil {movil.NumeroMovil}"
                };
                int index = clb.Items.Add(visual);
                if (seleccionados.Contains(movil.IdMovil))
                    clb.SetItemChecked(index, true);
            }

            gbMoviles.Controls.Add(clb);
        }

        public List<int> ObtenerMovilesSeleccionados()
        {
            var clb = gbMoviles.Controls.Find("clbMoviles", true).FirstOrDefault() as CheckedListBox;
            if (clb == null) return new List<int>();

            return clb.CheckedItems
                .Cast<MovilVisualDTO>()
                .Select(m => m.IdMovil)
                .ToList();
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        // Propiedades
        public string txtDirecciones
        {
            get => txtViaje.Text;
            set => txtViaje.Text = value;
        }

        public string rtbComentario
        {
            get => rtbComentarios.Text;
            set => rtbComentarios.Text = value;
        }

        public static ModificarViajesVista ObtenerInstancia()
        {
            var instancia = new ModificarViajesVista();
            return instancia;
        }

    }
}
