using Npgsql;
using Programa.Modelos;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Programa.Conexion
{
    public class RemiseriaDbContext : DbContext
    {
        public RemiseriaDbContext()
            : base("name=RemiseriaConnection")
        {
        }

        // Constructor para pasar una DbConnection (usado por DbBootstrapper)
        public RemiseriaDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Database.SetInitializer<RemiseriaDbContext>(null); // Evita reinicializaciones automáticas
        }

        // Opcional: constructor que acepta connection string directa
        public RemiseriaDbContext(string connectionString)
            : base(new NpgsqlConnection(connectionString), true)
        {
        }

        // DbSets
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<DuenoAuto>().ToTable("dueno_auto", "public");

            modelBuilder.Entity<Movil>().ToTable("movil", "public");

            modelBuilder.Entity<Operador>().ToTable("operador", "public");

            modelBuilder.Entity<Base>().ToTable("bases", "public");

            modelBuilder.Entity<Viaje>().ToTable("viajes", "public");

            modelBuilder.Entity<Vuelta>().ToTable("vuelta", "public");

            modelBuilder.Entity<Recordatorio>().ToTable("recordatorio", "public");

            modelBuilder.Entity<ImporteCuadras>().ToTable("importescuadras", "public");

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