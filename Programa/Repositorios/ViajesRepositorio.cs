using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class ViajesRepositorio : IViajesRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(ViajesModelo viajesModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT INTO Viajes
                                 (hora_viaje, direccion, estado_vuelta, vuelta, vuelta_fecha, id_movil, id_operador) 
                                 VALUES
                                 (@hora_viaje, @direccion, @estado_vuelta, @vuelta, @vuelta_fecha, @id_movil, @id_operador);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hora_viaje", viajesModelo.Hora_viaje ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", viajesModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado_vuelta", viajesModelo.Estado_vuelta);
                    cmd.Parameters.AddWithValue("@vuelta", viajesModelo.Vuelta);
                    cmd.Parameters.AddWithValue("@vuelta_fecha", viajesModelo.Vuelta_fecha ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_movil", viajesModelo.Id_movil);
                    cmd.Parameters.AddWithValue("@id_operador", viajesModelo.Id_operador);

                    cmd.ExecuteNonQuery();
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
                    cmd.Parameters.AddWithValue("@hora_viaje", viajesModelo.Hora_viaje ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", viajesModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado_vuelta", viajesModelo.Estado_vuelta);
                    cmd.Parameters.AddWithValue("@vuelta", viajesModelo.Vuelta);
                    cmd.Parameters.AddWithValue("@vuelta_fecha", viajesModelo.Vuelta_fecha ?? (object)DBNull.Value);
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

        public IEnumerable<ViajesModelo> mostrarTodo()
        {
            var lista = new List<ViajesModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Viajes;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ViajesModelo
                        {
                            Id_viajes = Convert.ToInt32(reader["id_viajes"]),
                            Hora_viaje = reader["hora_viaje"]?.ToString(),
                            Direccion = reader["direccion"]?.ToString(),
                            Estado_vuelta = Convert.ToInt32(reader["estado_vuelta"]),
                            Vuelta = Convert.ToInt32(reader["vuelta"]),
                            Vuelta_fecha = reader["vuelta_fecha"]?.ToString(),
                            Id_movil = Convert.ToInt32(reader["id_movil"]),
                            Id_operador = Convert.ToInt32(reader["id_operador"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
