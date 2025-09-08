using SmileSoft.Dominio;
using DTO;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class PacienteEndpoints
    {
        public static void MapPacienteEndpoints(this WebApplication app)
        {
            app.MapGet("/pacientes", () =>
            {
                PacienteService pacienteService = new PacienteService();
                var dtos = pacienteService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetPacientes")
            .Produces<List<PacienteDTO>>(StatusCodes.Status200OK);
            app.MapGet($"pacientes/id", (int id) =>
            {
                PacienteService pacienteService = new PacienteService();
                PacienteDTO dto = pacienteService.GetPaciente(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("Get Paciente");
            app.MapPost("/pacientes", (PacienteDTO pacienteDTO) =>
            {
                try
                {
                    PacienteService pacienteService = new PacienteService();
                    // Validación de campos obligatorios
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(pacienteDTO.Nombre))
                        errores.Add("El nombre es obligatorio");
                    if (string.IsNullOrWhiteSpace(pacienteDTO.Apellido))
                        errores.Add("El apellido es obligatorio");
                    if (string.IsNullOrWhiteSpace(pacienteDTO.NroDni))
                        errores.Add("El DNI es obligatorio");
                    if (string.IsNullOrWhiteSpace(pacienteDTO.NroHC))
                        errores.Add("El número de historia clínica es obligatorio");
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = pacienteService.Add(pacienteDTO);
                    return Results.Created($"/pacientes/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear el paciente",
                        message = ex.Message
                    });
                }

            }).WithName("CreatePaciente");
            app.MapPut("/pacientes", (PacienteDTO dto) =>
            {
                try
                {
                    PacienteService pacienteService = new PacienteService();
                    var found = pacienteService.Update(dto.Id,dto);
                    if (!found)
                    {
                        return Results.NotFound(new { error = "No se encontró el paciente." });
                    }


                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateCliente");
            app.MapDelete("/pacientes/id", (int id) =>
            {
                PacienteService pacienteService = new PacienteService();
                var eliminado = pacienteService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeletePaciente");
        }
    }
}
