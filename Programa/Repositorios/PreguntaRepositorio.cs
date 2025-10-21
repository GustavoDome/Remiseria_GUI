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
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad Pregunta.
    /// Implementa la interfaz <see cref="IPreguntaRepositorio"/>.
    /// </summary>
    public class PreguntaRepositorio : IPreguntaRepositorio
    {
        /// <summary>
        /// Agrega una nueva pregunta al contexto de datos y guarda los cambios.
        /// </summary>
        /// <param name="preguntaModelo">Instancia de <see cref="Pregunta"/> que representa la nueva pregunta a registrar.</param>
        public void Agregar(Pregunta preguntaModelo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Preguntas.Add(preguntaModelo);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los datos de una pregunta existente en la base de datos.
        /// </summary>
        /// <param name="preguntaModelo">Instancia de <see cref="Pregunta"/> con los nuevos datos a actualizar.</param>
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

        /// <summary>
        /// Elimina físicamente una pregunta de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador de la pregunta a eliminar.</param>
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

        /// <summary>
        /// Muestra todas las preguntas registradas, incluyendo su categoría asociada.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="PreguntaDTO"/> con los datos completos de cada pregunta.
        /// </returns>
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
