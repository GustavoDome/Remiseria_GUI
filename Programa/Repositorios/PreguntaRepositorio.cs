using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    public class PreguntaRepositorio : IPreguntaRepositorio
    {
        public void Agregar(Pregunta preguntaModelo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Preguntas.Add(preguntaModelo);
                contexto.SaveChanges();
            }
        }

        public void Editar(Pregunta preguntaModelo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var preguntaExistente = contexto.Preguntas.Find(preguntaModelo.IdPregunta);
                if (preguntaExistente != null)
                {
                    preguntaExistente.TextoPregunta = preguntaModelo.TextoPregunta;
                    preguntaExistente.IdCategoria = preguntaModelo.IdCategoria;

                    contexto.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var pregunta = contexto.Preguntas.Find(id);
                if (pregunta != null)
                {
                    contexto.Preguntas.Remove(pregunta);
                    contexto.SaveChanges();
                }
            }
        }

        public IEnumerable<PreguntaDTO> MostrarTodo()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Preguntas
                    .Include(p => p.Categoria)
                   .Select(p => new PreguntaDTO
                   {
                       IdPregunta = p.IdPregunta,
                       Texto = p.TextoPregunta,
                       Categoria = p.Categoria.CategoriaPregunta,
                       IdCategoria = p.IdCategoria
                   })
                    .ToList();
            }
        }
    }
}
