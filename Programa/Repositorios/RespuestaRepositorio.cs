using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class RespuestaRepositorio : IRespuestasRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(RespuestaModelo respuestaModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Respuesta (respuesta_texto, respuesta_audio_video, id_pregunta) 
                                 VALUES (@respuesta_texto, @respuesta_audio_video, @id_pregunta);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@respuesta_texto", respuestaModelo.Respuesta_texto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@respuesta_audio_video", respuestaModelo.Respuesta_audio_video ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_pregunta", respuestaModelo.Id_pregunta);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(RespuestaModelo respuestaModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE Respuesta SET 
                                 respuesta_texto = @respuesta_texto, 
                                 respuesta_audio_video = @respuesta_audio_video, 
                                 id_pregunta = @id_pregunta 
                                 WHERE id_respuesta = @id_respuesta;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_respuesta", respuestaModelo.Id_respuesta);
                    cmd.Parameters.AddWithValue("@respuesta_texto", respuestaModelo.Respuesta_texto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@respuesta_audio_video", respuestaModelo.Respuesta_audio_video ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_pregunta", respuestaModelo.Id_pregunta);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Respuesta WHERE id_respuesta = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<RespuestaModelo> mostrarTodo()
        {
            var lista = new List<RespuestaModelo>();

            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Respuesta;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Leer el campo byte[] para respuesta_audio_video
                        long length = (long)(reader["respuesta_audio_video"] is DBNull ? 0 : ((byte[])reader["respuesta_audio_video"]).LongLength);
                        byte[] respuestaAudioVideo = length > 0 ? (byte[])reader["respuesta_audio_video"] : null;

                        lista.Add(new RespuestaModelo
                        {
                            Respuesta_texto = reader["respuesta_texto"]?.ToString(),
                            Respuesta_audio_video = respuestaAudioVideo,
                            Id_pregunta = Convert.ToInt32(reader["id_pregunta"]),
                            Id_respuesta = reader["id_respuesta"] != DBNull.Value ? Convert.ToInt32(reader["id_respuesta"]) : 0
                        });
                    }
                }
            }

            return lista;
        }
    }
}
