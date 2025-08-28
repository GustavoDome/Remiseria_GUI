using Npgsql;
using Programa.Conexion;
using Programa.Modelos.Interfaces;
using Programa.Modelos;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class BasesRepositorio : IBasesRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(BasesModelo basesmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT INTO Bases(estado_base, fecha_base, id_movil, id_operador, activo) 
                                 VALUES (@estado_base, @fecha_base, @id_movil, @id_operador, @activo);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estado_base", basesmodelo.Estado_base);
                    cmd.Parameters.AddWithValue("@fecha_base", basesmodelo.Fecha_base ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(BasesModelo basesmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Bases SET estado_base = @estado_base, fecha_base = @fecha_base, id_movil = @id_movil, id_operador = @id_operador 
                                 WHERE id_base = @id_base;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estado_base", basesmodelo.Estado_base);
                    cmd.Parameters.AddWithValue("@fecha_base", basesmodelo.Fecha_base ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "UPDATE Bases SET activo = FALSE WHERE id_base = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<MovilModeloId> seleccionarMovil() 
        {
            var lista = new List<MovilModeloId>();

            using (var conn = BD.Abrirconexion()) 
            {
                string query = "SELECT id_movil FROM Movil where activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovilModeloId
                        {
                            Id_movil = reader["id_movil"] != DBNull.Value ? Convert.ToInt32(reader["id_movil"]) : 0,
                        });
                    }
                }
            }

            return lista;
        }

        public IEnumerable<BasesModelo> mostrarTodo(int id_movil)
        {
            var lista = new List<BasesModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = @"select estado_base, fecha_base from Bases where activo = true and id_movil = @id_movil;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    cmd.Parameters.AddWithValue("@id_movil", id_movil.ToString());
                    while (reader.Read())
                    {
                        lista.Add(new BasesModelo
                        {
                            Estado_base = reader["estado_base"] != DBNull.Value ? Convert.ToBoolean(reader["estado_base"]) : false,
                            Fecha_base = reader["fecha_base"] != DBNull.Value ? reader["fecha_base"].ToString() : string.Empty,
                        });
                    }
                }
            }

            return lista;
        }
    }
}
