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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        ConexionBD BD = new ConexionBD();
        public void agregar(CategoriaModelo categoriaModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Categoria(Categoria_pregunta) Values
                                (@Categoria_pregunta);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Categoria_pregunta", categoriaModelo.Categoria_pregunta);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(CategoriaModelo categoriaModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Categoria set Categoria_pregunta = @Categoria_pregunta WHERE id_categoria = @id_categoria;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_categoria", categoriaModelo.Id_categoria);
                    cmd.Parameters.AddWithValue("@Categoria_pregunta", categoriaModelo.Categoria_pregunta);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "DELETE from Categoria where id_categoria = @id;";
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

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Categoria;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CategoriaModelo
                        {
                            Categoria_pregunta = reader.GetString(reader.GetOrdinal("Categoria_pregunta")),
                        });
                    }
                }
            }

            return lista;
        }
    }
}
