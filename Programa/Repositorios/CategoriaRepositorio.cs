using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad Categoria.
    /// Implementa la interfaz ICategoriaRepositorio.
    /// </summary>
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        /// <summary>
        /// Agrega una nueva instancia de Categoria al contexto de datos y guarda los cambios.
        /// </summary>
        /// <param name="nuevaCategoria">Instancia de Categoria a agregar.</param>
        public void Agregar(Categoria nuevaCategoria)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Categorias.Add(nuevaCategoria);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los datos de una Categoria existente en la base de datos.
        /// </summary>
        /// <param name="categoriaEditada">Instancia de Categoria con los nuevos valores.</param>
        public void Editar(Categoria categoriaEditada)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var categoriaExistente = contexto.Categorias.Find(categoriaEditada.IdCategoria);
                if (categoriaExistente != null)
                {
                    categoriaExistente.CategoriaPregunta = categoriaEditada.CategoriaPregunta;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente una Categoria de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la Categoria a eliminar.</param>
        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var categoria = contexto.Categorias.Find(id);
                if (categoria != null)
                {
                    contexto.Categorias.Remove(categoria);
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene todas las Categorias disponibles en formato DTO.
        /// </summary>
        /// <returns>Lista de objetos CategoriaDTO con los datos básicos de cada categoría.</returns>
        public IEnumerable<CategoriaDTO> ObtenerTodas()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Categorias
                    .Select(c => new CategoriaDTO
                    {
                        IdCategoria = c.IdCategoria,
                        NombreCategoria = c.CategoriaPregunta
                    })
                    .ToList();
            }
        }
    }
}
