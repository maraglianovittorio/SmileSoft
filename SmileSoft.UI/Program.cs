using DTO;
using Microsoft.EntityFrameworkCore;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
namespace SmileSoft.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpLogging(o => { });
            //builder.Services.AddDbContext<MiDbContext>(options =>
            //     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }
            app.UseHttpsRedirection();
            app.MapGet("/", () => $"Ir a /swagger para probar");
            app.MapPacienteEndpoints();
            app.MapAuthEndpoints();
            app.MapObraSocialEndpoints();
            app.MapUsuarioEndpoints();
            app.MapTipoPlanesEndpoints();
            app.MapTipoAtencionEndpoints();
            app.MapOdontologoEndpoints();
            app.MapPersonaEndpoints();
            app.MapAtencionEndpoints();
            app.Run();

        }
    }
}
