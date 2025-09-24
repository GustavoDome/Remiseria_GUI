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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public void Agregar(Categoria nuevaCategoria)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Categorias.Add(nuevaCategoria);
                contexto.SaveChanges();
            }
        }

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
