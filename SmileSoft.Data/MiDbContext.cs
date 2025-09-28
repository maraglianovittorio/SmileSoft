using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmileSoft.Dominio;

namespace SmileSoft.Data
{
    public class MiDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<ObraSocial> ObrasSociales { get; set; }        
        public DbSet<TipoPlan> TipoPlanes { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoAtencion> TipoAtenciones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        
        public MiDbContext()
        {
            this.Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.NroDni).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FechaNacimiento).IsRequired();
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.NroAfiliado).HasMaxLength(50);
                entity.Property(e => e.NroHC).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.NroHC).IsUnique();
            });
            
            modelBuilder.Entity<ObraSocial>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.HasMany(e => e.TipoPlanes)
                      .WithOne(tp => tp.ObraSocial)
                      .HasForeignKey(tp => tp.ObraSocialId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<TipoPlan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(250);
                entity.HasOne(e => e.ObraSocial)
                      .WithMany(os => os.TipoPlanes)
                      .HasForeignKey(e => e.ObraSocialId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Odontologo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.NroMatricula).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.NroMatricula).IsUnique();
                entity.Property(e => e.Email).HasMaxLength(100);
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rol).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<TipoAtencion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion).HasMaxLength(250);
                entity.Property(e => e.Duracion).IsRequired().HasMaxLength(100);
            });
        }
    }
}
