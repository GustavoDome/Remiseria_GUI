using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Programa.Repositorios
{
    public class ViajesRepositorio : IViajesRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(ViajesModelo viaje)
        {
            using (var conn = BD.Abrirconexion())
            using (var tran = conn.BeginTransaction())
            {
                try
                {
                    // 1️⃣ Insertar el viaje principal y obtener su ID generado
                    string queryViaje = @"INSERT INTO Viajes
                                  (hora_viaje, direccion, comentario, tipo_viaje, id_operador) 
                                  VALUES (@hora_viaje, @direccion, @comentario, @tipo_viaje, @id_operador)
                                  RETURNING id_viajes;";

                    int idViaje;
                    using (var cmd = new NpgsqlCommand(queryViaje, conn))
                    {
                        cmd.Parameters.AddWithValue("@hora_viaje", viaje.Hora_viaje);
                        cmd.Parameters.AddWithValue("@direccion", viaje.Direccion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@comentario", viaje.Comentario ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@tipo_viaje", viaje.Tipo_viaje ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_operador", viaje.Id_operador);

                        idViaje = Convert.ToInt32(cmd.ExecuteScalar()); // Obtener el id generado
                    }

                    // 2️⃣ Insertar cada móvil en la tabla intermedia
                    string queryMoviles = @"INSERT INTO Viajes_Moviles (id_viaje, id_movil) VALUES (@id_viaje, @id_movil)";
                    using (var cmd = new NpgsqlCommand(queryMoviles, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_viaje", idViaje);
                        var paramMovil = cmd.Parameters.Add("@id_movil", NpgsqlTypes.NpgsqlDbType.Integer);

                        foreach (var movil in viaje.Id_movil)
                        {
                            paramMovil.Value = movil;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3️⃣ Generar el string concatenado de móviles para mostrar en DataGridView
                    viaje.MovilesConcatenados = string.Join(", ", viaje.Id_movil);

                    // 4️⃣ Commit de la transacción
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw; // relanza la excepción para manejo externo
                }
            }
        }


        public void editar(ViajesModelo viajesModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Viajes 
                                 SET hora_viaje = @hora_viaje, 
                                     direccion = @direccion, 
                                     estado_vuelta = @estado_vuelta, 
                                     vuelta = @vuelta, 
                                     vuelta_fecha = @vuelta_fecha, 
                                     id_movil = @id_movil, 
                                     id_operador = @id_operador 
                                 WHERE id_viajes = @id_viajes;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_viajes", viajesModelo.Id_viajes);
                    cmd.Parameters.AddWithValue("@hora_viaje", viajesModelo.Hora_viaje);
                    cmd.Parameters.AddWithValue("@direccion", viajesModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_movil", viajesModelo.Id_movil);
                    cmd.Parameters.AddWithValue("@id_operador", viajesModelo.Id_operador);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "DELETE FROM Viajes WHERE id_viajes = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<MovilModeloId> seleccionarMovil()
        {
            var lista = new List<MovilModeloId>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT numero_movil FROM Movil where activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovilModeloId
                        {
                            Numero_movil = reader["numero_movil"] != DBNull.Value ? Convert.ToInt32(reader["numero_movil"]) : 0,
                        });
                    }
                }
            }

            return lista;
        }
        public IEnumerable<ViajesModelo> mostrarTodo()
        {
            var listaTemporal = new List<(int id_viajes, TimeSpan hora_viaje, string direccion, string comentario, string tipo_viaje, int id_operador, int numero_movil)>();

            using (var conn = BD.Abrirconexion())
            {
                string query = @"
            SELECT v.id_viajes, v.hora_viaje, v.direccion, v.comentario, v.tipo_viaje, v.id_operador, m.numero_movil
            FROM Viajes v
            JOIN Viajes_Moviles vm ON v.id_viajes = vm.id_viaje
            JOIN Movil m ON vm.id_movil = m.id_movil;
        ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaTemporal.Add((
                            Convert.ToInt32(reader["id_viajes"]),
                            (TimeSpan)reader["hora_viaje"],
                            reader["direccion"]?.ToString(),
                            reader["comentario"]?.ToString(),
                            reader["tipo_viaje"]?.ToString(),
                            Convert.ToInt32(reader["id_operador"]),
                            Convert.ToInt32(reader["numero_movil"])
                        ));
                    }
                }
            }

            // Agrupamos por viaje y convertimos los móviles en un string para mostrar en DataGridView
            var listaFinal = listaTemporal
                .GroupBy(x => x.id_viajes)
                .Select(g => new ViajesModelo
                {
                    Id_viajes = g.Key,
                    Hora_viaje = g.First().hora_viaje,
                    Direccion = g.First().direccion,
                    Comentario = g.First().comentario,
                    Tipo_viaje = g.First().tipo_viaje,
                    Id_operador = g.First().id_operador,
                    // Convertimos la lista de móviles en un string separado por comas
                    Id_movil = g.Select(x => x.numero_movil).ToList(),
                    MovilesConcatenados = string.Join(", ", g.Select(x => x.numero_movil)) // Nueva propiedad para DataGridView
                })
                .ToList();

            return listaFinal;
        }


        public IEnumerable<VueltaModelo> mostrarVuelta() 
        {
            var lista = new List<VueltaModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT estado_vuelta, vuelta, vuelta_fecha FROM Viajes;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new VueltaModelo
                        {
                            Estado_vuelta = reader["estado_vuelta"]?.ToString(),
                            Vuelta = Convert.ToInt32(reader["vuelta"]),
                            Vuelta_fecha = reader["vuelta_fecha"]?.ToString()

                        });
                    }
                }
            }

            return lista;
        }
    }
}
