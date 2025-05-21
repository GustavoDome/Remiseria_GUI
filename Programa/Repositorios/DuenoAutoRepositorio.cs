using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Programa.Modelos;
using Programa.Conexion;
using Npgsql;
using System.Windows.Forms;

namespace Programa.Repositorios
{
    public class DuenoAutoRepositorio : IDuenoAutoRepositorio
    {
        ConexionBD BD = new ConexionBD();
        
        public void agregar(DuenoAutoModelo duenoAutoModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Dueño_auto(nombre,apellido,direccion,chofer,telefono,activo)
                                VALUES (@nombre,@apellido,@direccion,@chofer,@telefono,@activo);";

                using(var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", duenoAutoModelo.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", duenoAutoModelo.Apellido);
                    cmd.Parameters.AddWithValue("@direccion", duenoAutoModelo.Direccion);
                    cmd.Parameters.AddWithValue("@chofer", duenoAutoModelo.Chofer);
                    cmd.Parameters.AddWithValue("@telefono", duenoAutoModelo.Telefono);
                    cmd.Parameters.AddWithValue("@activo", duenoAutoModelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(DuenoAutoModelo duenoAutoModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Dueño_auto set nombre = @nombre, apellido = @apellido, direccion = @direccion, chofer = @chofer, telefono = @telefono WHERE id_dueño = @id_dueño;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_dueño", duenoAutoModelo.Id);
                    cmd.Parameters.AddWithValue("@nombre", duenoAutoModelo.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", duenoAutoModelo.Apellido);
                    cmd.Parameters.AddWithValue("@direccion", duenoAutoModelo.Direccion);
                    cmd.Parameters.AddWithValue("@chofer", duenoAutoModelo.Chofer);
                    cmd.Parameters.AddWithValue("@telefono", duenoAutoModelo.Telefono);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Dueño_auto set activo = FALSE where id_dueño = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<DuenoAutoModelo> mostrarTodo()
        {
            var lista = new List<DuenoAutoModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Dueño_auto WHERE Activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader =  cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DuenoAutoModelo
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                            Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                            Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                            Chofer = reader.GetBoolean(reader.GetOrdinal("chofer"))
                        });
                    }
                }
            }

            return lista;
        }
    }
}
