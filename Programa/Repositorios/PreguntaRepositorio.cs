using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Repositorios
{
    public class PreguntaRepositorio : IPreguntaRepositorio
    {
        ConexionBD BD = new ConexionBD();
        public void agregar(PreguntaModelo preguntaModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Pregunta(pregunta,id_categoria) Values
                                (@pregunta,@id_categoria);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pregunta", preguntaModelo.Pregunta);
                    cmd.Parameters.AddWithValue("@id_categoria", preguntaModelo.Id_categoria);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(PreguntaModelo preguntaModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Pregunta set pregunta = @pregunta, id_categoria = @id_categoria WHERE id_pregunta = @id_pregunta;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pregunta", preguntaModelo.Id_pregunta);
                    cmd.Parameters.AddWithValue("@pregunta", preguntaModelo.Pregunta);
                    cmd.Parameters.AddWithValue("@id_categoria", preguntaModelo.Id_categoria);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "DELETE from Pregunta where id_pregunta = @id;";
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

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Categoria;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new PreguntaModelo
                        {
                            Pregunta = reader.GetString(reader.GetOrdinal("pregunta")),
                            Id_categoria = reader.GetInt32(reader.GetOrdinal("id_categoria")),
                        });
                    }
                }
            }

            return lista;
        }
    }
}
