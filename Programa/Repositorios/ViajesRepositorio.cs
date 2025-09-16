using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Programa.Repositorios
{
    public class ViajesRepositorio : IViajesRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(agregarViajeModelo viaje)
        {
            int idViaje;
            using (var conn = BD.Abrirconexion())
            using (var tran = conn.BeginTransaction())
            {
                try
                {
                    // 1️⃣ Insertar el viaje principal y obtener su ID generado
                    string queryViaje = @"INSERT INTO Viajes
                                  (hora_viaje, direccion, estado_vuelta, vuelta_fecha, id_operador, estado_viaje, comentario) 
                                  VALUES (@hora_viaje, @direccion, @estado_vuelta, @vuelta_fecha, @id_operador, @estado_viaje, @comentario)
                                  RETURNING id_viajes;";

                    using (var cmd = new NpgsqlCommand(queryViaje, conn))
                    {
                        cmd.Parameters.AddWithValue("@hora_viaje", NpgsqlTypes.NpgsqlDbType.Time, viaje.Hora_viaje);
                        cmd.Parameters.AddWithValue("@direccion", viaje.Direccion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@estado_vuelta", viaje.Estado_vuelta);
                        cmd.Parameters.AddWithValue("@vuelta_fecha", viaje.Vuelta_fecha);
                        cmd.Parameters.AddWithValue("@id_operador", viaje.Id_operador);
                        cmd.Parameters.AddWithValue("@estado_viaje", viaje.Estado_viaje ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@comentario", viaje.Comentario);

                        idViaje = Convert.ToInt32(cmd.ExecuteScalar());
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
                finally 
                {
                    BD.CerrarConexion();
                }
            }
        }


        public void editar(agregarViajeModelo viajesModelo)
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
                    cmd.Parameters.AddWithValue("@id_viajes", viajesModelo.Id_operador);
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
            BD.CerrarConexion();

            return lista;
        }
        public DataTable mostrarTodo()
        {
            DataTable dt = new DataTable();

            // columnas fijas
            dt.Columns.Add("ID Viaje");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Dirección");
            dt.Columns.Add("Comentario");

            // diccionario para no repetir filas
            Dictionary<int, DataRow> filas = new Dictionary<int, DataRow>();

            try
            {
                using (var conn = BD.Abrirconexion())
                {
                    string query = @"
                    SELECT v.id_viajes,
                           v.hora_viaje,
                           v.direccion,
                           v.comentario,
                           v.estado_viaje,
                           m.numero_movil
                    FROM Viajes v
                    JOIN Viajes_Moviles vm ON v.id_viajes = vm.id_viaje
                    JOIN Movil m ON vm.id_movil = m.id_movil
                    ORDER BY v.id_viajes, m.numero_movil;
                ";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idViaje = Convert.ToInt32(reader["id_viajes"]);
                            int movil = Convert.ToInt32(reader["numero_movil"]);
                            string estado = reader["estado_viaje"]?.ToString();

                            // si el viaje aún no existe, creo la fila
                            if (!filas.ContainsKey(idViaje))
                            {
                                DataRow row = dt.NewRow();
                                row["ID Viaje"] = idViaje;
                                row["Hora"] = reader["hora_viaje"];
                                row["Dirección"] = reader["direccion"];
                                row["Comentario"] = reader["comentario"];

                                filas[idViaje] = row;
                                dt.Rows.Add(row);
                            }

                            // nombre dinámico de la columna para cada móvil
                            string colName = $"Movil {movil}";
                            if (!dt.Columns.Contains(colName))
                                dt.Columns.Add(colName);

                            filas[idViaje][colName] = estado;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los viajes: " + ex.Message);
            }
            finally
            {
                BD.CerrarConexion();
            }

            return dt;
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
