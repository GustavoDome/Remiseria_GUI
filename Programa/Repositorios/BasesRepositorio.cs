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
    public class BasesRepositorio : IBasesRepositorio
    {
        ConexionBD BD = new ConexionBD();

        public void agregar(BasesModelo basesmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Bases(estado_base,fecha_base,id_movil,id_operador,activo) Values
                                (@estado_base,@fecha_base,@id_movil,@id_operador,@activo);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estado_base",basesmodelo.Estado_base);
                    cmd.Parameters.AddWithValue("@fecha_base", basesmodelo.Fecha_base);
                    cmd.Parameters.AddWithValue("@id_movil", basesmodelo.Id_movil);
                    cmd.Parameters.AddWithValue("@id_operador", basesmodelo.Id_operador);
                    cmd.Parameters.AddWithValue("@activo", basesmodelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(BasesModelo basesmodelo) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Bases set estado_base = @estado_base, fecha_base = @fecha_base, id_movil = @id_movil, id_operador = @id_operador WHERE id_base = @id_base;";
                using (var cmd = new NpgsqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@id_base", basesmodelo.Id);
                    cmd.Parameters.AddWithValue("@estado_base", basesmodelo.Estado_base);
                    cmd.Parameters.AddWithValue("@fecha_base", basesmodelo.Fecha_base);
                    cmd.Parameters.AddWithValue("@id_movil", basesmodelo.Id_movil);
                    cmd.Parameters.AddWithValue("@id_operador", basesmodelo.Id_operador);

                    cmd.ExecuteNonQuery();
                }
            }

        }
        public void eliminar(int id) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "UPDATE Bases set activo = FALSE WHERE id_base=@id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<BasesModelo> mostrarTodo() 
        {
            var lista = new List<BasesModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Bases WHERE Activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new BasesModelo
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Estado_base = reader.GetBoolean(reader.GetOrdinal("estado_base")),
                            Fecha_base = reader.GetString(reader.GetOrdinal("fecha_base")),
                            Id_movil = reader.GetInt32(reader.GetOrdinal("id_movil")),
                            Id_operador = reader.GetInt32(reader.GetOrdinal("id_operador"))
                        });
                    }
                }
            }

            return lista;
        }
    }
}
