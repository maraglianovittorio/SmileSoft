using SmileSoft.Dominio;
using SmileSoft.DTO;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class PersonaEndpoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK).RequireAuthorization();
            
            app.MapGet("/personas/tutores", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetTutores();
                return Results.Ok(dtos);
            }).WithName("GetTutores").RequireAuthorization();
            
            app.MapGet($"personas/id", (int id) =>
            {
                PersonaService personaService = new PersonaService();
                PersonaDTO dto = personaService.GetPersona(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("GetPersona").RequireAuthorization();
            
            app.MapGet("/personas/tutor/dni", (string dni) =>
            {
                PersonaService personaService = new PersonaService();
                PersonaDTO persona = personaService.GetTutorByDni(dni);
                return persona is not null ? Results.Ok(persona) : Results.NotFound();
            }).WithName("TutorByDni").RequireAuthorization();
            
            app.MapGet("/personas/tutor/id", (int id) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var dto = personaService.GetTutor(id);
                    return Results.Ok(dto);
                }
                catch (Exception ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
            }).WithName("GetTutorById").RequireAuthorization();
            
            app.MapPost("/personas", (PersonaDTO personaDTO) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(personaDTO.Nombre))
                        errores.Add("El nombre es obligatorio");
                    if (string.IsNullOrWhiteSpace(personaDTO.Apellido))
                        errores.Add("El apellido es obligatorio");
                    if (string.IsNullOrWhiteSpace(personaDTO.NroDni))
                        errores.Add("El DNI es obligatorio");   
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = personaService.Add(personaDTO);
                    return Results.Created($"/personas/{dto.Id}", new { Persona = dto });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear la persona",
                        message = ex.Message
                    });
                }

            }).WithName("CreatePersona").RequireAuthorization();

            app.MapPut("/personas/id", (int id, PersonaDTO persona) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var found = personaService.GetPersona(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró la persona." });
                    }
                    personaService.Update(id, persona);

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePersona").RequireAuthorization();

            app.MapDelete("/personas/id", (int id) =>
            {
                PersonaService personaService = new PersonaService();
                var eliminado = personaService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeletePersona").RequireAuthorization();

            app.MapGet("/personas/dni", (string dni) =>
            {
                PersonaService personaService = new PersonaService();
                PersonaDTO persona = personaService.GetByDni(dni);
                return persona is not null ? Results.Ok(persona) : Results.NotFound();

            }).WithName("PersonaByDni").RequireAuthorization();
        }
    }
}
