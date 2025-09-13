using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Repositorios
{
    public class PlanillaCostosRepositorio : IPlanillaCostosRepositorio
    {
        private readonly ConexionBD BD = new ConexionBD();

        public IEnumerable<CuadrasImporteModelo> mostrarImporteCuadras()
        {
            var lista = new List<CuadrasImporteModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select cuadras from ImportesCuadras;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CuadrasImporteModelo
                        {
                            Cuadras = Convert.ToInt32(reader["cuadras"])
                        });
                    }
                }
            }
            return lista;
        }

        public IEnumerable<CuadrasMinimoImporteModelo> mostrarImporteMinimoCuadras()
        {
            var lista = new List<CuadrasMinimoImporteModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select minimo from ImportesCuadras;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CuadrasMinimoImporteModelo
                        {
                            Minimo = Convert.ToInt32(reader["minimo"])
                        });
                    }
                }
            }
            return lista;
        }

        public IEnumerable<CuadrasEsperaModelo> mostrarEsperaCuadras() 
        {
            var lista = new List<CuadrasEsperaModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select espera from ImportesCuadras;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CuadrasEsperaModelo
                        {
                            Espera = Convert.ToInt32(reader["espera"])
                        });
                    }
                }
            }
            return lista;
        }

        public IEnumerable<CuadrasMandadoModelo> mostrarMandadoCuadras() 
        {
            var lista = new List<CuadrasMandadoModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select mandado from ImportesCuadras;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CuadrasMandadoModelo
                        {
                            Mandado = Convert.ToInt32(reader["mandado"])
                        });
                    }
                }
            }
            return lista;
        }

        public void modificarImporteCuadras(CuadrasImporteModelo cuadras) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"update ImporteCuadras set cuadras = @cuadras where id_importe_cuadras = 1;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cuadras", cuadras.Cuadras);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void modificarImporteCuadrasMandado(CuadrasMandadoModelo mandado) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"update ImporteCuadras set mandado = @mandado where id_importe_cuadras = 1;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mandado", mandado.Mandado);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void modificarImporteCuadrasEspera(CuadrasEsperaModelo espera) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"update ImporteCuadras set espera = @espera where id_importe_cuadras = 1;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@espera", espera.Espera);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ImporteCiudadModelo> mostrarImporteCiudad()
        {
            var lista = new List<ImporteCiudadModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select kilometro from ImporteCiudad;";

                using (var cmd = new NpgsqlCommand(query,conn))
                using (var reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        lista.Add(new ImporteCiudadModelo
                        {
                            Kilometro = Convert.ToInt32(reader["kilometro"])
                        });
                    }
                }
            }
            return lista;
        }

        public IEnumerable<ImporteCiudadEspera> mostrarEsperaCiudad() 
        {
            var lista = new List<ImporteCiudadEspera>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select espera from ImporteCiudad;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ImporteCiudadEspera
                        {
                            Espera = Convert.ToInt32(reader["espera"])
                        });
                    }
                }
            }
            return lista;
        }

        public void modificarImporteCiudad(ImporteCiudadModelo kilometros) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"update ImporteCiudad set kilometro = @kilometro where id_importe_ciudad = 1;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kilometro", kilometros.Kilometro);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void modificarImporteCIudadEspera(ImporteCiudadEspera espera) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"update ImporteCiudad set espera = @espera where id_importe_ciudad = 1;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@espera", espera.Espera);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<CiudadesModelo> mostrarCiudades() 
        {
            var lista = new List<CiudadesModelo>();
            using (var conn = BD.Abrirconexion())
            {
                string query = "Select id_ciudad,ciudad,importe from Ciudad;";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CiudadesModelo
                        {
                            Id = Convert.ToInt32(reader["id_ciudad"]),
                            Ciudad = reader["ciudad"]?.ToString(),
                            Importe = Convert.ToInt32(reader["espera"])
                        });
                    }
                }
            }
            return lista;
        }

        public void agregarCiudades(CiudadesModelo ciudad) 
        {
            using (var conn = BD.Abrirconexion()) 
            {
                string query = @"insert into ciudad (ciudad,importe) values (@ciudad,@importe);";

                using (var cmd = new NpgsqlCommand(query,conn)) 
                {
                    cmd.Parameters.AddWithValue("@ciudad", ciudad.Ciudad);
                    cmd.Parameters.AddWithValue("@importe", ciudad.Importe);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void editarCiudades(CiudadesModelo ciudades) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"update Ciudad set ciudad = @ciudad, importe = @importe where id_ciudad = @id_ciudad;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_ciudad", ciudades.Id);
                    cmd.Parameters.AddWithValue("@ciudad", ciudades.Ciudad);
                    cmd.Parameters.AddWithValue("@importe", ciudades.Importe);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void eliminarCiudades(int id) 
        {
            using (var conn = BD.Abrirconexion())
            {
                string query = @"delete from Ciudad where id_ciudad = @id_ciudad;";
                using (var cmd = new NpgsqlCommand(query,conn)) 
                {
                    cmd.Parameters.AddWithValue("@id_ciudad", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
