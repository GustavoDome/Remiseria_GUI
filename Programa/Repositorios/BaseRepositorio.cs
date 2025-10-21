using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using System.Data.Entity;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static Programa.Conexion.RemiseriaDbContext;
using System.Windows.Forms;

namespace Programa.Repositorios
{
    /// <summary>
    /// Repositorio para operaciones CRUD sobre la entidad Base.
    /// Implementa la interfaz IBasesRepositorio.
    /// </summary>
    public class BaseRepositorio : IBasesRepositorio
    {
        /// <summary>
        /// Agrega una nueva instancia de Base al contexto de datos y guarda los cambios.
        /// </summary>
        /// <param name="nuevaBase">Instancia de Base a agregar.</param>
        public void Agregar(Base nuevaBase)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Bases.Add(nuevaBase);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los campos de una Base existente en la base de datos.
        /// </summary>
        /// <param name="baseEditada">Instancia de Base con los nuevos valores.</param>
        public void Editar(Base baseEditada)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var baseExistente = contexto.Bases.Find(baseEditada.IdBase);
                if (baseExistente != null)
                {
                    baseExistente.EstadoBase = baseEditada.EstadoBase;
                    baseExistente.Fecha_base = baseEditada.Fecha_base;
                    baseExistente.Comentario = baseEditada.Comentario;
                    baseExistente.IdMovil = baseEditada.IdMovil;
                    baseExistente.IdOperador = baseEditada.IdOperador;

                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Realiza un borrado lógico de una Base, marcándola como inactiva.
        /// </summary>
        /// <param name="id">Identificador de la Base a eliminar.</param>
        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var baseExistente = contexto.Bases.Find(id);
                if (baseExistente != null)
                {
                    baseExistente.Activo = false;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Edita únicamente el comentario de una Base existente.
        /// </summary>
        /// <param name="baseEditada">Instancia de Base con el nuevo comentario.</param>
        public void EditarComentario(Base baseEditada)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var baseExistente = contexto.Bases.Find(baseEditada.IdBase);
                if (baseExistente != null)
                {
                    baseExistente.Comentario = baseEditada.Comentario;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Verifica si existe una Base activa para un móvil en una fecha determinada.
        /// </summary>
        /// <param name="idMovil">Identificador del móvil.</param>
        /// <param name="fecha">Fecha a verificar.</param>
        /// <returns>True si existe una Base activa en esa fecha, false en caso contrario.</returns>
        public bool ExisteBaseEnFecha(int idMovil, DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var fechaInicio = fecha.Date;
                var fechaFin = fechaInicio.AddDays(1);

                return contexto.Bases.Any(b =>
                    b.IdMovil == idMovil &&
                    b.Fecha_base >= fechaInicio &&
                    b.Fecha_base < fechaFin &&
                    b.Activo);
            }
        }

        /// <summary>
        /// Obtiene una lista de móviles activos en formato DTO resumido.
        /// </summary>
        /// <returns>Lista de objetos MovilResumenDTO.</returns>
        public IEnumerable<MovilResumenDTO> SeleccionarMovil()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Moviles
                    .Where(m => m.Activo)
                    .Select(m => new MovilResumenDTO
                    {
                        IdMovil = m.IdMovil,
                        NumeroMovil = m.NumeroMovil
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Busca una Base por su identificador y devuelve sus datos en formato DTO detallado.
        /// </summary>
        /// <param name="idBase">Identificador de la Base.</param>
        /// <returns>Instancia de BaseDetalleDTO con los datos encontrados, o null si no existe.</returns>
        public BaseDetalleDTO BuscarPorId(int idBase)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Bases
                    .Include(b => b.Operador)
                    .Where(b => b.IdBase == idBase)
                    .Select(b => new BaseDetalleDTO
                    {
                        IdBase = b.IdBase,
                        Fecha_base = b.Fecha_base,
                        EstadoBase = b.EstadoBase,
                        Comentario = b.Comentario,
                        NombreOperador = b.Operador.Nombre,
                        RolOperador = b.Operador.RolUsuario
                    })
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Muestra todas las Bases activas asociadas a un móvil, ordenadas por fecha.
        /// </summary>
        /// <param name="id_movil">Identificador del móvil.</param>
        /// <returns>Lista de objetos BaseDetalleDTO.</returns>
        public IEnumerable<BaseDetalleDTO> MostrarTodo(int id_movil)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Bases
                    .Include(b => b.Operador)
                    .Where(b => b.Activo && b.IdMovil == id_movil)
                    .OrderBy(b => b.Fecha_base)
                    .Select(b => new BaseDetalleDTO
                    {
                        IdBase = b.IdBase,
                        Fecha_base = b.Fecha_base,
                        EstadoBase = b.EstadoBase,
                        Comentario = b.Comentario,
                        NombreOperador = b.Operador.Nombre,
                        RolOperador = b.Operador.RolUsuario
                    })

                    .ToList();
            }
        }
    }
}