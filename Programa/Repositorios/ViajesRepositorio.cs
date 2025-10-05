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
                        int idMovil = dto.IdMoviles[i];
                        int numeroVuelta = dto.Vueltas[i];

                        var vueltaPendiente = contexto.Vueltas.FirstOrDefault(v =>
                            v.IdMovil == idMovil &&
                            DbFunctions.TruncateTime(v.VueltaFecha) == dto.VueltaFecha.Date &&
                            v.NumeroVuelta == numeroVuelta &&
                            v.EstadoVuelta == "·");

                        if (vueltaPendiente != null)
                        {
                            vueltaPendiente.EstadoVuelta = dto.EstadoVuelta; // por ejemplo "X"
                            viaje.Vueltas.Add(vueltaPendiente); // EF lo asocia al viaje
                        }
                        else
                        {
                            var nuevaVuelta = new Vuelta
                            {
                                IdMovil = idMovil,
                                NumeroVuelta = numeroVuelta,
                                VueltaFecha = dto.VueltaFecha,
                                EstadoVuelta = dto.EstadoVuelta
                            };

                            viaje.Vueltas.Add(nuevaVuelta);
                        }
                    }

                    foreach (var idVuelta in dto.IdsVueltasActivadas)
                    {
                        var vuelta = contexto.Vueltas.FirstOrDefault(v => v.IdVuelta == idVuelta);
                        if (vuelta != null)
                        {
                            viaje.Vueltas.Add(vuelta); // EF la vincula al viaje
                        }
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
        public void CambiarEstado(int idViaje)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var viaje = contexto.Viajes.FirstOrDefault(v => v.IdViajes == idViaje);
                if (viaje == null)
                    throw new Exception("Viaje no encontrado.");

                // Ciclo de estado: · → L → X → ·
                switch (viaje.EstadoViaje)
                {
                    case "·":
                        viaje.EstadoViaje = "L";
                        break;
                    case "L":
                        viaje.EstadoViaje = "X";
                        break;
                    case "X":
                    default:
                        viaje.EstadoViaje = "·";
                        break;
                }

                contexto.SaveChanges();
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
                    DateTime fechaSinHora = fecha.Date;

                    var viajes = contexto.Viajes
                        .Where(v => v.Vueltas.Any(vu => vu.VueltaFecha.Year == fechaSinHora.Year &&
                                                        vu.VueltaFecha.Month == fechaSinHora.Month &&
                                                        vu.VueltaFecha.Day == fechaSinHora.Day))
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

                        var vueltasDelDia = viaje.Vueltas
                            .Where(vu => vu.VueltaFecha.Date == fecha.Date && vu.Movil != null)
                            .ToList();

                        foreach (var vuelta in vueltasDelDia)
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
                var inner = ex;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                MessageBox.Show("Error al cargar los viajes: " + inner.Message);
            }

            return dt;
        }
        public void AgregarVueltaManual(VueltaDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var yaExiste = contexto.Vueltas.Any(v =>
                    v.IdMovil == dto.IdMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == dto.VueltaFecha.Date &&
                    v.NumeroVuelta == dto.NumeroVuelta);

                if (yaExiste)
                    return; // No duplicar

                var nueva = new Vuelta
                {
                    IdViaje = null,
                    IdMovil = dto.IdMovil,
                    NumeroVuelta = dto.NumeroVuelta,
                    VueltaFecha = dto.VueltaFecha,
                    EstadoVuelta = dto.EstadoVuelta
                };

                contexto.Vueltas.Add(nueva);
                contexto.SaveChanges();
            }
        }
        public bool CambiarEstadoVuelta(int idVuelta)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var vuelta = contexto.Vueltas.FirstOrDefault(v => v.IdVuelta == idVuelta);
                if (vuelta == null)
                    return false;

                switch (vuelta.EstadoVuelta)
                {
                    case "X":
                        vuelta.EstadoVuelta = "S";
                        break;
                    case "S":
                        vuelta.EstadoVuelta = "R";
                        break;
                    case "R":
                        vuelta.EstadoVuelta = "/";
                        break;
                    case "/":
                        vuelta.EstadoVuelta = "X";
                        break;
                    default:
                        vuelta.EstadoVuelta = "X"; // Estado desconocido, reinicia en "X"
                        break;
                }

                contexto.SaveChanges();
                return true;
            }
        }
        public void EliminarVuelta(int idVuelta)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var vuelta = contexto.Vueltas.FirstOrDefault(v => v.IdVuelta == idVuelta);

                if (vuelta == null)
                    throw new Exception("Vuelta no encontrada.");

                contexto.Vueltas.Remove(vuelta);
                contexto.SaveChanges();
            }
        }
        public void EliminarUltimaVueltaDeMovil(int idMovil, DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var ultima = contexto.Vueltas
                    .Where(v => v.IdMovil == idMovil && DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date)
                    .OrderByDescending(v => v.NumeroVuelta)
                    .FirstOrDefault();

                if (ultima == null)
                    throw new Exception("No hay vueltas para ese móvil en esa fecha.");

                contexto.Vueltas.Remove(ultima);
                contexto.SaveChanges();
            }
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
                        string colEstado = $"Movil {vuelta.Movil.NumeroMovil}";
                        string colId = $"IdVuelta {vuelta.Movil.NumeroMovil}";

                        if (!dt.Columns.Contains(colEstado))
                            dt.Columns.Add(colEstado);

                        if (!dt.Columns.Contains(colId))
                            dt.Columns.Add(colId);

                        row[colEstado] = vuelta.EstadoVuelta;
                        row[colId] = vuelta.IdVuelta;

                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }
        }
        public int ObtenerProximoNumeroDeVuelta(int idMovil, DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                // Buscar vuelta pendiente
                var vueltaPendiente = contexto.Vueltas.FirstOrDefault(v =>
                    v.IdMovil == idMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date &&
                    v.EstadoVuelta == "·");

                if (vueltaPendiente != null)
                {
                    // Reutilizar la vuelta pendiente
                    return vueltaPendiente.NumeroVuelta;
                }

                // Si no hay pendiente, continuar desde la última
                var vueltasDelMovil = contexto.Vueltas
                    .Where(v => v.IdMovil == idMovil && DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date)
                    .Select(v => v.NumeroVuelta)
                    .ToList();

                if (vueltasDelMovil.Any())
                {
                    return vueltasDelMovil.Max() + 1;
                }

                // Si el móvil es nuevo, buscar la vuelta menos saturada
                var ocupacionPorVuelta = contexto.Vueltas
                    .Where(v => DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date)
                    .GroupBy(v => v.NumeroVuelta)
                    .Select(g => new { Vuelta = g.Key, Cantidad = g.Count() })
                    .OrderBy(g => g.Cantidad)
                    .ThenBy(g => g.Vuelta)
                    .ToList();

                if (!ocupacionPorVuelta.Any())
                    return 1;

                return ocupacionPorVuelta.First().Vuelta;
            }
        }
        public int CalcularVueltaJustaParaNuevoMovil(DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var vueltasPorMovil = contexto.Vueltas
                    .Where(v => DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date)
                    .GroupBy(v => v.IdMovil)
                    .Select(g => g.Max(v => v.NumeroVuelta))
                    .ToList();

                if (!vueltasPorMovil.Any())
                    return 1;

                // Detectar la vuelta más frecuente entre los móviles
                var frecuencia = vueltasPorMovil
                    .GroupBy(v => v)
                    .OrderByDescending(g => g.Count())
                    .ThenBy(g => g.Key)
                    .First()
                    .Key;

                return frecuencia;
            }
        }
        public bool MovilYaTieneVuelta(int idMovil, DateTime fecha, int numeroVuelta)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Vueltas.Any(v =>
                    v.IdMovil == idMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date &&
                    v.NumeroVuelta == numeroVuelta);
            }
        }
        public bool MovilTieneVueltas(int idMovil, DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Vueltas.Any(v =>
                    v.IdMovil == idMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date);
            }
        }
        public List<MovilResumenDTO> ObtenerMovilesDelDia(DateTime fecha)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Vueltas
                    .Include(v => v.Movil)
                    .Where(v => DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date)
                    .Select(v => new MovilResumenDTO
                    {
                        IdMovil = v.Movil.IdMovil,
                        NumeroMovil = v.Movil.NumeroMovil
                    })
                    .Distinct()
                    .ToList();
            }
        }
        public bool ExisteVueltaConEstado(int idMovil, DateTime fecha, int numeroVuelta, string estado)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Vueltas.Any(v =>
                    v.IdMovil == idMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date &&
                    v.NumeroVuelta == numeroVuelta &&
                    v.EstadoVuelta == estado);
            }
        }
        public void ActivarVueltaPendiente(int idMovil, DateTime fecha, int numeroVuelta)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var vuelta = contexto.Vueltas.FirstOrDefault(v =>
                    v.IdMovil == idMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date &&
                    v.NumeroVuelta == numeroVuelta &&
                    v.EstadoVuelta == "·");

                if (vuelta != null)
                {
                    vuelta.EstadoVuelta = "X";
                    contexto.SaveChanges();
                }
            }
        }
        public int ObtenerIdVuelta(int idMovil, DateTime fecha, int numeroVuelta)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var vuelta = contexto.Vueltas.FirstOrDefault(v =>
                    v.IdMovil == idMovil &&
                    DbFunctions.TruncateTime(v.VueltaFecha) == fecha.Date &&
                    v.NumeroVuelta == numeroVuelta);

                return vuelta?.IdVuelta ?? 0;
            }
        }
    }
}
