using DTO;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class ObraSocialEndpoints
    {

        public static void MapObraSocialEndpoints(this WebApplication app)
        {
            app.MapGet("/obrasocial", () =>
            {
                ObraSocialService obraSocialService = new ObraSocialService();
                var dtos = obraSocialService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetObraSociales")
            .Produces<List<ObraSocialDTO>>(StatusCodes.Status200OK);
            app.MapGet($"obrasocial/id", (int id) =>
            {
                ObraSocialService obraSocialService = new ObraSocialService();
                ObraSocialDTO dto = obraSocialService.GetObraSocial(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("GetObraSocial");
            app.MapPost("/obrasocial", (ObraSocialDTO obraSocialDTO) =>
            {
                try
                {
                    ObraSocialService obraSocialService = new ObraSocialService();
                    // Validación de campos obligatorios
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(obraSocialDTO.Nombre))
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
                    var dto = obraSocialService.Add(obraSocialDTO);
                    return Results.Created($"/obrasocial/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear la obra social",
                        message = ex.Message
                    });
                }

            }).WithName("CreateObraSocial");
            app.MapPut("/obrasocial/{id}", (int id, ObraSocialDTO obraSocial) =>
            {
                try
                {
                    ObraSocialService obraSocialService = new ObraSocialService();
                    var found = obraSocialService.GetObraSocial(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró la obra social." });
                    }
                    obraSocialService.Update(id, obraSocial);

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateObraSocial");
            app.MapDelete("/obrasocial/{id}", (int id) =>
            {
                ObraSocialService obraSocialService = new ObraSocialService();
                var eliminado = obraSocialService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeleteObraSocial");
        }
    }
}

