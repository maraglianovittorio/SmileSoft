using SmileSoft.DTO;
using SmileSoft.Services;
using SmileSoft.Dominio;

namespace SmileSoft.WebAPI
{
    public static class TipoPlanesEndpoints
    {
        public static void MapTipoPlanesEndpoints(this WebApplication app)
        {
            app.MapGet("/tipoplanes", () =>
            {
                TipoPlanService tipoPlanService = new TipoPlanService();
                var dtos = tipoPlanService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetTipoPlanes")
            .Produces<List<TipoPlanDTO>>(StatusCodes.Status200OK).RequireAuthorization();
            
            app.MapGet($"/tipoplanes/obraSocial", (int id) =>
            {
                TipoPlanService tipoPlanService = new TipoPlanService();
                var dtos = tipoPlanService.GetByObraSocialId(id);
                return Results.Ok(dtos);
            }).WithName("GetTipoPlanesByObraSocial").RequireAuthorization();
            
            app.MapGet($"tipoplanes/id", (int id) =>
            {
                TipoPlanService tipoPlanService = new TipoPlanService();
                TipoPlanDTO dto = tipoPlanService.GetTipoPlan(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("GetTipoPlan").RequireAuthorization();
            
            app.MapPost("/tipoplanes", (TipoPlanDTO tipoPlanDTO) =>
            {
                try
                {
                    TipoPlanService tipoPlanService = new TipoPlanService();
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(tipoPlanDTO.Nombre))
                        errores.Add("El nombre es obligatorio");
                    if (string.IsNullOrWhiteSpace(tipoPlanDTO.Descripcion))
                        errores.Add("La descripción es obligatoria");
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = tipoPlanService.Add(tipoPlanDTO);
                    return Results.Created($"/tipoplanes/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear el tipo de plan",
                        message = ex.Message
                    });
                }

            }).WithName("CreateTipoPlan").RequireAuthorization();
            
            app.MapPut("/tipoplanes/{id}", (int id, TipoPlanDTO tipoPlan) =>
            {
                try
                {
                    TipoPlanService tipoPlanService = new TipoPlanService();
                    var found = tipoPlanService.GetTipoPlan(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró el tipo de plan." });
                    }
                    tipoPlanService.Update(id, tipoPlan);

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateTipoPlan").RequireAuthorization();
            
            app.MapDelete("/tipoplanes/{id}", (int id) =>
            {
                TipoPlanService tipoPlanService = new TipoPlanService();
                var eliminado = tipoPlanService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeleteTipoPlan").RequireAuthorization();
        }
    }
}
