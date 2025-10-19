using Npgsql;
using Programa.Conexion;
using Programa.Modelos;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Programa
{
    public static class DbBootstrapper
    {
        public static bool InitializeDatabase()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RemiseriaConnection"].ConnectionString;
                var builder = new NpgsqlConnectionStringBuilder(connectionString);

                string dbName = builder.Database;
                builder.Database = "postgres"; // Conectamos a la BD base del sistema
                string adminConnectionString = builder.ConnectionString;

                bool dbCreated = false;

                using (var adminConnection = new NpgsqlConnection(adminConnectionString))
                {
                    adminConnection.Open();

                    using (var cmd = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{dbName}'", adminConnection))
                    {
                        var exists = cmd.ExecuteScalar();
                        if (exists == null)
                        {
                            using (var createCmd = new NpgsqlCommand($"CREATE DATABASE \"{dbName}\" WITH OWNER = '{builder.Username}' ENCODING = 'UTF8'", adminConnection))
                            {
                                createCmd.ExecuteNonQuery();
                                dbCreated = true;
                            }
                        }
                    }
                }

                // 2) Conectarse a la BD recién creada o existente
                using (var context = new RemiseriaDbContext(connectionString))
                {
                    // Crear esquema si no existe (solo por seguridad)
                    context.Database.ExecuteSqlCommand("CREATE SCHEMA IF NOT EXISTS public;");

                    // Crear las tablas si no existen
                    context.Database.ExecuteSqlCommand(@"
                    CREATE TABLE IF NOT EXISTS public.dueno_auto (
                        id_dueno SERIAL PRIMARY KEY,
                        nombre VARCHAR(50),
                        apellido VARCHAR(50),
                        direccion VARCHAR(70),
                        chofer BOOLEAN,
                        telefono VARCHAR(50),
                        activo BOOLEAN
                    );

                    CREATE TABLE IF NOT EXISTS public.movil (
                        id_movil SERIAL PRIMARY KEY,
                        numero_movil integer,
                        marca_auto varchar(25),
                        modelo_auto varchar(25),
                        ano_auto varchar(25),
                        color_auto varchar(25),
                        id_dueno INTEGER REFERENCES public.dueno_auto(id_dueno),
                        activo BOOLEAN
                    );

                    CREATE TABLE IF NOT EXISTS public.operador (
                        id_operador SERIAL PRIMARY KEY,
                        rolUsuario VARCHAR(50),
                        nombre VARCHAR(50),
                        contrasena VARCHAR(50),
                        direccion VARCHAR(50),
                        telefono VARCHAR(50),
                        tipo_fuente VARCHAR(50),
                        color_sistema VARCHAR(50),
                        tamanoFuente integer,
                        tipoAlarma VARCHAR(50),
                        activo BOOLEAN
                    );

                    CREATE TABLE IF NOT EXISTS public.bases (
                        id_base SERIAL PRIMARY KEY,
                        estado_base BOOLEAN,
                        fecha_base TIMESTAMP,
                        comentario varchar(100),
                        id_movil INTEGER REFERENCES public.movil(id_movil),
                        id_operador INTEGER REFERENCES public.operador(id_operador),
                        activo BOOLEAN
                    );

                    CREATE TABLE IF NOT EXISTS public.viajes (
                        id_viajes SERIAL PRIMARY KEY,
                        hora_viaje TIME,
                        direccion varchar(50),
                        id_operador INTEGER REFERENCES public.operador(id_operador),
                        numero_viaje Integer,
                        estado_viaje varchar(100),
                        comentario varchar(100)
                    );

                    CREATE TABLE IF NOT EXISTS public.vuelta (
                        id_vuelta SERIAL PRIMARY KEY,
                        id_viaje INTEGER REFERENCES public.viajes(id_viajes) ON DELETE CASCADE,
                        id_movil INTEGER REFERENCES public.movil(id_movil) ON DELETE CASCADE,
                        vuelta integer,
                        vuelta_fecha date,
                        estado_vuelta varchar(2)
                    );

                    CREATE TABLE IF NOT EXISTS public.categoria (
                        id_categoria SERIAL PRIMARY KEY,
                        categoria_pregunta VARCHAR(50)
                    );

                    CREATE TABLE IF NOT EXISTS public.pregunta (
                        id_pregunta SERIAL PRIMARY KEY,
                        pregunta VARCHAR(100),
                        id_categoria INTEGER REFERENCES public.categoria(id_categoria)
                    );

                    CREATE TABLE IF NOT EXISTS public.respuesta (
                        id_respuesta SERIAL PRIMARY KEY,
                        respuesta_texto VARCHAR(100),
                        respuesta_audio_video BYTEA,
                        id_pregunta INTEGER REFERENCES public.pregunta(id_pregunta)
                    );

                    CREATE TABLE IF NOT EXISTS public.recordatorio (
                        id_recordatorio SERIAL PRIMARY KEY,
                        id_operador integer REFERENCES public.operador(id_operador),
                        ubicacion varchar(50),
                        fecha_dia TIMESTAMP NOT NULL,
                        fecha_hora TIMESTAMP NOT NULL,
                        comentario varchar(100)
                    );

                    CREATE TABLE IF NOT EXISTS public.importescuadras (
                        id_importe_cuadra serial primary key,
                        minimo int not null,
                        cuadras int not null,
                        mandado int not null,
                        espera int not null
                    );

                    CREATE TABLE IF NOT EXISTS public.importeciudad (
                        id_importe_ciudad serial primary key,
                        kilometro int not null,
                        espera int not null
                    );

                    CREATE TABLE IF NOT EXISTS public.ciudad (
                        id_ciudad serial primary key,
                        ciudad varchar(250),
                        importe int not null
                    );

                    CREATE INDEX IF NOT EXISTS idx_vuelta_viaje_movil ON public.vuelta(id_viaje, id_movil);
                    ");

                    // 3) Insertar datos iniciales mínimos
                    if (!context.Operadores.Any(o => o.Nombre == "admin"))
                    {
                        var admin = new Operador
                        {
                            RolUsuario = "Gerente",
                            Nombre = "admin",
                            Contrasena = "123",
                            Direccion = "Sin dirección",
                            Telefono = "00000000",
                            Fuente = "Calibri",
                            TemaSistema = "claro",
                            TamanoFuente = 11,
                            TipoAlarma = "reloj",
                            Activo = true
                        };
                        context.Operadores.Add(admin);
                    }

                    if (!context.ImportesCuadras.Any())
                    {
                        var imp = new ImporteCuadras
                        {
                            Minimo = 100,
                            Cuadras = 5,
                            Mandado = 50,
                            Espera = 20
                        };
                        context.ImportesCuadras.Add(imp);
                    }

                    context.SaveChanges();
                }

                return dbCreated;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la BD: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
