using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Conexion
{
    public class ConexionBD
    {
        private readonly string connectionString;
        public ConexionBD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        public NpgsqlConnection ObtenerConexion()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
