using DTO;
using SmileSoft.Services;
using SmileSoft.Dominio;

namespace SmileSoft.WebAPI
{
    public static class TipoAtencionEndpoints
    {
        public static void MapTipoAtencionEndpoints(this WebApplication app)
        {
            app.MapGet("/tipoatencion", () =>
            {
                TipoAtencionService tipoAtencionService = new TipoAtencionService();
                var dtos = tipoAtencionService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetTipoAtencion")
            .Produces<List<TipoAtencionDTO>>(StatusCodes.Status200OK);
            app.MapGet($"tipoatencion/id", (int id) =>
            {
                TipoAtencionService tipoAtencionService = new TipoAtencionService();
                TipoAtencion dto = tipoAtencionService.GetTipoAtencion(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("GetOneTipoAtencion");
            app.MapPost("/tipoatencion", (TipoAtencionDTO tipoAtencionDTO) =>
            {
                try
                {
                    TipoAtencionService tipoAtencionService = new TipoAtencionService();
                    // Validación de campos obligatorios
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(tipoAtencionDTO.Descripcion))
                        errores.Add("La descripción es obligatoria");
                    if (tipoAtencionDTO.Duracion == TimeSpan.Zero)
                        errores.Add("La duracion es obligatoria");
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = tipoAtencionService.Add(tipoAtencionDTO);
                    return Results.Created($"/tipoatencion/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear el tipo de atención",
                        message = ex.Message
                    });
                }

            }).WithName("CreateTipoAtencion");
            app.MapPut("/tipoatencion/{id}", (int id, TipoAtencionDTO tipoAtencion) =>
            {
                try
                {
                    TipoAtencionService tipoAtencionService = new TipoAtencionService();
                    var found = tipoAtencionService.GetTipoAtencion(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró el tipo de atención." });
                    }
                    tipoAtencionService.Update(id, tipoAtencion);

                    return Results.NoContent();
                }
                catch (ArgumentException ex) { 
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateTipoAtencion");
            app.MapDelete("/tipoatencion/{id}", (int id) =>
            {
                TipoAtencionService tipoAtencionService = new TipoAtencionService();
                var eliminado = tipoAtencionService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeleteTipoAtencion");
        }
    }
}
