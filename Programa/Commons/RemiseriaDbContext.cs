using Npgsql;
using Programa.Modelos;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Programa.Conexion
{
    /// <summary>
    /// Contexto principal de Entity Framework para la aplicación Remisería.
    /// Gestiona la conexión a la base de datos y el mapeo de entidades al esquema "public".
    /// </summary>
    public class RemiseriaDbContext : DbContext
    {
        /// <summary>
        /// Constructor por defecto que utiliza la cadena de conexión definida en el archivo de configuración.
        /// </summary>
        public RemiseriaDbContext()
            : base("name=RemiseriaConnection")
        {
        }

        /// <summary>
        /// Constructor que permite inyectar una instancia de <see cref="DbConnection"/>.
        /// Utilizado principalmente por <see cref="DbBootstrapper"/> para inicializar la base de datos.
        /// </summary>
        /// <param name="connection">Conexión a la base de datos.</param>
        /// <param name="contextOwnsConnection">Indica si el contexto debe cerrar la conexión al finalizar.</param>
        public RemiseriaDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Database.SetInitializer<RemiseriaDbContext>(null); // Evita reinicializaciones automáticas
        }

        /// <summary>
        /// Constructor alternativo que acepta una cadena de conexión directa.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos PostgreSQL.</param>
        public RemiseriaDbContext(string connectionString)
            : base(new NpgsqlConnection(connectionString), true)
        {
        }

        // DbSets que representan las tablas del modelo de datos
        public DbSet<DuenoAuto> DuenoAutos { get; set; }
        public DbSet<Movil> Moviles { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Base> Bases { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Vuelta> Vueltas { get; set; }
        public DbSet<Recordatorio> Recordatorios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<ImporteCuadras> ImportesCuadras { get; set; }
        public DbSet<ImporteCiudad> ImportesCiudad { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        /// <summary>
        /// Configura el modelo de datos y las convenciones de mapeo entre entidades y tablas.
        /// Define nombres de tablas, claves primarias y relaciones entre entidades.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de EF.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Evita la pluralización automática de nombres de tablas
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            // Define el esquema por defecto
            modelBuilder.HasDefaultSchema("public");

            // Mapeo explícito de entidades a tablas
            modelBuilder.Entity<DuenoAuto>().ToTable("dueno_auto", "public");

            modelBuilder.Entity<Movil>().ToTable("movil", "public");

            modelBuilder.Entity<Operador>().ToTable("operador", "public");

            modelBuilder.Entity<Base>().ToTable("bases", "public");

            modelBuilder.Entity<Viaje>().ToTable("viajes", "public");

            modelBuilder.Entity<Vuelta>().ToTable("vuelta", "public");

            modelBuilder.Entity<Recordatorio>().ToTable("recordatorio", "public");

            modelBuilder.Entity<ImporteCuadras>().ToTable("importescuadras", "public");

            // Configuración de relaciones y claves
            modelBuilder.Entity<Vuelta>()
                .HasKey(v => v.IdVuelta); // Clave primaria única

            modelBuilder.Entity<Vuelta>()
                .HasRequired(v => v.Viaje)
                .WithMany(v => v.Vueltas)
                .HasForeignKey(v => v.IdViaje)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vuelta>()
                .HasRequired(v => v.Movil)
                .WithMany()
                .HasForeignKey(v => v.IdMovil);

            // Relación opcional con Operador en Recordatorio
            modelBuilder.Entity<Recordatorio>()
                .HasRequired(r => r.Operador)
                .WithMany()
                .HasForeignKey(r => r.IdOperador);

            // Evitar pluralización automática
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}