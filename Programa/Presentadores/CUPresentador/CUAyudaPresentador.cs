using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores.CUPresentador
{
    public class CUAyudaPresentador
    {
        public class CUAgregarCategoriaPresentador
        {
            private ICategoriaRepositorio categoriaRepositorio;
            private IAgregarAyudaVistaCategoria agregarCategoriaVista;
            private List<CategoriaDTO> modeloCategoria;
            private IAyudaVista ayudavista;
            public CUAgregarCategoriaPresentador(ICategoriaRepositorio repositorio,IAgregarAyudaVistaCategoria categoria, IAyudaVista ayudavista)
            {
                this.categoriaRepositorio = repositorio;
                this.agregarCategoriaVista = categoria;
                this.ayudavista = ayudavista;

                this.agregarCategoriaVista.agregar += agregarCategoria;
                this.agregarCategoriaVista.volver += volverAyuda;
            }
            private void agregarCategoria(object sender, EventArgs e) 
            {
                if(this.agregarCategoriaVista.categorianombre != null) 
                {
                    Categoria agregarCategoria = new Categoria { CategoriaPregunta = this.agregarCategoriaVista.categorianombre };
                    this.categoriaRepositorio.Agregar(agregarCategoria);
                    modeloCategoria = categoriaRepositorio.ObtenerTodas().ToList();
                    ayudavista.SetCategoriaBindingSource(new BindingSource { DataSource = modeloCategoria });
                    IAyudaVista ayuda = AyudaVista.ObtenerInstancia();
                    ((Form)agregarCategoriaVista).Close();
                }
                else 
                {
                    MessageBox.Show("Porfavor complete todos los campos faltantes");
                }
            }
            private void volverAyuda(object sender, EventArgs e) 
            {
                IAyudaVista ayuda = AyudaVista.ObtenerInstancia();
                ((Form)agregarCategoriaVista).Close();
            }
        }
        public class CUModificarCategoriaPresentador
        {
            private ICategoriaRepositorio categoriaRepositorio;
            private IModificarAyudaVistaCategoria modificarCategoriaVista;
            private IAyudaVista ayudavista;
            private CategoriaDTO categoriaOriginal;

            public CUModificarCategoriaPresentador(
                ICategoriaRepositorio repositorio,
                IModificarAyudaVistaCategoria vista,
                IAyudaVista ayudavista,
                CategoriaDTO categoriaDTO)
            {
                this.categoriaRepositorio = repositorio;
                this.modificarCategoriaVista = vista;
                this.ayudavista = ayudavista;
                this.categoriaOriginal = categoriaDTO;

                this.modificarCategoriaVista.volver += volverAyuda;
                this.modificarCategoriaVista.modificar += modificarCategoria;

                // Mostrar nombre actual en la vista
                this.modificarCategoriaVista.categorianombre = categoriaDTO.NombreCategoria;
            }

            private void modificarCategoria(object sender, EventArgs e)
            {
                string nuevoNombre = modificarCategoriaVista.categorianombre;
                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    MessageBox.Show("Por favor complete el nombre de la categoría.");
                    return;
                }

                Categoria categoriaModificada = new Categoria
                {
                    IdCategoria = categoriaOriginal.IdCategoria,
                    CategoriaPregunta = nuevoNombre
                };

                categoriaRepositorio.Editar(categoriaModificada);

                // Refrescar vista principal
                var modeloActualizado = categoriaRepositorio.ObtenerTodas().ToList();
                ayudavista.SetCategoriaBindingSource(new BindingSource { DataSource = modeloActualizado });

                ((Form)modificarCategoriaVista).Close();
            }

            private void volverAyuda(object sender, EventArgs e)
            {
                ((Form)modificarCategoriaVista).Close();
            }
        }
        public class CUAgregarPreguntaPresentador
        {
            private IAgregarAyudaVistaPregunta agregarPreguntaVista;
            private IPreguntaRepositorio preguntaRepositorio;
            private IAyudaVista ayudavista;
            private int idCategoria;

            public CUAgregarPreguntaPresentador(
                IPreguntaRepositorio repositorio,
                IAgregarAyudaVistaPregunta vista,
                IAyudaVista ayudavista,
                int idCategoria)
            {
                this.preguntaRepositorio = repositorio;
                this.agregarPreguntaVista = vista;
                this.ayudavista = ayudavista;
                this.idCategoria = idCategoria;

                this.agregarPreguntaVista.agregar += agregarPregunta;
                this.agregarPreguntaVista.volver += volverAyuda;
            }

            private void agregarPregunta(object sender, EventArgs e)
            {
                string texto = agregarPreguntaVista.preguntatexto;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    MessageBox.Show("Por favor complete el texto de la pregunta.");
                    return;
                }

                Pregunta nuevaPregunta = new Pregunta
                {
                    TextoPregunta = texto,
                    IdCategoria = idCategoria
                };

                preguntaRepositorio.Agregar(nuevaPregunta);

                var modeloActualizado = preguntaRepositorio.MostrarTodo()
                    .Where(p => p.IdCategoria == idCategoria)
                    .ToList();

                ayudavista.SetPreguntaBindingSource(new BindingSource { DataSource = modeloActualizado });

                ((Form)agregarPreguntaVista).Close();
            }

            private void volverAyuda(object sender, EventArgs e)
            {
                ((Form)agregarPreguntaVista).Close();
            }
        }
        public class CUModificarPreguntaPresentador
        {
            private IModificarAyudaVistaPregunta modificarPreguntaVista;
            private IPreguntaRepositorio preguntaRepositorio;
            private IAyudaVista ayudavista;
            private PreguntaDTO preguntaOriginal;

            public CUModificarPreguntaPresentador(
                IPreguntaRepositorio repositorio,
                IModificarAyudaVistaPregunta vista,
                IAyudaVista ayudavista,
                PreguntaDTO preguntaDTO)
            {
                this.preguntaRepositorio = repositorio;
                this.modificarPreguntaVista = vista;
                this.ayudavista = ayudavista;
                this.preguntaOriginal = preguntaDTO;

                this.modificarPreguntaVista.volver += volverAyuda;
                this.modificarPreguntaVista.modificar += modificarPregunta;

                this.modificarPreguntaVista.preguntatexto = preguntaDTO.Texto;
            }

            private void modificarPregunta(object sender, EventArgs e)
            {
                string nuevoTexto = modificarPreguntaVista.preguntatexto;
                if (string.IsNullOrWhiteSpace(nuevoTexto))
                {
                    MessageBox.Show("Por favor complete el texto de la pregunta.");
                    return;
                }

                Pregunta preguntaModificada = new Pregunta
                {
                    IdPregunta = preguntaOriginal.IdPregunta,
                    TextoPregunta = nuevoTexto,
                    IdCategoria = preguntaOriginal.IdCategoria
                };

                preguntaRepositorio.Editar(preguntaModificada);

                var modeloActualizado = preguntaRepositorio.MostrarTodo()
                    .Where(p => p.IdCategoria == preguntaOriginal.IdCategoria)
                    .ToList();

                ayudavista.SetPreguntaBindingSource(new BindingSource { DataSource = modeloActualizado });

                ((Form)modificarPreguntaVista).Close();
            }

            private void volverAyuda(object sender, EventArgs e)
            {
                ((Form)modificarPreguntaVista).Close();
            }
        }
        public class CUAgregarRespuestaPresentador
        {
            private IAgregarAyudaVistaRespuesta agregarRespuestaVista;
            private IRespuestasRepositorio respuestasRepositorio;
            private IAyudaVista ayudavista;
            private int idPregunta;

            public CUAgregarRespuestaPresentador(
                IRespuestasRepositorio repositorio,
                IAgregarAyudaVistaRespuesta vista,
                IAyudaVista ayudavista,
                int idPregunta)
            {
                this.respuestasRepositorio = repositorio;
                this.agregarRespuestaVista = vista;
                this.ayudavista = ayudavista;
                this.idPregunta = idPregunta;

                this.agregarRespuestaVista.agregar += agregarRespuesta;
                this.agregarRespuestaVista.volver += volverAyuda;
            }

            private void agregarRespuesta(object sender, EventArgs e)
            {
                string texto = agregarRespuestaVista.respuestatexto;
                byte[] multimedia = agregarRespuestaVista.multimedia;

                if (string.IsNullOrWhiteSpace(texto))
                {
                    MessageBox.Show("Por favor complete el texto de la respuesta.");
                    return;
                }

                Respuesta nuevaRespuesta = new Respuesta
                {
                    TextoRespuesta = texto,
                    IdPregunta = idPregunta,
                    AudioVideo = multimedia,
                };

                respuestasRepositorio.Agregar(nuevaRespuesta);

                var modeloRespuesta = respuestasRepositorio.MostrarTodo()
                    .Where(r => r.IdPregunta == idPregunta)
                    .ToList();

                ayudavista.SetRespuestaBindingSource(new BindingSource { DataSource = modeloRespuesta });

                ((Form)agregarRespuestaVista).Close();
            }

            private void volverAyuda(object sender, EventArgs e)
            {
                ((Form)agregarRespuestaVista).Close();
            }
        }
        public class CUModificarRespuestaPresentador
        {
            private IModificarAyudaVistaRespuesta modificarRespuestaVista;
            private IRespuestasRepositorio respuestasRepositorio;
            private IAyudaVista ayudavista;
            private RespuestaDTO respuestaOriginal;

            public CUModificarRespuestaPresentador(
                IRespuestasRepositorio repositorio,
                IModificarAyudaVistaRespuesta vista,
                IAyudaVista ayudavista,
                RespuestaDTO respuestaDTO)
            {
                this.respuestasRepositorio = repositorio;
                this.modificarRespuestaVista = vista;
                this.ayudavista = ayudavista;
                this.respuestaOriginal = respuestaDTO;

                this.modificarRespuestaVista.volver += volverAyuda;
                this.modificarRespuestaVista.modificar += modificarRespuesta;

                this.modificarRespuestaVista.respuestatexto = respuestaDTO.TextoRespuesta;
            }

            private void modificarRespuesta(object sender, EventArgs e)
            {
                string nuevoTexto = modificarRespuestaVista.respuestatexto;
                if (string.IsNullOrWhiteSpace(nuevoTexto))
                {
                    MessageBox.Show("Por favor complete el texto de la respuesta.");
                    return;
                }

                Respuesta respuestaModificada = new Respuesta
                {
                    IdRespuesta = respuestaOriginal.IdRespuesta,
                    TextoRespuesta = nuevoTexto,
                    IdPregunta = respuestaOriginal.IdPregunta
                };

                respuestasRepositorio.Editar(respuestaModificada);

                var modeloActualizado = respuestasRepositorio.MostrarTodo()
                    .Where(r => r.IdPregunta == respuestaOriginal.IdPregunta)
                    .ToList();

                ayudavista.SetRespuestaBindingSource(new BindingSource { DataSource = modeloActualizado });

                ((Form)modificarRespuestaVista).Close();
            }

            private void volverAyuda(object sender, EventArgs e)
            {
                ((Form)modificarRespuestaVista).Close();
            }
        }
    }
}
