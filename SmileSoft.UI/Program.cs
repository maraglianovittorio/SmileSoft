using SmileSoft.Dominio;
using DTO;
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
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }
            app.UseHttpsRedirection();

            //Paciente.ListaP.Add(new Paciente(1, "Vittorio", "Maragliano", "Iriondo", 1));
            //Paciente.ListaP.Add(new Paciente(2, "Guido", "Maragliano", "Iriondo", 2));
            app.MapGet("/", () => $"Ir a /swagger para probar");

           

          

            // OBRAS SOCIALES -------------------------------------------------------------------------------------------
            app.MapGet($"/obraSocial", () => ObraSocial.ListaOS).WithName("GetObrasSociales");

            app.MapGet($"obraSocial/id", (int id) =>
            {
                var obraSocial = ObraSocial.ListaOS.FirstOrDefault(o => o.Id == id);
                return obraSocial is not null ? Results.Ok(obraSocial) : Results.NotFound();

            }).WithName("Get Obras Sociales");

            app.MapPost("/obraSocial", (ObraSocialDTO obraSocialDTO) =>
            {
                // Validaci�n de campos obligatorios
                var errores = new List<string>();

                if (string.IsNullOrWhiteSpace(obraSocialDTO.Nombre))
                    errores.Add("El nombre es obligatorio");

                if (errores.Count > 0)
                {
                    return Results.BadRequest(new
                    {
                        error = "Datos inv�lidos",
                        message = "Faltan campos obligatorios",
                        details = errores
                    });
                }

                var nuevoID = ObraSocial.ObtenerProximoID();
                var buscaNombre = ObraSocial.ListaOS.FirstOrDefault(o => o.Nombre == obraSocialDTO.Nombre);
                if (buscaNombre != null)
                {
                    return Results.Conflict(new
                    {
                        error = "Nombre de obra social duplicado",
                        message = $"Ya existe una obra social con el nombre {obraSocialDTO.Nombre}",
                        field = "Nombre"
                    });
                }

                // Crear la obra social con datos limpios (trim)
                var nuevaObraSocial = new ObraSocial(
                    nuevoID,
                    obraSocialDTO.Nombre.Trim()
                );

                ObraSocial.ListaOS.Add(nuevaObraSocial);
                return Results.Created($"obraSocial/{nuevoID}", nuevaObraSocial);
            }).WithName("Create obra social");

            app.MapDelete("/obraSocial/{id}", (int id) =>
            {
                var obraSocial = ObraSocial.ListaOS.FirstOrDefault(p => p.Id == id);
                if (obraSocial != null)
                {
                    ObraSocial.ListaOS.Remove(obraSocial);
                    return Results.NoContent();

                }
                else
                {
                    return Results.NotFound();
                }
            }).WithName("Delete obra social");

            app.MapPut("obraSocial/{id}", (int id, ObraSocialDTO obraSocialDTO) =>
            {
                var obraSocial = ObraSocial.ListaOS.FirstOrDefault(p => p.Id == id);
                if (obraSocial != null)
                {
                    var buscaNombre = ObraSocial.ListaOS.FirstOrDefault(p => p.Nombre == obraSocialDTO.Nombre && p.Id != id);
                    if (buscaNombre != null)
                    {
                        return Results.Conflict(new
                        {
                            error = "Nombre de obra social duplicado",
                            message = $"Ya existe una obra social con el nombre {obraSocialDTO.Nombre}",
                            field = "Nombre"
                        });
                    }
                    obraSocial.Nombre = obraSocialDTO.Nombre;

                    return Results.NoContent();
                }
                return Results.NotFound();
            });
            app.MapPacienteEndpoints();
            app.Run();

        }
    }
}
