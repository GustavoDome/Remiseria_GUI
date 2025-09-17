using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class PreguntaRepositorio : IPreguntaRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(PreguntaModelo preguntaModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Pregunta (pregunta, id_categoria) 
                                 VALUES (@pregunta, @id_categoria);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pregunta", preguntaModelo.Pregunta ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_categoria", preguntaModelo.Id_categoria);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(PreguntaModelo preguntaModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE Pregunta SET 
                                 pregunta = @pregunta, 
                                 id_categoria = @id_categoria 
                                 WHERE id_pregunta = @id_pregunta;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pregunta", preguntaModelo.Id_pregunta);
                    cmd.Parameters.AddWithValue("@pregunta", preguntaModelo.Pregunta ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_categoria", preguntaModelo.Id_categoria);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Pregunta WHERE id_pregunta = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<PreguntaModelo> mostrarTodo()
        {
            var lista = new List<PreguntaModelo>();
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Pregunta;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new PreguntaModelo
                        {
                            Id_pregunta = reader["id_pregunta"] != DBNull.Value ? Convert.ToInt32(reader["id_pregunta"]) : 0,
                            Pregunta = reader["pregunta"]?.ToString(),
                            Id_categoria = reader["id_categoria"] != DBNull.Value ? Convert.ToInt32(reader["id_categoria"]) : 0
                        });
                    }
                }
            }

            return lista;
        }
    }
}
