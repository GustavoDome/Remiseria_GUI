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

namespace Programa.Repositorios
{
    public class BaseRepositorio : IBasesRepositorio
    {
        public void Agregar(Base nuevaBase)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Bases.Add(nuevaBase);
                contexto.SaveChanges();
            }
        }

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
