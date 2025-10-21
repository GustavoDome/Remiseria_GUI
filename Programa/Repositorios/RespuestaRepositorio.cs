using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad Respuesta.
    /// Implementa la interfaz <see cref="IRespuestasRepositorio"/>.
    /// </summary>
    public class RespuestaRepositorio : IRespuestasRepositorio
    {
        /// <summary>
        /// Agrega una nueva respuesta al contexto de datos y guarda los cambios.
        /// </summary>
        /// <param name="respuestaModelo">Instancia de <see cref="Respuesta"/> que representa la nueva respuesta a registrar.</param>
        public void Agregar(Respuesta respuestaModelo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Respuestas.Add(respuestaModelo);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los datos de una respuesta existente en la base de datos.
        /// </summary>
        /// <param name="respuestaModelo">Instancia de <see cref="Respuesta"/> con los nuevos datos a actualizar.</param>
        public void Editar(Respuesta respuestaModelo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var respuestaExistente = contexto.Respuestas.Find(respuestaModelo.IdRespuesta);
                if (respuestaExistente != null)
                {
                    respuestaExistente.TextoRespuesta = respuestaModelo.TextoRespuesta;
                    respuestaExistente.AudioVideo = respuestaModelo.AudioVideo;
                    respuestaExistente.IdPregunta = respuestaModelo.IdPregunta;

                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente una respuesta de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador de la respuesta a eliminar.</param>
        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var respuesta = contexto.Respuestas.Find(id);
                if (respuesta != null)
                {
                    contexto.Respuestas.Remove(respuesta);
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Muestra todas las respuestas registradas en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="RespuestaDTO"/> con los datos básicos de cada respuesta.
        /// </returns>
        public IEnumerable<RespuestaDTO> MostrarTodo()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Respuestas
                    .Select(r => new RespuestaDTO
                    {
                        IdRespuesta = r.IdRespuesta,
                        TextoRespuesta = r.TextoRespuesta,
                        AudioVideo = r.AudioVideo,
                        IdPregunta = r.IdPregunta
                    })
                    .ToList();
            }
        }
    }
}
