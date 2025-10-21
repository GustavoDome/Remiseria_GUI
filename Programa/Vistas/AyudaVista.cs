using Programa.DTOs;
using Programa.Estilos;
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
    /// <summary>
    /// Vista principal del módulo de ayuda.
    /// Permite gestionar categorías, preguntas y respuestas, incluyendo contenido multimedia.
    /// Adapta la interfaz según el rol del operador.
    /// </summary>
    public partial class AyudaVista : Form, IAyudaVista
    {
        public AyudaVista(string rol)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ModificarVista_Load);
            asociarPresentador();
            this.rol = rol;
        }

        private void ModificarVista_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            GestorEstilosGlobal.Instance.AplicarEstilosAFormulario(this);
        }

        public void asociarPresentador()
        {
            btnPlanillaCostos.Click += (s, e) => ingresarPlanillasCosto?.Invoke(this, EventArgs.Empty);
            btnAgregarPregunta.Click += (s, e) => agregarPregunta?.Invoke(this, EventArgs.Empty);
            btnModificarPregunta.Click += (s, e) => modificarPregunta?.Invoke(this, EventArgs.Empty);
            btnEliminarPregunta.Click += (s, e) => eliminarPregunta?.Invoke(this, EventArgs.Empty);
            btnAgregarRespuesta.Click += (s, e) => agregarRespuesta?.Invoke(this, EventArgs.Empty);
            btnAgregarCategoria.Click += (s, e) => agregarCategoria?.Invoke(this, EventArgs.Empty);
            btnModificarCategoria.Click += (s, e) => modificarCategoria?.Invoke(this, EventArgs.Empty);
            btnEliminarCategoria.Click += (s, e) => eliminarCategoria?.Invoke(this, EventArgs.Empty);
            btnVolver.Click += (s, e) => volver?.Invoke(this, EventArgs.Empty);
        }
        private void OnModificarRespuesta(int idRespuesta)
        {
            respuestaModificarSeleccionada?.Invoke(idRespuesta);
        }

        private void OnEliminarRespuesta(int idRespuesta)
        {
            respuestaEliminarSeleccionada?.Invoke(idRespuesta);
        }

        public void ocultarBotones()
        {
            if(this.rol == "Operador") 
            {
                btnAgregarCategoria.Hide();
                btnModificarCategoria.Hide();
                btnEliminarCategoria.Hide();
                btnEliminarPregunta.Hide();
                btnAgregarRespuesta.Hide();
            }
        }

        public void SetCategoriaBindingSource(BindingSource categorias)
        {
            GBCategorias.Controls.Clear();
            var lista = categorias.DataSource as IEnumerable<CategoriaDTO>;
            if (lista != null)
            {
                int y = 20;
                foreach (var dto in lista)
                {
                    var boton = new Button
                    {
                        Text = dto.NombreCategoria,
                        Width = 230,
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
                int y = 20;
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
                int y = 20;
                foreach (var dto in lista)
                {
                    var label = new Label
                    {
                        Text = dto.TextoRespuesta,
                        Width = 460,
                        Height = 50,
                        AutoEllipsis = true,
                        Location = new Point(10, y)
                    };
                    GBRespuestas.Controls.Add(label);

                    if (dto.AudioVideo != null && dto.AudioVideo.Length > 0)
                    {
                        y += 50;
                        var btnMultimedia = new Button
                        {
                            Text = "Ver multimedia",
                            Width = 460,
                            Height = 100,
                            Location = new Point(10, y),
                            Tag = dto.AudioVideo
                        };
                        btnMultimedia.Click += (s, e) => ReproducirMultimedia((byte[])btnMultimedia.Tag);
                        GBRespuestas.Controls.Add(btnMultimedia);

                        y += 70;
                    }
                    if (this.rol != "Operador")
                    {
                        var btnModificar = new Button
                        {
                            Text = "Modificar",
                            Width = 150,
                            Height = 30,
                            Location = new Point(10, y + 75),
                            Tag = dto.IdRespuesta
                        };
                        btnModificar.Click += (s, e) =>
                        {
                            int idRespuesta = (int)((Button)s).Tag;
                            OnModificarRespuesta(idRespuesta);
                        };
                        GBRespuestas.Controls.Add(btnModificar);

                        var btnEliminar = new Button
                        {
                            Text = "Eliminar",
                            Width = 150,
                            Height = 30,
                            Location = new Point(160, y + 75),
                            Tag = dto.IdRespuesta
                        };
                        btnEliminar.Click += (s, e) =>
                        {
                            int idRespuesta = (int)((Button)s).Tag;
                            OnEliminarRespuesta(idRespuesta);
                        };
                        GBRespuestas.Controls.Add(btnEliminar);
                    }
                    y += 40;
                }
            }
        }

        private void OnCategoriaSeleccionada(int idCategoria)
        {
            categoriaSeleccionada?.Invoke(idCategoria);
        }

        private void OnPreguntaSeleccionada(int idPregunta)
        {
            preguntaSeleccionada?.Invoke(idPregunta);
        }

        // Eventos internos para comunicar selección al presentador
        public event Action<int> categoriaSeleccionada;
        public event Action<int> preguntaSeleccionada;
        public event EventHandler ingresarPlanillasCosto;
        public event EventHandler agregarPregunta;
        public event EventHandler modificarPregunta;
        public event EventHandler eliminarPregunta;
        public event EventHandler agregarRespuesta;
        public event EventHandler agregarCategoria;
        public event EventHandler modificarCategoria;
        public event EventHandler eliminarCategoria;
        public event EventHandler volver;
        public event Action<int> respuestaModificarSeleccionada;
        public event Action<int> respuestaEliminarSeleccionada;
        private string rol;

        // Singleton
        public static AyudaVista instancia;
        public static AyudaVista ObtenerInstancia(string rol)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AyudaVista(rol);
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
