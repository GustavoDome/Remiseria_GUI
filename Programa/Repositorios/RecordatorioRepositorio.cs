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
    public class RecordatorioRepositorio : IRecordatorioRepositorio
    {
        ConexionBD BD = new ConexionBD();
        public void agregar(RecordatorioModelo recordatorioModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Recordatorio(id_viaje,ubicacion,fecha_dia,fecha_hora) Values
                                (@id_viaje,@ubicacion,@fecha_dia,@fecha_hora);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_viaje", recordatorioModelo.Id_viaje);
                    cmd.Parameters.AddWithValue("@ubicacion", recordatorioModelo.Ubicacion);
                    cmd.Parameters.AddWithValue("@fecha_dia", recordatorioModelo.Fecha_dia);
                    cmd.Parameters.AddWithValue("@fecha_hora", recordatorioModelo.Fecha_hora);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(RecordatorioModelo recordatorioModelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Recordatorio set id_viaje = @id_viaje, ubicacion = @ubicacion, fecha_dia = @fecha_dia, fecha_hora = @fecha_hora WHERE id_recordatorio = @id_recordatorio;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_recordatorio", recordatorioModelo.Id_recordatorio);
                    cmd.Parameters.AddWithValue("@id_viaje", recordatorioModelo.Id_viaje);
                    cmd.Parameters.AddWithValue("@ubicacion", recordatorioModelo.Ubicacion);
                    cmd.Parameters.AddWithValue("@fecha_dia", recordatorioModelo.Fecha_dia);
                    cmd.Parameters.AddWithValue("@fecha_hora", recordatorioModelo.Fecha_hora);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = "DELETE from Recordatorio where id_respuesta = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<RecordatorioModelo> mostrarTodo()
        {
            var lista = new List<RecordatorioModelo>();

            using (var conn = BD.Abrirconexion())
            {
                string query = "SELECT * FROM Recordatorio;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RecordatorioModelo
                        {
                            Id_viaje = reader.GetInt32(reader.GetOrdinal("id_viaje")),
                            Ubicacion = reader.GetString(reader.GetOrdinal("ubicacion")),
                            Fecha_dia = reader.GetString(reader.GetOrdinal("fecha_dia")),
                            Fecha_hora = reader.GetString(reader.GetOrdinal("fecha_hora")),
                        });
                    }
                }
            }

            return lista;
        }
    }
}
