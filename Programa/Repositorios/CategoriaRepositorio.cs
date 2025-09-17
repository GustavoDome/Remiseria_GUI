using Npgsql;
using Programa.Conexion;
using Programa.Modelos.Interfaces;
using Programa.Modelos;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(CategoriaModelo categoriaModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Categoria(Categoria_pregunta) VALUES (@Categoria_pregunta);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Categoria_pregunta", categoriaModelo.Categoria_pregunta ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(CategoriaModelo categoriaModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE Categoria SET Categoria_pregunta = @Categoria_pregunta WHERE id_categoria = @id_categoria;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_categoria", categoriaModelo.Id_categoria);
                    cmd.Parameters.AddWithValue("@Categoria_pregunta", categoriaModelo.Categoria_pregunta ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Categoria WHERE id_categoria = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<CategoriaModelo> mostrarTodo()
        {
            var lista = new List<CategoriaModelo>();

            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Categoria;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CategoriaModelo
                        {
                            Categoria_pregunta = reader["Categoria_pregunta"] != DBNull.Value ? reader["Categoria_pregunta"].ToString() : string.Empty
                        });
                    }
                }
            }

            return lista;
        }
    }
}
