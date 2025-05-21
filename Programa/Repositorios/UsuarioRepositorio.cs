using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Programa.Modelos;
using Programa.Conexion;
using Npgsql;

namespace Programa.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        ConexionBD BD = new ConexionBD();

        public void agregar(UsuarioModelo usuarioModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT INTO Operador (rolUsuario, nombre, direccion, telefono, tipo_fuente, color_sistema, tamanoFuente, tipoAlarma, activo)
                                 VALUES (@rolUsuario, @nombre, @direccion, @telefono, @tipo_fuente, @color_sistema, @tamanoFuente, @tipoAlarma, @activo);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rolUsuario", usuarioModelo.RolUsuario);
                    cmd.Parameters.AddWithValue("@nombre", usuarioModelo.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", usuarioModelo.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", usuarioModelo.Telefono);
                    cmd.Parameters.AddWithValue("@tipo_fuente", usuarioModelo.Fuente);
                    cmd.Parameters.AddWithValue("@color_sistema", usuarioModelo.TemaSistema);
                    cmd.Parameters.AddWithValue("@tamanoFuente", usuarioModelo.TamanoFuente);
                    cmd.Parameters.AddWithValue("@tipoAlarma", usuarioModelo.TipoAlarma);
                    cmd.Parameters.AddWithValue("@activo", usuarioModelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(UsuarioModelo usuarioModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Operador SET 
                                 rolUsuario=@rolUsuario, nombre=@nombre, direccion=@direccion, telefono=@telefono, tipo_fuente=@tipo_fuente, 
                                 color_sistema=@color_sistema, tamanoFuente=@tamanoFuente, tipoAlarma=@tipoAlarma
                                 WHERE id_operador=@id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioModelo.Id);
                    cmd.Parameters.AddWithValue("@rolUsuario", usuarioModelo.RolUsuario);
                    cmd.Parameters.AddWithValue("@nombre", usuarioModelo.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", usuarioModelo.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", usuarioModelo.Telefono);
                    cmd.Parameters.AddWithValue("@tipo_fuente", usuarioModelo.Fuente);
                    cmd.Parameters.AddWithValue("@color_sistema", usuarioModelo.TemaSistema);
                    cmd.Parameters.AddWithValue("@tamanoFuente", usuarioModelo.TamanoFuente);
                    cmd.Parameters.AddWithValue("@tipoAlarma", usuarioModelo.TipoAlarma);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "UPDATE Operador set activo = FALSE WHERE id_operador=@id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<UsuarioModelo> mostrarTodo()
        {
            var lista = new List<UsuarioModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Operador WHERE Activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new UsuarioModelo
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                            Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                            TipoAlarma = reader.GetString(reader.GetOrdinal("tipoAlarma"))
                        });
                    }
                }
            }

            return lista;
        }
    }
}
