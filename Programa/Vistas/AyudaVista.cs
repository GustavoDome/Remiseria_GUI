using Programa.DTOs;
using Programa.Vistas.Interfaces;
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

namespace Programa.Vistas
{
    public partial class AyudaVista : Form, IAyudaVista
    {
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

        public AyudaVista()
        {
            InitializeComponent();
            asociarPresentador();
        }

        public void asociarPresentador()
        {
            btnPlanillaCostos.Click += (s, e) => ingresarPlanillasCosto?.Invoke(this, EventArgs.Empty);
            btnAgregarPregunta.Click += (s, e) => agregarPregunta?.Invoke(this, EventArgs.Empty);
            btnModificarPregunta.Click += (s, e) => modificarPregunta?.Invoke(this, EventArgs.Empty);
            btnEliminarPregunta.Click += (s, e) => eliminarPregunta?.Invoke(this, EventArgs.Empty);
            btnAgregarRespuesta.Click += (s, e) => agregarRespuesta?.Invoke(this, EventArgs.Empty);
            btnModificarRespuesta.Click += (s, e) => modificarRespuesta?.Invoke(this, EventArgs.Empty);
            btnEliminarRespuesta.Click += (s, e) => eliminarRespuesta?.Invoke(this, EventArgs.Empty);
            btnAgregarCategoria.Click += (s, e) => agregarCategoria?.Invoke(this, EventArgs.Empty);
            btnModificarCategoria.Click += (s, e) => modificarCategoria?.Invoke(this, EventArgs.Empty);
            btnEliminarCategoria.Click += (s, e) => eliminarCategoria?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }

        public void ocultarBotones(string rol)
        {
            // lógica para ocultar botones según el rol
        }

        public void SetCategoriaBindingSource(BindingSource categorias)
        {
            GBCategorias.Controls.Clear();
            var lista = categorias.DataSource as IEnumerable<CategoriaDTO>;
            if (lista != null)
            {
                int y = 10;
                foreach (var dto in lista)
                {
                    var boton = new Button
                    {
                        Text = dto.NombreCategoria,
                        Width = 160,
                        Height = 40,
                        Location = new Point(10, y),
                        Tag = dto.IdCategoria
                    };
                    boton.Click += (s, e) => OnCategoriaSeleccionada(dto.IdCategoria);
                    GBCategorias.Controls.Add(boton);
                    y += 45; // Espaciado vertical
                }
            }
        }

        public void SetPreguntaBindingSource(BindingSource preguntas)
        {
            GBPreguntas.Controls.Clear();
            var lista = preguntas.DataSource as IEnumerable<PreguntaDTO>;
            if (lista != null)
            {
                int y = 10;
                foreach (var dto in lista)
                {
                    var boton = new Button
                    {
                        Text = dto.Texto,
                        Width = 440,
                        Height = 40,
                        Location = new Point(10, y),
                        Tag = dto.IdPregunta
                    };
                    boton.Click += (s, e) => OnPreguntaSeleccionada(dto.IdPregunta);
                    GBPreguntas.Controls.Add(boton);
                    y += 45;
                }
            }
        }

        private void ReproducirMultimedia(byte[] datos)
        {
            try
            {
                // Guardar temporalmente el archivo
                string rutaTemporal = Path.Combine(Path.GetTempPath(), "respuesta_multimedia.mp4");
                File.WriteAllBytes(rutaTemporal, datos);

                // Abrir con el reproductor predeterminado
                System.Diagnostics.Process.Start(rutaTemporal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo reproducir el contenido multimedia.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetRespuestaBindingSource(BindingSource respuestas)
        {
            GBRespuestas.Controls.Clear();
            var lista = respuestas.DataSource as IEnumerable<RespuestaDTO>;
            if (lista != null)
            {
                int y = 10;
                foreach (var dto in lista)
                {
                    var label = new Label
                    {
                        Text = dto.TextoRespuesta,
                        Width = 300,
                        Height = 30,
                        Location = new Point(10, y)
                    };
                    GBRespuestas.Controls.Add(label);

                    if (dto.TieneMultimedia)
                    {
                        var btnMultimedia = new Button
                        {
                            Text = "Ver multimedia",
                            Width = 120,
                            Height = 30,
                            Location = new Point(320, y),
                            Tag = dto.AudioVideo
                        };
                        btnMultimedia.Click += (s, e) => ReproducirMultimedia((byte[])btnMultimedia.Tag);
                        GBRespuestas.Controls.Add(btnMultimedia);
                    }

                    y += 35;
                }
            }
        }

        // Eventos internos para comunicar selección al presentador
        public event Action<int> categoriaSeleccionada;
        public event Action<int> preguntaSeleccionada;

        private void OnCategoriaSeleccionada(int idCategoria)
        {
            categoriaSeleccionada?.Invoke(idCategoria);
        }

        private void OnPreguntaSeleccionada(int idPregunta)
        {
            preguntaSeleccionada?.Invoke(idPregunta);
        }

        // Singleton
        private static AyudaVista instancia;
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
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
                instancia.Activate();
            }
            return instancia;
        }
    }
}
