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
    public class DuenoAutoRepositorio : IDuenoAutoRepositorio
    {
        public void Agregar(DuenoAuto nuevoDueno)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.DuenoAutos.Add(nuevoDueno);
                contexto.SaveChanges();
            }
        }

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
