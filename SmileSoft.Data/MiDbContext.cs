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
                //Usuarios - Admin y Secretario
                var defaultUser = new Usuario("admin", "Admin123", "Admin");
                var defaultSecretario = new Usuario("secretario", "secretario123", "Secretario");
                
                //Usuarios - Odontólogos
                var defaultOdontologoUser = new Usuario("odontologo1", "Odonto123", "Odontologo");
                var defaultOdontologoUser2 = new Usuario("odontologo2", "Odonto123", "Odontologo");
                var defaultOdontologoUser3 = new Usuario("odontologo3", "Odonto123", "Odontologo");
                var defaultOdontologoUser4 = new Usuario("odontologo4", "Odonto123", "Odontologo");
                
                //Usuarios - Pacientes
                var pacienteUser1 = new Usuario("mrusso", "Paciente123", "Paciente");
                var pacienteUser2 = new Usuario("cquintana", "Paciente123", "Paciente");
                var pacienteUser3 = new Usuario("fmallo", "Paciente123", "Paciente");
                
                Usuarios.Add(defaultUser);
                Usuarios.Add(defaultSecretario);
                Usuarios.Add(defaultOdontologoUser);
                Usuarios.Add(defaultOdontologoUser2);
                Usuarios.Add(defaultOdontologoUser3);
                Usuarios.Add(defaultOdontologoUser4);
                Usuarios.Add(pacienteUser1);
                Usuarios.Add(pacienteUser2);
                Usuarios.Add(pacienteUser3);
                SaveChanges();
                
                //Obras sociales
                var obraSocial1 = new ObraSocial(0, "OSDE");
                var obraSocial2 = new ObraSocial(0, "Swiss Medical");
                ObrasSociales.Add(obraSocial1);
                ObrasSociales.Add(obraSocial2);
                SaveChanges();
                
                //Odontologos
                var odontologo1 = new Odontologo(0, "Angel", "Di Maria", "12345", new DateTime(DateTime.Now.Year - 30, 1, 1), "Avenida siempre viva 742", "odontologo1@ejemplo.com", "123456789", "123123123", defaultOdontologoUser);
                var odontologo2 = new Odontologo(0,"Alejo", "Veliz", "67890", new DateTime(DateTime.Now.Year - 28, 5, 15), "Avenida Siempre Viva 742", "odontologo2@ejemplo.com", "987654321", "123456789", defaultOdontologoUser2);
                var odontologo3 = new Odontologo(0, "Marco", "Ruben", "54321", new DateTime(DateTime.Now.Year - 35, 8, 20), "Calle Falsa 123", "odonto@gmail.com", "555555555", "987654321", defaultOdontologoUser3);
                var odontologo4 = new Odontologo(0, "Jaminton", "Campaz", "98765", new DateTime(DateTime.Now.Year - 32, 11, 30), "Calle Verdadera 456", "odonto4@gmail.com", "444444444", "111222333", defaultOdontologoUser4);

                Odontologos.Add(odontologo1);
                Odontologos.Add(odontologo2);
                Odontologos.Add(odontologo3);
                Odontologos.Add(odontologo4);
                SaveChanges();

                //Tutores
                var tutor1 = new Persona(0, "Edgardo", "Bauza", "22334455",new DateTime(2000,10,10), "Calle Falsa 123", "tutor1@ejemplo.com", "123456789");
                var tutor2 = new Persona(0, "Eduardo", "Coudet", "33445566", new DateTime(2003,11,08),"Avenida Siempre Viva 742", "tutor2@ejemplo.com", "987654321");
                var tutor3 = new Persona(0, "Ariel", "Holan", "44556677",new DateTime(2001,06,10), "Calle Luna 456", "tutor3@ejemplo.com", "555555555");
                Personas.Add(tutor1);
                Personas.Add(tutor2);
                Personas.Add(tutor3);
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
                SaveChanges();

                // Pacientes - Con usuarios asignados para acceso al portal
                var paciente1 = new Paciente(
                    0, 
                    "Miguel Angel", 
                    "Russo", 
                    "11223344", 
                    "Calle Falsa 123", 
                    "mrusso@email.com", 
                    new DateTime(DateTime.Now.Year - 25, 3, 10), 
                    "341-5551234", 
                    "1234567", 
                    "HC-001", 
                    null, 
                    tipoPlan4.Id, 
                    pacienteUser1.Id
                );
                
                var paciente2 = new Paciente(
                    0, 
                    "Carlos", 
                    "Quintana", 
                    "98765432", 
                    "Avenida Siempre Viva 742", 
                    "cquintana@email.com", 
                    new DateTime(DateTime.Now.Year - 22, 7, 15), 
                    "341-5555678", 
                    "7654321", 
                    "HC-002", 
                    null, 
                    tipoPlan2.Id, 
                    pacienteUser2.Id
                );
                
                var paciente3 = new Paciente(
                    0, 
                    "Facundo", 
                    "Mallo", 
                    "55667788", 
                    "Calle Luna 456", 
                    "fmallo@email.com", 
                    new DateTime(DateTime.Now.Year - 30, 1, 1), 
                    "341-5559012", 
                    null, 
                    "HC-003", 
                    null, 
                    null, 
                    pacienteUser3.Id
                );
                
                // Pacientes - Sin usuario (solo registrados en el sistema)
                var paciente4 = new Paciente(
                    0, 
                    "Jorge", 
                    "Broun", 
                    "44332211", 
                    "Calle Sol 789", 
                    "jbroun@email.com", 
                    new DateTime(DateTime.Now.Year - 27, 12, 5), 
                    "341-5553456", 
                    null, 
                    "HC-004", 
                    null, 
                    null, 
                    null
                );
                
                // Paciente menor con tutor asignado
                var paciente5 = new Paciente(
                    0, 
                    "Ignacio", 
                    "Malcorra", 
                    "99887766",
                    tutor1.Direccion, 
                    tutor1.Email, 
                    new DateTime(DateTime.Now.Year - 10, 3, 10), 
                    tutor1.Telefono, 
                    null, 
                    "HC-005", 
                    tutor1.Id, 
                    null, 
                    null
                );

                Pacientes.Add(paciente1);
                Pacientes.Add(paciente2);
                Pacientes.Add(paciente3);
                Pacientes.Add(paciente4);
                Pacientes.Add(paciente5);
                SaveChanges();

                //Tipos de atencion
                var tipoAtencion1 = new TipoAtencion(0, "Consulta General", new TimeSpan(0, 30, 0));
                var tipoAtencion2 = new TipoAtencion(0, "Consulta Odontológica", new TimeSpan(0, 90, 0));
                var tipoAtencion3 = new TipoAtencion(0, "Blanqueamiento", new TimeSpan(0, 60, 0));
                var tipoAtencion4 = new TipoAtencion(0, "Ortodoncia", new TimeSpan(0, 90, 0));
                var tipoAtencion5 = new TipoAtencion(0, "Limpieza Dental", new TimeSpan(0, 60, 0));
                TipoAtenciones.Add(tipoAtencion1);
                TipoAtenciones.Add(tipoAtencion2);
                TipoAtenciones.Add(tipoAtencion3);
                TipoAtenciones.Add(tipoAtencion4);
                TipoAtenciones.Add(tipoAtencion5);
                SaveChanges();

                // Atenciones
                var hoy = DateTime.Today;
                var ayer = hoy.AddDays(-1);
                var mañana = hoy.AddDays(1);

                var atencion2 = new Atencion(ayer.AddHours(9), "Atendido", "Se realizó limpieza profunda. Paciente refiere sensibilidad.", odontologo1.Id, paciente2.Id, tipoAtencion5.Id);
                var atencion3 = new Atencion(ayer.AddHours(10), "Atendido", "Revisión general sin novedades.", odontologo2.Id, paciente3.Id, tipoAtencion1.Id);
                var atencion4 = new Atencion(ayer.AddHours(11), "Cancelada", string.Empty, odontologo3.Id, paciente4.Id, tipoAtencion2.Id);
                var atencion5 = new Atencion(ayer.AddHours(12), "Atendido", "Ajuste de ortodoncia. Se cita para el próximo mes.", odontologo4.Id, paciente1.Id, tipoAtencion4.Id);
                var atencion6 = new Atencion(ayer.AddHours(14), "Atendido", "Blanqueamiento exitoso.", odontologo1.Id, paciente5.Id, tipoAtencion3.Id);

                var atencion7 = new Atencion(hoy.AddHours(10), "En sala de espera", string.Empty, odontologo2.Id, paciente4.Id, tipoAtencion2.Id);
                var atencion8 = new Atencion(hoy.AddHours(11), "Otorgada", string.Empty, odontologo3.Id, paciente1.Id, tipoAtencion5.Id);
                var atencion9 = new Atencion(hoy.AddHours(12), "Otorgada", string.Empty, odontologo4.Id, paciente2.Id, tipoAtencion1.Id);
                var atencion10 = new Atencion(hoy.AddHours(14), "Otorgada", string.Empty, odontologo1.Id, paciente5.Id, tipoAtencion1.Id);
                var atencion11 = new Atencion(hoy.AddHours(15), "Otorgada", string.Empty, odontologo2.Id, paciente3.Id, tipoAtencion3.Id);

                var atencion12 = new Atencion(mañana.AddHours(9), "Otorgada", string.Empty, odontologo1.Id, paciente3.Id, tipoAtencion1.Id);
                var atencion13 = new Atencion(mañana.AddHours(9).AddMinutes(30), "Otorgada", string.Empty, odontologo2.Id, paciente4.Id, tipoAtencion5.Id);
                var atencion14 = new Atencion(mañana.AddHours(10), "Otorgada", string.Empty, odontologo3.Id, paciente5.Id, tipoAtencion3.Id);
                var atencion15 = new Atencion(mañana.AddHours(11), "Otorgada", string.Empty, odontologo4.Id, paciente1.Id, tipoAtencion2.Id);
                var atencion16 = new Atencion(mañana.AddHours(12), "Otorgada", string.Empty, odontologo1.Id, paciente2.Id, tipoAtencion4.Id);
                var atencion17 = new Atencion(mañana.AddHours(14), "Otorgada", string.Empty, odontologo2.Id, paciente1.Id, tipoAtencion1.Id);
                var atencion18 = new Atencion(mañana.AddHours(15), "Otorgada", string.Empty, odontologo3.Id, paciente2.Id, tipoAtencion5.Id);
                var atencion19 = new Atencion(mañana.AddHours(16), "Otorgada", string.Empty, odontologo4.Id, paciente3.Id, tipoAtencion2.Id);
                var atencion20 = new Atencion(mañana.AddHours(17), "Otorgada", string.Empty, odontologo1.Id, paciente4.Id, tipoAtencion3.Id);

                Atenciones.Add(atencion2);
                Atenciones.Add(atencion3);
                Atenciones.Add(atencion4);
                Atenciones.Add(atencion5);
                Atenciones.Add(atencion6);
                Atenciones.Add(atencion7);
                Atenciones.Add(atencion8);
                Atenciones.Add(atencion9);
                Atenciones.Add(atencion10);
                Atenciones.Add(atencion11);
                Atenciones.Add(atencion12);
                Atenciones.Add(atencion13);
                Atenciones.Add(atencion14);
                Atenciones.Add(atencion15);
                Atenciones.Add(atencion16);
                Atenciones.Add(atencion17);
                Atenciones.Add(atencion18);
                Atenciones.Add(atencion19);
                Atenciones.Add(atencion20);
                SaveChanges();

                
                Console.WriteLine("===== USUARIOS DE PRUEBA CREADOS =====");
                Console.WriteLine("\n--- ADMINISTRADOR ---");
                Console.WriteLine("Username: admin");
                Console.WriteLine("Password: Admin123");
                Console.WriteLine("\n--- SECRETARIO ---");
                Console.WriteLine("Username: secretario");
                Console.WriteLine("Password: secretario123");
                Console.WriteLine("\n--- ODONTÓLOGOS ---");
                Console.WriteLine("Username: odontologo1 | Password: Odonto123");
                Console.WriteLine("Username: odontologo2 | Password: Odonto123");
                Console.WriteLine("Username: odontologo3 | Password: Odonto123");
                Console.WriteLine("Username: odontologo4 | Password: Odonto123");
                Console.WriteLine("\n--- PACIENTES CON ACCESO AL PORTAL ---");
                Console.WriteLine("Username: mrusso     | Password: Paciente123 | Miguel Angel Russo");
                Console.WriteLine("Username: cquintana  | Password: Paciente123 | Carlos Quintana");
                Console.WriteLine("Username: fmallo     | Password: Paciente123 | Facundo Mallo");
                Console.WriteLine("\n=======================================");
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
                entity.HasOne(e => e.Usuario)
                        .WithMany()
                        .HasForeignKey(e => e.UsuarioId)
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
