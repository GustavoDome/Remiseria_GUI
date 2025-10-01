using System.Data.Entity;
using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    public class ViajesRepositorio : IViajesRepositorio
    {
        public void Agregar(AgregarViajeDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            using (var tran = contexto.Database.BeginTransaction())
            {
                try
                {
                    // Crear el viaje
                    var viaje = new Viaje
                    {
                        NumeroViaje = dto.NumeroViaje,
                        HoraViaje = dto.HoraViaje,
                        Direccion = dto.Direccion,
                        EstadoViaje = dto.EstadoViaje,
                        Comentario = dto.Comentario,
                        IdOperador = dto.IdOperador,
                        Vueltas = new List<Vuelta>() // inicializamos la colección
                    };

                    var movilesValidos = contexto.Moviles.Select(m => m.IdMovil).ToList();
                    var movilesInvalidos = dto.IdMoviles.Except(movilesValidos).ToList();

                    if (movilesInvalidos.Any())
                        throw new Exception("Los siguientes móviles no existen: " + string.Join(", ", movilesInvalidos));

                    // Agregar vueltas directamente a la colección
                    for (int i = 0; i < dto.IdMoviles.Count; i++)
                    {
                        var vuelta = new Vuelta
                        {
                            IdMovil = dto.IdMoviles[i],
                            NumeroVuelta = dto.Vueltas[i],
                            VueltaFecha = dto.VueltaFecha,
                            EstadoVuelta = dto.EstadoVuelta
                        };

                        viaje.Vueltas.Add(vuelta); // EF se encarga de asignar IdViaje
                    }

                    // Guardar todo en cascada
                    contexto.Viajes.Add(viaje);
                    contexto.SaveChanges(); // genera el ID y guarda las vueltas

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    var inner = ex.InnerException;
                    while (inner?.InnerException != null)
                        inner = inner.InnerException;

                    MessageBox.Show("Error interno: " + (inner?.Message ?? ex.Message));
                    throw;
                }
            }
        }
        public ModificarViajeDTO ObtenerPorId(int idViaje)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var viaje = contexto.Viajes
                    .Include(v => v.Vueltas)
                    .FirstOrDefault(v => v.IdViajes == idViaje);

                if (viaje == null)
                    throw new Exception("Viaje no encontrado.");

                return new ModificarViajeDTO
                {
                    IdViaje = viaje.IdViajes,
                    Direccion = viaje.Direccion,
                    Comentario = viaje.Comentario,
                    IdMoviles = viaje.Vueltas.Select(v => v.IdMovil).Distinct().ToList()
                };
            }
        }
        public void Editar(ModificarViajeDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            using (var tran = contexto.Database.BeginTransaction())
            {
                try
                {
                    var viaje = contexto.Viajes
                        .Include(v => v.Vueltas)
                        .FirstOrDefault(v => v.IdViajes == dto.IdViaje);

                    if (viaje == null)
                        throw new Exception("Viaje no encontrado.");

                    // Actualizar campos editables
                    viaje.Direccion = dto.Direccion;
                    viaje.Comentario = dto.Comentario;

                    // Validar móviles
                    var movilesValidos = contexto.Moviles.Select(m => m.IdMovil).ToList();
                    var movilesInvalidos = dto.IdMoviles.Except(movilesValidos).ToList();

                    if (movilesInvalidos.Any())
                        throw new Exception("Los siguientes móviles no existen: " + string.Join(", ", movilesInvalidos));

                    // Eliminar vueltas anteriores
                    contexto.Vueltas.RemoveRange(viaje.Vueltas);

                    // Agregar nuevas vueltas
                    for (int i = 0; i < dto.IdMoviles.Count; i++)
                    {
                        var nuevaVuelta = new Vuelta
                        {
                            IdViaje = viaje.IdViajes,
                            IdMovil = dto.IdMoviles[i],
                            NumeroVuelta = i + 1,
                            VueltaFecha = DateTime.Today,
                            EstadoVuelta = "X"
                        };

                        contexto.Vueltas.Add(nuevaVuelta);
                    }

                    contexto.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    var inner = ex.InnerException;
                    while (inner?.InnerException != null)
                        inner = inner.InnerException;

                    MessageBox.Show("Error interno: " + (inner?.Message ?? ex.Message));
                    throw;
                }
            }
        }

        public void Eliminar(int idViaje)
        {
            using (var contexto = new RemiseriaDbContext())
            using (var tran = contexto.Database.BeginTransaction())
            {
                try
                {
                    var viaje = contexto.Viajes
                        .Include(v => v.Vueltas)
                        .FirstOrDefault(v => v.IdViajes == idViaje);

                    if (viaje == null)
                        throw new Exception("Viaje no encontrado.");

                    // Eliminar vueltas asociadas
                    contexto.Vueltas.RemoveRange(viaje.Vueltas);

                    // Eliminar viaje
                    contexto.Viajes.Remove(viaje);

                    contexto.SaveChanges();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
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
        public DataTable MostrarTodo(DateTime fecha)
        {
            DataTable dt = new DataTable();

            // columnas fijas
            dt.Columns.Add("ID Viaje");
            dt.Columns.Add("N° Viaje");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Dirección");
            dt.Columns.Add("Comentario");

            Dictionary<int, DataRow> filas = new Dictionary<int, DataRow>();

            try
            {
                using (var contexto = new RemiseriaDbContext())
                {
                    var viajes = contexto.Viajes
                        .Include(v => v.Vueltas.Select(vu => vu.Movil))
                        .Where(v => DbFunctions.TruncateTime(v.Vueltas.FirstOrDefault().VueltaFecha) == fecha.Date)
                        .OrderBy(v => v.IdViajes)
                        .ToList();

                    foreach (var viaje in viajes)
                    {
                        DataRow row = dt.NewRow();
                        row["ID Viaje"] = viaje.IdViajes;
                        row["N° Viaje"] = viaje.NumeroViaje;
                        row["Hora"] = viaje.HoraViaje;
                        row["Dirección"] = viaje.Direccion;
                        row["Comentario"] = viaje.Comentario;

                        dt.Rows.Add(row);
                        filas[viaje.IdViajes] = row;

                        foreach (var vuelta in viaje.Vueltas)
                        {
                            string colName = $"Movil {vuelta.Movil.NumeroMovil}";
                            if (!dt.Columns.Contains(colName))
                                dt.Columns.Add(colName);

                            filas[viaje.IdViajes][colName] = viaje.EstadoViaje;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los viajes: " + ex.Message);
            }

            return dt;
        }


        public DataTable MostrarVuelta(DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var vueltas = contexto.Vueltas
                    .Include(v => v.Movil)
                    .Where(v => DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date)
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Vuelta");

                var vueltasAgrupadas = vueltas
                    .GroupBy(v => v.NumeroVuelta)
                    .OrderBy(g => g.Key);

                foreach (var grupo in vueltasAgrupadas)
                {
                    DataRow row = dt.NewRow();
                    row["Vuelta"] = grupo.Key;

                    foreach (var vuelta in grupo)
                    {
                        string colName = $"Movil {vuelta.Movil.NumeroMovil}";
                        if (!dt.Columns.Contains(colName))
                            dt.Columns.Add(colName);

                        row[colName] = vuelta.EstadoVuelta;
                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }
        }
    }
}
