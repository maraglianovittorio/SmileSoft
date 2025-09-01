using SmileSoft.Dominio;
using DTO;

namespace SmileSoft.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar servicios para controladores
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configurar pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.MapControllers();

            // Mantener solo el endpoint de inicio
            app.MapGet("/", () => "Ir a /swagger para probar la API")
                .WithName("Home");

            app.Run();
        }
    }
}
