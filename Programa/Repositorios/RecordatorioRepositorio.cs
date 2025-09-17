using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class RecordatorioRepositorio : IRecordatorioRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(RecordatorioModelo recordatorioModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Recordatorio (id_viaje, ubicacion, fecha_dia, fecha_hora) 
                                 VALUES (@id_viaje, @ubicacion, @fecha_dia, @fecha_hora);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ubicacion", recordatorioModelo.Ubicacion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha_dia", recordatorioModelo.Fecha_dia ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha_hora", recordatorioModelo.Fecha_hora ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(RecordatorioModelo recordatorioModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE Recordatorio SET 
                                 id_viaje = @id_viaje, 
                                 ubicacion = @ubicacion, 
                                 fecha_dia = @fecha_dia, 
                                 fecha_hora = @fecha_hora 
                                 WHERE id_recordatorio = @id_recordatorio;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_recordatorio", recordatorioModelo.Id_recordatorio);
                    cmd.Parameters.AddWithValue("@ubicacion", recordatorioModelo.Ubicacion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha_dia", recordatorioModelo.Fecha_dia ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha_hora", recordatorioModelo.Fecha_hora ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Recordatorio WHERE id_recordatorio = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<RecordatorioModelo> mostrarTodo()
        {
            var lista = new List<RecordatorioModelo>();

            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Recordatorio;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RecordatorioModelo
                        {
                            Id_recordatorio = reader["id_recordatorio"] != DBNull.Value ? Convert.ToInt32(reader["id_recordatorio"]) : 0,
                            Ubicacion = reader["ubicacion"]?.ToString(),
                            Fecha_dia = reader["fecha_dia"]?.ToString(),
                            Fecha_hora = reader["fecha_hora"]?.ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
