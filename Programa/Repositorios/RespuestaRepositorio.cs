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
    public class RespuestaRepositorio : IRespuestasRepositorio
    {
        public void Agregar(Respuesta respuestaModelo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Respuestas.Add(respuestaModelo);
                contexto.SaveChanges();
            }
        }

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
