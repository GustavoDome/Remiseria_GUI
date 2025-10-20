using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad DuenoAuto.
    /// Implementa la interfaz IDuenoAutoRepositorio.
    /// </summary>
    public class DuenoAutoRepositorio : IDuenoAutoRepositorio
    {
        /// <summary>
        /// Agrega un nuevo dueño de auto al contexto de datos y guarda los cambios.
        /// </summary>
        /// <param name="nuevoDueno">Instancia de <see cref="DuenoAuto"/> que representa el nuevo dueño a registrar.</param>
        public void Agregar(DuenoAuto nuevoDueno)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.DuenoAutos.Add(nuevoDueno);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los datos de un dueño de auto existente en la base de datos.
        /// </summary>
        /// <param name="duenoEditado">Instancia de <see cref="DuenoAuto"/> con los nuevos datos a actualizar.</param>
        public void Editar(DuenoAuto duenoEditado)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var duenoExistente = contexto.DuenoAutos.Find(duenoEditado.IdDueno);
                if (duenoExistente != null)
                {
                    duenoExistente.Nombre = duenoEditado.Nombre;
                    duenoExistente.Apellido = duenoEditado.Apellido;
                    duenoExistente.Direccion = duenoEditado.Direccion;
                    duenoExistente.Chofer = duenoEditado.Chofer;
                    duenoExistente.Telefono = duenoEditado.Telefono;

                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Realiza un borrado lógico del dueño de auto, marcándolo como inactivo.
        /// </summary>
        /// <param name="id">Identificador del dueño de auto a eliminar.</param>
        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var dueno = contexto.DuenoAutos.Find(id);
                if (dueno != null)
                {
                    dueno.Activo = false;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene todos los dueños de auto activos en formato DTO.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="DuenoAutoDTO"/> que contienen los datos básicos de cada dueño.
        /// </returns>
        public IEnumerable<DuenoAutoDTO> ObtenerTodos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.DuenoAutos
                    .Where(d => d.Activo)
                    .Select(d => new DuenoAutoDTO
                    {
                        IdDueno = d.IdDueno,
                        Nombre = d.Nombre,
                        Apellido = d.Apellido,
                        Telefono = d.Telefono,
                        Chofer = d.Chofer
                    })
                    .ToList();
            }
        }
    }
}
