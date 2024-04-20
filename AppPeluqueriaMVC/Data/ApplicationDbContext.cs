using AppPeluqueriaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AppPeluqueriaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion de las relaciones de Citas y Cosmeticos
            modelBuilder.Entity<Cita>()
                        .HasMany(c => c.Cosmeticos)
                        .WithMany(c => c.Citas)
                        .UsingEntity<CitaCosmetico>(
                            j => j
                                .HasOne(cc => cc.Cosmetico)
                                .WithMany(),
                            j => j
                                .HasOne(cc => cc.Cita)
                                .WithMany())
                        .HasKey(cc => new { cc.CitaId, cc.CosmeticoId });

            // Configuracion de Empleado con citas
            modelBuilder.Entity<Empleado>()
                        .HasMany(e => e.Citas)
                        .WithOne(c => c.Empleado)
                        .HasForeignKey(c => c.Id);

            // Configuracion de Empleado
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasIndex(e => e.DNI).IsUnique();
                entity.Property(e => e.DNI).HasColumnType("varchar(10)");
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity.Property(e => e.Apellido).HasColumnType("varchar(30)");
                entity.Property(e => e.Especialidad).HasColumnType("varchar(20)");
                entity.Property(e => e.Sueldo).HasColumnType("decimal(7,2)");
            });
                

            // Configuracion de Cliente con citas
            modelBuilder.Entity<Cliente>()
                        .HasMany(e => e.Citas)
                        .WithOne(c => c.Cliente)
                        .HasForeignKey(c => c.Id);

            // Configuracion de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.DNI).IsUnique();
                entity.Property(e => e.DNI).HasColumnType("varchar(10)");
                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");
                entity.Property(e => e.Apellido).HasColumnType("varchar(30)");
                entity.HasIndex(e => e.Telefono).IsUnique();
                entity.Property(e => e.Telefono).HasColumnType("varchar(20)");
                entity.Property(e => e.Calle).HasColumnType("varchar(20)");
                entity.Property(e => e.NumInt).HasColumnType("varchar(10)");
                entity.Property(e => e.Colonia).HasColumnType("varchar(40)");
                entity.Property(e => e.CodigoPostal).HasColumnType("varchar(10)");
                entity.Property(e => e.Ciudad).HasColumnType("varchar(40)");
                entity.Property(e => e.Pais).HasColumnType("varchar(40)");
                entity.Property(e => e.Tratamientos).HasColumnType("varchar(100)");
            });
        }

        // Modelos
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cliente> Cliente {  get; set; }
        public DbSet<Cosmetico> Cosmetico { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<CitaCosmetico> CitaCosmetico { get; set; }
    }
}
