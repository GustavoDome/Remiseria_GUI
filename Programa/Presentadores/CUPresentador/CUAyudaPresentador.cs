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
            private AyudaPresentador presentador;
            private string rol;
            public CUAgregarCategoriaPresentador(ICategoriaRepositorio repositorio,IAgregarAyudaVistaCategoria categoria, IAyudaVista ayudavista, AyudaPresentador presentador, string rol)
            {
                this.categoriaRepositorio = repositorio;
                this.agregarCategoriaVista = categoria;
                this.ayudavista = ayudavista;
                this.presentador = presentador;
                this.rol = rol;

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
                    IAyudaVista ayuda = AyudaVista.ObtenerInstancia(this.rol);
                    this.presentador.RefrescarModelos();
                    ((Form)agregarCategoriaVista).Close();
                }
                else 
                {
                    MessageBox.Show("Porfavor complete todos los campos faltantes");
                }
            }
            private void volverAyuda(object sender, EventArgs e) 
            {
                IAyudaVista ayuda = AyudaVista.ObtenerInstancia(this.rol);
                ((Form)agregarCategoriaVista).Close();
            }
        }
        public class CUModificarCategoriaPresentador
        {
            private ICategoriaRepositorio categoriaRepositorio;
            private IModificarAyudaVistaCategoria modificarCategoriaVista;
            private IAyudaVista ayudavista;
            private CategoriaDTO categoriaOriginal;
            private AyudaPresentador presentador;

            public CUModificarCategoriaPresentador(ICategoriaRepositorio repositorio,IModificarAyudaVistaCategoria vista,IAyudaVista ayudavista,CategoriaDTO categoriaDTO,AyudaPresentador presentador)
            {
                this.categoriaRepositorio = repositorio;
                this.modificarCategoriaVista = vista;
                this.ayudavista = ayudavista;
                this.categoriaOriginal = categoriaDTO;
                this.presentador = presentador;

                this.modificarCategoriaVista.volver += volverAyuda;
                this.modificarCategoriaVista.modificar += modificarCategoria;

                // Mostrar nombre actual en la vista
                this.modificarCategoriaVista.categorianombre = categoriaDTO.NombreCategoria;
                this.presentador = presentador;
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
                this.presentador.RefrescarModelos();

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
            private AyudaPresentador presentador;

            public CUAgregarPreguntaPresentador(IPreguntaRepositorio repositorio, IAgregarAyudaVistaPregunta vista, IAyudaVista ayudavista, int idCategoria, AyudaPresentador presentador)
            {
                this.preguntaRepositorio = repositorio;
                this.agregarPreguntaVista = vista;
                this.ayudavista = ayudavista;
                this.idCategoria = idCategoria;

                this.agregarPreguntaVista.agregar += agregarPregunta;
                this.agregarPreguntaVista.volver += volverAyuda;
                this.presentador = presentador;
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
                this.presentador.RefrescarModelos();

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
            private AyudaPresentador presentador;

            public CUModificarPreguntaPresentador(IPreguntaRepositorio repositorio, IModificarAyudaVistaPregunta vista, IAyudaVista ayudavista, PreguntaDTO preguntaDTO, AyudaPresentador presentador)
            {
                this.preguntaRepositorio = repositorio;
                this.modificarPreguntaVista = vista;
                this.ayudavista = ayudavista;
                this.preguntaOriginal = preguntaDTO;

                this.modificarPreguntaVista.volver += volverAyuda;
                this.modificarPreguntaVista.modificar += modificarPregunta;

                this.modificarPreguntaVista.preguntatexto = preguntaDTO.Texto;
                this.presentador = presentador;
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
                this.presentador.RefrescarModelos();

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
            private AyudaPresentador presentador;

            public CUAgregarRespuestaPresentador(IRespuestasRepositorio repositorio, IAgregarAyudaVistaRespuesta vista, IAyudaVista ayudavista, int idPregunta, AyudaPresentador presentador)
            {
                this.respuestasRepositorio = repositorio;
                this.agregarRespuestaVista = vista;
                this.ayudavista = ayudavista;
                this.idPregunta = idPregunta;

                this.agregarRespuestaVista.agregar += agregarRespuesta;
                this.agregarRespuestaVista.volver += volverAyuda;
                this.presentador = presentador;
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
                this.presentador.RefrescarModelos();

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
            private AyudaPresentador presentador;

            public CUModificarRespuestaPresentador(IRespuestasRepositorio repositorio, IModificarAyudaVistaRespuesta vista, IAyudaVista ayudavista, RespuestaDTO respuestaDTO, AyudaPresentador presentador)
            {
                this.respuestasRepositorio = repositorio;
                this.modificarRespuestaVista = vista;
                this.ayudavista = ayudavista;
                this.respuestaOriginal = respuestaDTO;

                this.modificarRespuestaVista.volver += volverAyuda;
                this.modificarRespuestaVista.modificar += modificarRespuesta;

                this.modificarRespuestaVista.respuestatexto = respuestaDTO.TextoRespuesta;
                this.presentador = presentador;
            }

            private void modificarRespuesta(object sender, EventArgs e)
            {
                string nuevoTexto = modificarRespuestaVista.respuestatexto;
                byte[] nuevamultimedia = modificarRespuestaVista.multimedia;
                if (string.IsNullOrWhiteSpace(nuevoTexto))
                {
                    MessageBox.Show("Por favor complete el texto de la respuesta.");
                    return;
                }

                Respuesta respuestaModificada = new Respuesta
                {
                    IdRespuesta = respuestaOriginal.IdRespuesta,
                    TextoRespuesta = nuevoTexto,
                    IdPregunta = respuestaOriginal.IdPregunta,
                    AudioVideo = nuevamultimedia
                };

                respuestasRepositorio.Editar(respuestaModificada);

                var modeloActualizado = respuestasRepositorio.MostrarTodo()
                    .Where(r => r.IdPregunta == respuestaOriginal.IdPregunta)
                    .ToList();

                ayudavista.SetRespuestaBindingSource(new BindingSource { DataSource = modeloActualizado });
                this.presentador.RefrescarModelos();

                ((Form)modificarRespuestaVista).Close();
            }

            private void volverAyuda(object sender, EventArgs e)
            {
                ((Form)modificarRespuestaVista).Close();
            }
        }
    }
}
