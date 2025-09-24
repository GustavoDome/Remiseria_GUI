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
    public class RecordatorioRepositorio : IRecordatorioRepositorio
    {
        private readonly Conexion.RemiseriaDbContext BD = new Conexion.RemiseriaDbContext();

        public void Agregar(Recordatorio nuevoRecordatorio)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Recordatorios.Add(nuevoRecordatorio);
                contexto.SaveChanges();
            }
        }

        public void Editar(Recordatorio recordatorioEditado)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var recordatorioExistente = contexto.Recordatorios.Find(recordatorioEditado.IdRecordatorio);
                if (recordatorioExistente != null)
                {
                    recordatorioExistente.Ubicacion = recordatorioEditado.Ubicacion;
                    recordatorioExistente.FechaDia = recordatorioEditado.FechaDia;
                    recordatorioExistente.FechaHora = recordatorioEditado.FechaHora;

                    contexto.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var recordatorio = contexto.Recordatorios.Find(id);
                if (recordatorio != null)
                {
                    contexto.Recordatorios.Remove(recordatorio);
                    contexto.SaveChanges();
                }
            }
        }

        public IEnumerable<RecordatorioDTO> ObtenerTodos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Recordatorios
                    .Select(r => new RecordatorioDTO
                    {
                        Ubicacion = r.Ubicacion,
                        FechaDia = r.FechaDia ?? DateTime.MinValue,
                        FechaHora = r.FechaHora ?? DateTime.MinValue,
                        NombreOperador = "" // Si querés incluirlo, habría que hacer un join con Operador
                    })
                    .ToList();
            }
        }
    }
}
