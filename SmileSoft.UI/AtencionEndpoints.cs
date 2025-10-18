using DTO;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class AtencionEndpoints
    {

        public static void MapAtencionEndpoints(this WebApplication app)
        {
            app.MapGet("/atenciones", () =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetAtenciones");
            app.MapGet($"/atenciones/estado=estado", (string estado) =>
            {
            AtencionService atencionService = new AtencionService();
            var dtos = atencionService.GetAtencionesByEstado(estado);
                return Results.Ok(dtos);
            })
            .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
            .WithName("GetAtencionesByEstado");
            app.MapGet($"/atenciones/paciente=pacienteId", (int pacienteId) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByPaciente(pacienteId);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByPaciente");
            app.MapGet($"/atenciones/odontologo=odontologoId", (int odontologoId) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByOdontologo(odontologoId);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByOdontologo");
            app.MapGet($"/atenciones/tipoatencion=tipoAtencionId", (int tipoAtencionId) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByTipoAtencion(tipoAtencionId);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByTipoAtencion");
            app.MapGet($"/atenciones/startdate=startDate/enddate=endDate", (DateTime startDate, DateTime endDate) =>
            {
                AtencionService atencionService = new AtencionService();
                var dtos = atencionService.GetAllByRango(startDate, endDate);
                return Results.Ok(dtos);
            })
                .Produces<List<AtencionDTO>>(StatusCodes.Status200OK)
                .WithName("GetAtencionesByRango");
            app.MapGet($"atenciones/id", (int id) =>
            {
                AtencionService atencionService = new AtencionService();
                AtencionDTO dto = atencionService.GetAtencion(id);
                return dto is not null ? Results.Ok(new { Atencion = dto }) : Results.NotFound();
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

