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
    public class ViajesRepositorio : IViajesRepositorio
    {
        ConexionBD BD = new ConexionBD();
        public void agregar(ViajesModelo viajesModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Viajes(hora_viaje,direccion,estado_vuelta,vuelta,vuelta_fecha,id_movil,id_operador) Values
                                (@hora_viaje,@direccion,@estado_vuelta,@vuelta,@vuelta_fecha,@id_movil,@id_operador);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hora_viaje", viajesModelo.Hora_viaje);
                    cmd.Parameters.AddWithValue("@direccion", viajesModelo.Direccion);
                    cmd.Parameters.AddWithValue("@estado_vuelta", viajesModelo.Estado_vuelta);
                    cmd.Parameters.AddWithValue("@vuelta", viajesModelo.Vuelta);
                    cmd.Parameters.AddWithValue("@vuelta_fecha", viajesModelo.Vuelta_fecha);
                    cmd.Parameters.AddWithValue("@id_movil", viajesModelo.Id_movil);
                    cmd.Parameters.AddWithValue("@id_operador", viajesModelo.Id_operador);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(ViajesModelo viajesModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Viajes set hora_viaje = @hora_viaje, direccion = @direccion, estado_vuelta = @estado_vuelta, vuelta = @vuelta, vuelta_fecha = @vuelta_fecha, id_movil = @id_movil, id_operador = @id_operador WHERE id_viajes = @id_viajes;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_viajes", viajesModelo.Id_viajes);
                    cmd.Parameters.AddWithValue("@hora_viaje", viajesModelo.Hora_viaje);
                    cmd.Parameters.AddWithValue("@direccion", viajesModelo.Direccion);
                    cmd.Parameters.AddWithValue("@estado_vuelta", viajesModelo.Estado_vuelta);
                    cmd.Parameters.AddWithValue("@vuelta", viajesModelo.Vuelta);
                    cmd.Parameters.AddWithValue("@vuelta_fecha", viajesModelo.Vuelta_fecha);
                    cmd.Parameters.AddWithValue("@id_movil", viajesModelo.Id_movil);
                    cmd.Parameters.AddWithValue("@id_operador", viajesModelo.Id_operador);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "DELETE from Viajes where id_viajes = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ViajesModelo> mostrarTodo()
        {
            var lista = new List<ViajesModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Viajes;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ViajesModelo
                        {
                            Id_viajes = reader.GetInt32(reader.GetOrdinal("id")),
                            Hora_viaje = reader.GetString(reader.GetOrdinal("hora_viaje")),
                            Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                            Estado_vuelta = reader.GetInt32(reader.GetOrdinal("estado_vuelta")),
                            Vuelta = reader.GetInt32(reader.GetOrdinal("vuelta")),
                            Vuelta_fecha = reader.GetString(reader.GetOrdinal("vuelta_fecha")),
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
