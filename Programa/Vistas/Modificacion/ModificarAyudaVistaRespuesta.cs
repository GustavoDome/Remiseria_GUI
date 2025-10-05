using Programa.Estilos;
using Programa.Modelos;
using Programa.Vistas.Alta;
using Programa.Vistas.Modificacion.Interfaces;
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

namespace Programa.Vistas.Modificacion
{
    public partial class ModificarAyudaVistaRespuesta : Form, IModificarAyudaVistaRespuesta
    {
        public ModificarAyudaVistaRespuesta()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarAyudaRespuestaVista_Load);
            asociarEventos();
        }
        private void ModificarAyudaRespuestaVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        public string respuestatexto
        {
            get { return trbRespuesta.Text; }
            set { trbRespuesta.Text = value; }
        }
        public byte[] multimedia
        {
            get => multimediaData;
            set => multimediaData = value;
        }

        public event EventHandler modificar;
        public event EventHandler volver;

        private byte[] multimediaData;
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

        private void asociarEventos()
        {
            btnModificar.Click += (s, e) => modificar?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
            btnAgregarArchivo.Click += (s, e) => cargarMultimedia();
        }
        public static ModificarAyudaVistaRespuesta ObtenerInstancia()
        {
            var instancia = new ModificarAyudaVistaRespuesta();
            return instancia;
        }
    }
}
