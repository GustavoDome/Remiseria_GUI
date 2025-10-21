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
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad Recordatorio.
    /// Implementa la interfaz <see cref="IRecordatorioRepositorio"/>.
    /// </summary>
    public class RecordatorioRepositorio : IRecordatorioRepositorio
    {
        private readonly Conexion.RemiseriaDbContext BD = new Conexion.RemiseriaDbContext();

        /// <summary>
        /// Agrega un nuevo recordatorio al contexto de datos, asociándolo al operador correspondiente.
        /// </summary>
        /// <param name="nuevoRecordatorio">Instancia de <see cref="Recordatorio"/> que representa el nuevo recordatorio a registrar.</param>
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

        /// <summary>
        /// Edita los datos de un recordatorio existente en la base de datos.
        /// </summary>
        /// <param name="recordatorioEditado">Instancia de <see cref="Recordatorio"/> con los nuevos datos a actualizar.</param>
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

        /// <summary>
        /// Elimina físicamente un recordatorio de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador del recordatorio a eliminar.</param>
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

        /// <summary>
        /// Obtiene un recordatorio específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del recordatorio.</param>
        /// <returns>
        /// Objeto <see cref="RecordatorioDTO"/> con los datos del recordatorio, o null si no se encuentra.
        /// </returns>
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

        /// <summary>
        /// Obtiene el tipo de alarma configurado para un operador específico.
        /// </summary>
        /// <param name="idOperador">Identificador del operador.</param>
        /// <returns>
        /// Cadena que representa el tipo de alarma, o "default" si no se encuentra el operador.
        /// </returns>
        public string ObtenerTipoAlarma(int idOperador)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operador = contexto.Operadores.FirstOrDefault(o => o.IdOperador == idOperador);
                return operador?.TipoAlarma ?? "default";
            }
        }

        /// <summary>
        /// Obtiene todos los recordatorios registrados en la base de datos, ordenados por identificador.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="RecordatorioDTO"/> con los datos completos de cada recordatorio.
        /// </returns>
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
