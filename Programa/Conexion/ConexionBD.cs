using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;

namespace Programa.Conexion
{
    public class ConexionBD
    {
        private readonly string connectionString;
        public ConexionBD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        public NpgsqlConnection Abrirconexion ()
        {
            var conexion = new NpgsqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }

        public void CerrarConexion(NpgsqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
