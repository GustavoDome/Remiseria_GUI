using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Programa.Modelos;

namespace Programa.Conexion
{
    public class RemiseriaDbContext : DbContext
    {
        public RemiseriaDbContext() : base("name=DefaultConnection") { }

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
            modelBuilder.Entity<DuenoAuto>().ToTable("dueno_auto", "public");

            modelBuilder.Entity<Movil>().ToTable("movil", "public");

            modelBuilder.Entity<Operador>().ToTable("operador", "public");

            modelBuilder.Entity<Base>().ToTable("bases", "public");

            modelBuilder.Entity<Viaje>().ToTable("viajes", "public");

            modelBuilder.Entity<Vuelta>().ToTable("vuelta", "public");

            modelBuilder.Entity<Recordatorio>().ToTable("recordatorio", "public");

            // Clave compuesta para Vuelta
            modelBuilder.Entity<Vuelta>()
                .HasKey(v => new { v.IdViaje, v.IdMovil });

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