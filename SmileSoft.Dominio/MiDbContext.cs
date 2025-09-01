using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class MiDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FCMDQAD\SQLEXPRESS;Initial Catalog=SmileSoft;Integrated Security=true;TrustServerCertificate=true;");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        }
        public MiDbContext()
        {
            this.Database.EnsureCreated();
        }

    }



}
