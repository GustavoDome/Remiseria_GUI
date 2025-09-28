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
    public partial class AgregarAyudaVistaRespuesta : Form, IAgregarAyudaVistaRespuesta
    {
        public AgregarAyudaVistaRespuesta()
        {
            InitializeComponent();
            asociarEventos();
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

        // Singleton
        private static AgregarAyudaVistaRespuesta instancia;
        public static AgregarAyudaVistaRespuesta ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AgregarAyudaVistaRespuesta();
                instancia.Show();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
