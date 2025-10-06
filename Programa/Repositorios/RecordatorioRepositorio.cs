using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
                try
                {
                    // Crear una entidad mínima del operador con solo el ID
                    var operadorStub = new Operador { IdOperador = nuevoRecordatorio.IdOperador };
                    contexto.Operadores.Attach(operadorStub);
                    nuevoRecordatorio.Operador = operadorStub;

                    contexto.Recordatorios.Add(nuevoRecordatorio);
                    contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el recordatorio: " + ex.InnerException?.Message ?? ex.Message);
                }
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
                    recordatorioExistente.Comentario = recordatorioEditado.Comentario;

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
        public RecordatorioDTO ObtenerPorId(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var r = contexto.Recordatorios.FirstOrDefault(x => x.IdRecordatorio == id);
                if (r == null) return null;

                return new RecordatorioDTO
                {
                    IdRecordatorio = r.IdRecordatorio,
                    Direccion = r.Ubicacion,
                    FechaDia = r.FechaDia ?? DateTime.MinValue,
                    FechaHora = r.FechaHora ?? DateTime.MinValue,
                    Comentario = r.Comentario,
                    NombreOperador = "" // opcional
                };
            }
        }
        public string ObtenerTipoAlarma(int idOperador)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operador = contexto.Operadores.FirstOrDefault(o => o.IdOperador == idOperador);
                return operador?.TipoAlarma ?? "default";
            }
        }
        public IEnumerable<RecordatorioDTO> ObtenerTodos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Recordatorios
                    .OrderBy(r => r.IdRecordatorio)
                    .Select(r => new RecordatorioDTO
                    {
                        IdRecordatorio = r.IdRecordatorio,
                        Direccion = r.Ubicacion,
                        FechaDia = r.FechaDia ?? DateTime.MinValue,
                        FechaHora = r.FechaHora ?? DateTime.MinValue,
                        Comentario = r.Comentario,
                        NombreOperador = r.Operador != null ? r.Operador.Nombre : "(Sin nombre)"
                    })
                    .ToList();
            }
        }
    }
}
