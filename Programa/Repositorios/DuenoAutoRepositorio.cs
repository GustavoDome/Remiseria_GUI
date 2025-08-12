using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class DuenoAutoRepositorio : IDuenoAutoRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(DuenoAutoModelo duenoAutoModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT INTO Dueño_auto(nombre, apellido, direccion, chofer, telefono, activo)
                                 VALUES (@nombre, @apellido, @direccion, @chofer, @telefono, @activo);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", duenoAutoModelo.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@apellido", duenoAutoModelo.Apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", duenoAutoModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@chofer", duenoAutoModelo.Chofer);
                    cmd.Parameters.AddWithValue("@telefono", duenoAutoModelo.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", duenoAutoModelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(DuenoAutoModelo duenoAutoModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Dueño_auto SET 
                                 nombre = @nombre, 
                                 apellido = @apellido, 
                                 direccion = @direccion, 
                                 chofer = @chofer, 
                                 telefono = @telefono 
                                 WHERE id_dueño = @id_dueño;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_dueño", duenoAutoModelo.Id);
                    cmd.Parameters.AddWithValue("@nombre", duenoAutoModelo.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@apellido", duenoAutoModelo.Apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", duenoAutoModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@chofer", duenoAutoModelo.Chofer);
                    cmd.Parameters.AddWithValue("@telefono", duenoAutoModelo.Telefono ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Dueño_auto SET activo = FALSE WHERE id_dueño = @id;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<DuenoAutoModelo> mostrarTodo()
        {
            var lista = new List<DuenoAutoModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Dueño_auto WHERE activo = TRUE;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DuenoAutoModelo
                        {
                            Id = reader["id_dueño"] != DBNull.Value ? Convert.ToInt32(reader["id_dueño"]) : 0,
                            Nombre = reader["nombre"]?.ToString(),
                            Apellido = reader["apellido"]?.ToString(),
                            Direccion = reader["direccion"]?.ToString(),
                            Telefono = reader["telefono"]?.ToString(),
                            Chofer = reader["chofer"] != DBNull.Value && Convert.ToBoolean(reader["chofer"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
