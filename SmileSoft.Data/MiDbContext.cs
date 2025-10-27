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
                var defaultSecretario = new Usuario("secretario", "secretario123", "Secretario");
                var defaultOdontologoUser = new Usuario("odontologo1", "Odonto123", "Odontologo");
                var defaultOdontologoUser2 = new Usuario("odontologo2", "Odonto123", "Odontologo");
                Usuarios.Add(defaultUser);
                Usuarios.Add(defaultSecretario);
                //Obras sociales
                var obraSocial1 = new ObraSocial(0, "OSDE");
                var obraSocial2 = new ObraSocial(0, "Swiss Medical");
                ObrasSociales.Add(obraSocial1);
                ObrasSociales.Add(obraSocial2);
                //Odontologos
                var odontologo1 = new Odontologo(0, "12345", "Juan", "Perez", new DateTime(DateTime.Now.Year - 30, 1, 1), "Avenida siempre viva 742", "odontologo1@ejemplo.com", "123456789", "123123123", defaultOdontologoUser);
                var odontologo2 = new Odontologo(0, "67890", "Maria", "Gomez", new DateTime(DateTime.Now.Year - 28, 5, 15), "Avenida Siempre Viva 742", "odontologo2@ejemplo.com", "987654321", "123456789", defaultOdontologoUser2);
                Odontologos.Add(odontologo1);
                Odontologos.Add(odontologo2);

                // Pacientes
                var paciente1 = new Paciente(0, "Luis", "Martinez", "11223344", "Calle Falsa 123", "email@email.com", new DateTime(DateTime.Now.Year - 25, 3, 10), "123123", "", "1", null, null);
                var paciente2 = new Paciente(0, "Ana", "Gomez", "98765432", "Avenida Siempre Viva 742", "email@email2.com", new DateTime(DateTime.Now.Year - 22, 7, 15), "1111111", "", "2", null, null);
                Pacientes.Add(paciente1);
                Pacientes.Add(paciente2);

                //Tipos de atencion
                var tipoAtencion1 = new TipoAtencion(0, "Consulta General", new TimeSpan(0, 30, 0));
                var tipoAtencion2 = new TipoAtencion(0, "Consulta Odontológica", new TimeSpan(0, 90, 0));
                var tipoAtencion3 = new TipoAtencion(0, "Blanqueamiento", new TimeSpan(0, 60, 0));
                TipoAtenciones.Add(tipoAtencion1);
                TipoAtenciones.Add(tipoAtencion2);
                TipoAtenciones.Add(tipoAtencion3);
                SaveChanges();

                //Tipos de plan
                var tipoPlan1 = new TipoPlan(0, "Plan Básico", "Cobertura básica para pacientes", obraSocial1.Id);
                var tipoPlan2 = new TipoPlan(0, "Plan Completo", "Cobertura completa para pacientes", obraSocial1.Id);
                var tipoPlan3 = new TipoPlan(0, "Plan Premium", "Cobertura completa para pacientes", obraSocial2.Id);
                var tipoPlan4 = new TipoPlan(0, "Plan Familiar", "Cobertura para toda la familia", obraSocial2.Id);
                TipoPlanes.Add(tipoPlan1);
                TipoPlanes.Add(tipoPlan2);
                TipoPlanes.Add(tipoPlan3);
                TipoPlanes.Add(tipoPlan4);
                // Atenciones
                var atencion1 = new Atencion(DateTime.Now, "Otorgada", " ", odontologo1.Id, paciente1.Id, tipoAtencion1.Id);
                var atencion2 = new Atencion(DateTime.Now.AddDays(1), "Otorgada", " ", odontologo2.Id, paciente2.Id, tipoAtencion2.Id);
                Atenciones.Add(atencion1);
                Atenciones.Add(atencion2);
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
                      .OnDelete(DeleteBehavior.SetNull);

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
