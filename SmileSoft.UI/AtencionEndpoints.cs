using DTO;
using SmileSoft.Services;
using Microsoft.AspNetCore.Mvc;

namespace SmileSoft.WebAPI
{
    public static class AtencionEndpoints
    {

        public static void MapAtencionEndpoints(this WebApplication app)
        {
            app.MapPut("/atenciones/{id}/observaciones", (int id, [FromBody] string observaciones) =>
            {
                try
                {
                    // Validate input
                    if (id <= 0)
                    {
                        return Results.BadRequest(new { error = "El ID debe ser un número positivo." });
                    }

                    if (observaciones == null)
                    {
                        return Results.BadRequest(new { error = "Las observaciones no pueden ser nulas." });
                    }

                    AtencionService atencionService = new AtencionService();
                    bool updated = atencionService.UpdateObservaciones(id, observaciones);
                    
                    if (!updated)
                    {
                        return Results.NotFound(new { error = $"No se encontró la atención con ID {id}." });
                    }
                    
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        detail: ex.Message,
                        statusCode: StatusCodes.Status500InternalServerError,
                        title: "Error al actualizar observaciones"
                    );
                }
            }).WithName("UpdateAtencionObservaciones")
              .Produces(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status404NotFound)
              .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/atenciones", () =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetAtenciones")
            .Produces<List<AtencionDetalleDTO>>(StatusCodes.Status200OK);

            app.MapGet($"/atenciones/estado", (string estado) =>
            {
            AtencionService atencionService = new AtencionService();
            var dtos = atencionService.GetAtencionesByEstado(estado);
                return Results.Ok(dtos);
            })
            .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
            .WithName("GetAtencionesByEstado");
            app.MapGet($"/atenciones/paciente", (int pacienteId) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByPaciente(pacienteId);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByPaciente");
            
            app.MapGet($"/atenciones/odontologo", (int id) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByOdontologo(id);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDetalleDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByOdontologo");
            
            app.MapGet($"/atenciones/tipoatencion", (int tipoAtencionId) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByTipoAtencion(tipoAtencionId);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByTipoAtencion");
            
            app.MapGet($"/atenciones/rango", (DateTime startDate, DateTime endDate) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByRango(startDate, endDate);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByRango");

            app.MapGet($"/atenciones/rangoYOdo", (DateTime startDate, DateTime endDate,int id) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByRangoAndOdo(startDate, endDate,id);
                return Results.Ok(dtos);
            })
            .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
            .WithName("GetAtencionesByRangoAndOdo");
            
            app.MapGet($"atenciones/id", (int id) =>
            {
                AtencionService atencionService = new AtencionService();
                AtencionDetalleDTO dto = atencionService.GetAtencion(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("GetAtencion");
            
            app.MapPost("/atenciones", (AtencionDTO atencionDTO) =>
            {
                try
                {
                    AtencionService atencionService = new AtencionService();
                    // Validación de campos obligatorios
                    var errores = new List<string>();
                    //if (string.IsNullOrWhiteSpace(atencionDTO.FechaHoraAtencion))
                    //    errores.Add("La fecha y hora de atención son obligatorias");
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = atencionService.Add(atencionDTO);
                    return Results.Created($"/atenciones/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear la atención",
                        message = ex.Message
                    });
                }

            }).WithName("CreateAtencion");
            
            app.MapPut("/atenciones/{id}", (int id, AtencionDTO atencion) =>
            {
                try
                {
                    AtencionService atencionService = new AtencionService();
                    var found = atencionService.GetAtencion(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró la atención." });
                    }
                    atencionService.Update(id, atencion);

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAtencion");
            
            app.MapDelete("/atenciones/{id}", (int id) =>
            {
                AtencionService atencionService = new AtencionService();
                var eliminado = atencionService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeleteAtencion");
        }
    }
}

