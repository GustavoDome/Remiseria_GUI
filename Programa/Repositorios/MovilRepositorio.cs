using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;

namespace Programa.Repositorios
{
    public class MovilRepositorio : IMovilRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public void agregar(MovilModelo movilmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT INTO Movil(numero_movil, marca_auto, modelo_auto, año_auto, color_auto, id_dueño, activo)
                                 VALUES (@numero_movil, @marca_auto, @modelo_auto, @año_auto, @color_auto, @id_dueño, @activo);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numero_movil", movilmodelo.Numero_movil);
                    cmd.Parameters.AddWithValue("@marca_auto", movilmodelo.Marca_auto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@modelo_auto", movilmodelo.Modelo_auto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@año_auto", movilmodelo.Ano_auto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@color_auto", movilmodelo.Color_auto ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(MovilModelo movilmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Movil SET 
                                 numero_movil = @numero_movil, 
                                 marca_auto = @marca_auto, 
                                 modelo_auto = @modelo_auto, 
                                 año_auto = @año_auto, 
                                 color_auto = @color_auto, 
                                 id_dueño = @id_dueño, 
                                 activo = @activo 
                                 WHERE id_movil = @id;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numero_movil", movilmodelo.Numero_movil);
                    cmd.Parameters.AddWithValue("@marca_auto", movilmodelo.Marca_auto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@modelo_auto", movilmodelo.Modelo_auto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@año_auto", movilmodelo.Ano_auto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@color_auto", movilmodelo.Color_auto ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Movil SET activo = FALSE WHERE id_movil = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<MovilModelo> mostrarTodo()
        {
            var lista = new List<MovilModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT numero_movil,marca_auto,modelo_auto,ano_auto FROM Movil WHERE Activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovilModelo
                        {
                            Numero_movil = Convert.ToInt32(reader["numero_movil"]),
                            Marca_auto = reader["marca_auto"]?.ToString(),
                            Modelo_auto = reader["modelo_auto"]?.ToString(),
                            Ano_auto = reader["ano_auto"]?.ToString(),
                            Color_auto = reader["color_auto"]?.ToString(),
                        });
                    }
                }
            }

            return lista;
        }
    }
}
