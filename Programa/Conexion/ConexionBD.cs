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

        public NpgsqlConnection Abrirconexion ()
        {
            var conexion = new NpgsqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            try 
            {
                var conexion = new NpgsqlConnection(connectionString);
                conexion.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"No se pudo cerrar la Base de Datos, Error: {ex.Message}");
            }
        }
    }
}
