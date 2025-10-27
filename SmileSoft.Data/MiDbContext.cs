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
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
        
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
                //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        public MiDbContext()
        {
            this.Database.EnsureCreated();
            SeedInitialData();
        }

        private void SeedInitialData()
        {
            if (!Usuarios.Any())
            {
                //Usuarios
                var defaultUser = new Usuario("admin", "Admin123", "Admin");
                var defaultSecretario = new Usuario("secretario","secretario123","Secretario");
                Usuarios.Add(defaultUser);
                Usuarios.Add(defaultSecretario);
                //Obras sociales
                var obraSocial1 = new ObraSocial(0,"OSDE");
                var obraSocial2 = new ObraSocial(0,"Swiss Medical");
                ObrasSociales.Add(obraSocial1);
                ObrasSociales.Add(obraSocial2);
                //Odontologos
                //var odontologo1 = new Odontologo(0,"12345","Juan","Perez","Calle Falsa 123",new DateTime(DateTime.Now.Year - 30,1,1), "odontologo1@ejemplo.com", "123456789","123123123");
                //var odontologo2 = new Odontologo(0,"67890","Maria","Gomez","Avenida Siempre Viva 742",new DateTime(DateTime.Now.Year - 28,5,15), "odontologo2@ejemplo.com", "987654321", "123456789");
                //Odontologos.Add(odontologo1)
                //Odontologos.Add(odontologo2);

                SaveChanges();
                
                Console.WriteLine("Default user created:");
                Console.WriteLine("Username: admin");
                Console.WriteLine("Password: Admin123");
            }
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // preguntar si esto va
            modelBuilder.Entity<Persona>().ToTable("Personas");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Odontologo>().ToTable("Odontologos");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.NroDni).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FechaNacimiento).IsRequired();
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.NroAfiliado).HasMaxLength(50);
                entity.Property(e => e.NroHC).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.NroHC).IsUnique();
                entity.HasOne(e => e.Tutor)
                        .WithMany(t => t.PacientesTutelados)
                        .HasForeignKey(e => e.TutorId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict); // no se deja borrar una persona que es tutora de otra
                entity.HasOne(e => e.TipoPlan)
                        .WithMany(tp => tp.Pacientes)
                        .HasForeignKey(e => e.TipoPlanId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.SetNull);
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
                entity.Property(e => e.NroMatricula).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.NroMatricula).IsUnique();
                entity.HasMany(e=> e.Atenciones)
                      .WithOne(a => a.Odontologo)
                      .HasForeignKey(a => a.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Salt).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Rol).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<TipoAtencion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion).HasMaxLength(250);
                entity.Property(e => e.Duracion).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Atencion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FechaHoraAtencion).IsRequired();
                entity.HasOne(e => e.Paciente)
                      .WithMany(p => p.Atenciones)
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Odontologo)
                      .WithMany(o => o.Atenciones)
                      .HasForeignKey(e => e.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.TipoAtencion)
                      .WithMany(ta => ta.Atenciones)
                      .HasForeignKey(e => e.TipoAtencionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


        }
    }
}
