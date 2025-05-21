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
using System.Security.Cryptography.X509Certificates;

namespace Programa.Repositorios
{
    public class MovilRepositorio : IMovilRepositorio
    {
        ConexionBD BD = new ConexionBD();

        public void agregar(MovilModelo movilmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"INSERT into Movil(numero_movil,marca_auto,modelo_auto,año_auto,color_auto,id_dueño,activo)
                                VALUES (@numero_movil,@marca_auto,@modelo_auto,@año_auto,@color_auto,@id_dueño,@activo);";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numero_movil", movilmodelo.Numero_movil);
                    cmd.Parameters.AddWithValue("@marca_auto", movilmodelo.Marca_auto);
                    cmd.Parameters.AddWithValue("@modelo_auto", movilmodelo.Modelo_auto);
                    cmd.Parameters.AddWithValue("@año_auto", movilmodelo.Ano_auto);
                    cmd.Parameters.AddWithValue("@color_auto", movilmodelo.Color_auto);
                    cmd.Parameters.AddWithValue("@id_dueño", movilmodelo.Id_dueno_auto);
                    cmd.Parameters.AddWithValue("@activo", movilmodelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editar(MovilModelo movilmodelo)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Movil set numero_movil = @numero_movil, marca_auto = @marca_auto, modelo_auto = @modelo_auto, año_auto = @año_auto, color_auto = @color_auto, id_dueño = @id_dueño, activo = @activo where id_movil = @id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", movilmodelo.Id_movil);
                    cmd.Parameters.AddWithValue("@numero_movil", movilmodelo.Numero_movil);
                    cmd.Parameters.AddWithValue("@marca_auto", movilmodelo.Marca_auto);
                    cmd.Parameters.AddWithValue("@modelo_auto", movilmodelo.Modelo_auto);
                    cmd.Parameters.AddWithValue("@año_auto", movilmodelo.Ano_auto);
                    cmd.Parameters.AddWithValue("@color_auto", movilmodelo.Color_auto);
                    cmd.Parameters.AddWithValue("@id_dueño", movilmodelo.Id_dueno_auto);
                    cmd.Parameters.AddWithValue("@activo", movilmodelo.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminar(int id)
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"UPDATE Movil set activo = FALSE where id_movil = @id;";
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
                string query = "SELECT * FROM Movil WHERE Activo = TRUE;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovilModelo
                        {
                            Id_movil = reader.GetInt32(reader.GetOrdinal("id")),
                            Numero_movil = reader.GetInt32(reader.GetOrdinal("numero_movil")),
                            Marca_auto = reader.GetString(reader.GetOrdinal("marca_auto")),
                            Modelo_auto = reader.GetString(reader.GetOrdinal("modelo_auto")),
                            Ano_auto = reader.GetString(reader.GetOrdinal("año_auto")),
                            Color_auto = reader.GetString(reader.GetOrdinal("color_auto")),
                            Id_dueno_auto = reader.GetInt32(reader.GetOrdinal("id_dueño"))
                        });
                    }
                }
            }

            return lista;
        }
    }
}
