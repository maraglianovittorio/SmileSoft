using DTO;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class OdontologoEndpoints
    {

        public static void MapOdontologoEndpoints(this WebApplication app)
        {
            app.MapGet("/odontologos", () =>
            {
                OdontologoService odontologoService = new OdontologoService();
                var dtos = odontologoService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetOdontologos")
            .Produces<List<OdontologoDTO>>(StatusCodes.Status200OK).RequireAuthorization();
            
            app.MapGet($"odontologos/id", (int id) =>
            {
                OdontologoService odontologoService = new OdontologoService();
                OdontologoDTO dto = odontologoService.GetOdontologo(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("GetOdontologo").RequireAuthorization();
            
            app.MapPost("/odontologos", (OdontologoCreacionDTO odontologoCreacionDTO) =>
            {
                try
                {
                    OdontologoService odontologoService = new OdontologoService();
                    // Validación de campos obligatorios
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(odontologoCreacionDTO.Nombre))
                        errores.Add("El nombre es obligatorio");
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = odontologoService.Add(odontologoCreacionDTO);
                    return Results.Created($"/odontologos/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear el odontólogo",
                        message = ex.Message
                    });
                }

            }).WithName("CreateOdontologo").RequireAuthorization();
            
            app.MapPut("/odontologos/{id}", (int id, OdontologoCreacionDTO odontologo) =>
            {
                try
                {
                    OdontologoService odontologoService = new OdontologoService();
                    var found = odontologoService.GetOdontologo(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró el odontólogo." });
                    }
                    odontologoService.Update(id, odontologo);

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateOdontologo").RequireAuthorization();
            
            app.MapDelete("/odontologos/{id}", (int id) =>
            {
                OdontologoService odontologoService = new OdontologoService();
                var eliminado = odontologoService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeleteOdontologo").RequireAuthorization();
        }
    }
}


