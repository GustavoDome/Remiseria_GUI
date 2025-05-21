using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Repositorios
{
    public class RespuestaRepositorio : IRespuestasRepositorio
    {
        ConexionBD BD = new ConexionBD();
        public void agregar(RespuestaModelo respuestaModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Respuesta(respuesta_texto,respuesta_audio_video,id_pregunta) Values
                                (@respuesta_texto,@respuesta_audio_video,@id_pregunta);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estado_base", respuestaModelo.Respuesta_texto);
                    cmd.Parameters.AddWithValue("@estado_base", respuestaModelo.Respuesta_audio_video);
                    cmd.Parameters.AddWithValue("@estado_base", respuestaModelo.Id_pregunta);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(RespuestaModelo respuestaModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Respuesta set respuesta_texto = @respuesta_texto, respuesta_audio_video = @respuesta_audio_video, id_pregunta = @id_pregunta WHERE id_respuesta = @id_respuesta;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_respuesta", respuestaModelo.Id_respuesta);
                    cmd.Parameters.AddWithValue("@respuesta_texto", respuestaModelo.Respuesta_texto);
                    cmd.Parameters.AddWithValue("@respuesta_audio_video", respuestaModelo.Respuesta_audio_video);
                    cmd.Parameters.AddWithValue("@id_pregunta", respuestaModelo.Id_pregunta);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "DELETE from Respuesta where id_respuesta = @id;";
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

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Categoria;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long length = reader.GetBytes(reader.GetOrdinal("respuesta_audio_video"), 0, null, 0, 0);  // Manera de Ejecutar: File.WriteAllBytes("archivo_temporal.mp4", respuesta_audio_video); System.Diagnostics.Process.Start("archivo_temporal.mp4");

                        byte[] respuestaAudioVideo = new byte[length];

                        reader.GetBytes(reader.GetOrdinal("respuesta_audio_video"), 0, respuestaAudioVideo, 0, (int)length);

                        lista.Add(new RespuestaModelo
                        {
                            Respuesta_texto = reader.GetString(reader.GetOrdinal("respuesta_texto")),
                            Respuesta_audio_video = respuestaAudioVideo,
                            Id_pregunta = reader.GetInt32(reader.GetOrdinal("id_pregunta")),
                        });
                    }
                }
            }

            return lista;
        }
    }
}
