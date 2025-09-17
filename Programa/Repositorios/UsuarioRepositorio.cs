using System;
using System.Collections.Generic;
using System.Configuration;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Conexion;
using Npgsql;

namespace Programa.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(UsuarioModelo usuarioModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Operador 
                                 (rolUsuario, nombre, contrasena, direccion, telefono, tipo_fuente, color_sistema, tamanoFuente, tipoAlarma, activo)
                                 VALUES 
                                 (@rolUsuario, @nombre, @contrasena, @direccion, @telefono, @tipo_fuente, @color_sistema, @tamanoFuente, @tipoAlarma, @activo);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rolUsuario", usuarioModelo.RolUsuario ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@nombre", usuarioModelo.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@contrasena", usuarioModelo.Contrasena ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", usuarioModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", usuarioModelo.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipo_fuente", usuarioModelo.Fuente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@color_sistema", usuarioModelo.TemaSistema ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tamanoFuente", usuarioModelo.TamanoFuente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoAlarma", usuarioModelo.TipoAlarma ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", usuarioModelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(UsuarioModelo usuarioModelo)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE Operador SET 
                                 rolUsuario=@rolUsuario, nombre=@nombre, contrasena=@contrasena, direccion=@direccion, 
                                 telefono=@telefono, tipo_fuente=@tipo_fuente, color_sistema=@color_sistema, 
                                 tamanoFuente=@tamanoFuente, tipoAlarma=@tipoAlarma
                                 WHERE id_operador=@id;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioModelo.Id);
                    cmd.Parameters.AddWithValue("@rolUsuario", usuarioModelo.RolUsuario ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@nombre", usuarioModelo.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@contrasena", usuarioModelo.Contrasena ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", usuarioModelo.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", usuarioModelo.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipo_fuente", usuarioModelo.Fuente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@color_sistema", usuarioModelo.TemaSistema ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tamanoFuente", usuarioModelo.TamanoFuente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoAlarma", usuarioModelo.TipoAlarma ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Operador SET activo = FALSE WHERE id_operador=@id;";
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

            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Operador WHERE Activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new UsuarioModelo
                        {
                            Id = Convert.ToInt32(reader["id_operador"]),
                            RolUsuario = reader["rolUsuario"]?.ToString(),
                            Nombre = reader["nombre"]?.ToString(),
                            Contrasena = reader["contrasena"]?.ToString(),
                            Direccion = reader["direccion"]?.ToString(),
                            Telefono = reader["telefono"]?.ToString(),
                            Fuente = reader["tipo_fuente"]?.ToString(),
                            TemaSistema = reader["color_sistema"]?.ToString(),
                            TamanoFuente = reader["tamanoFuente"]?.ToString(),
                            TipoAlarma = reader["tipoAlarma"]?.ToString(),
                            Activo = Convert.ToBoolean(reader["activo"])
                        });
                    }
                }
            }

            return lista;
        }

        public UsuarioModelo LoginUsuario(string nombre, string contrasena)
        {
            using (var conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Operador WHERE nombre=@nombre AND contrasena=@contrasena AND activo=TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UsuarioModelo
                            {
                                Id = Convert.ToInt32(reader["id_operador"]),
                                Nombre = reader["nombre"]?.ToString(),
                                RolUsuario = reader["rolUsuario"]?.ToString(),
                                Contrasena = reader["contrasena"]?.ToString(),
                                Direccion = reader["direccion"]?.ToString(),
                                Telefono = reader["telefono"]?.ToString(),
                                Fuente = reader["tipo_fuente"]?.ToString(),
                                TemaSistema = reader["color_sistema"]?.ToString(),
                                TamanoFuente = reader["tamanoFuente"]?.ToString(),
                                TipoAlarma = reader["tipoAlarma"]?.ToString(),
                                Activo = Convert.ToBoolean(reader["activo"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
