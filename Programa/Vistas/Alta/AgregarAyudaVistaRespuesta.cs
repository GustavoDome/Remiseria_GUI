using Programa.Estilos;
using Programa.Vistas.Alta.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Alta
{
    /// <summary>
    /// Vista de agregación para una nueva respuesta en el módulo de ayuda.
    /// Permite ingresar texto y adjuntar contenido multimedia.
    /// </summary>
    public partial class AgregarAyudaVistaRespuesta : Form, IAgregarAyudaVistaRespuesta
    {
        public AgregarAyudaVistaRespuesta()
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

        private void asociarEventos()
        {
            btnAgregar.Click += (s, e) => agregar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
            btnAgregarArchivo.Click += (s, e) => cargarMultimedia();
        }

        private void cargarMultimedia()
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Archivos multimedia|*.mp4;*.mp3;*.wav";
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    multimediaData = File.ReadAllBytes(dialogo.FileName);
                    MessageBox.Show("Multimedia cargada correctamente.");
                }
            }
        }
        public string respuestatexto
        {
            get => trbRespuesta.Text;
            set => trbRespuesta.Text = value;
        }

        public byte[] multimedia
        {
            get => multimediaData;
            set => multimediaData = value;
        }

        public event EventHandler agregar;
        public event EventHandler volver;

        private byte[] multimediaData;

        public static AgregarAyudaVistaRespuesta ObtenerInstancia()
        {
            var instancia = new AgregarAyudaVistaRespuesta();
            return instancia;
        }
    }
}
