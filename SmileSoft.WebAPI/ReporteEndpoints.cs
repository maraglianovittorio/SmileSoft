using SmileSoft.DTO;
using SmileSoft.Services.Reportes;

namespace SmileSoft.WebAPI
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this WebApplication app)
        {
            app.MapPost("/reportes/pacientes", async (ReportePacientesRequestDTO request) =>
            {
                try
                {
                    var reporteService = new ReportePacientesService();
                    var pdfBytes = await reporteService.GenerarReporteAsync(request);

                    var fileName = $"Pacientes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    return Results.File(
                        pdfBytes,
                        contentType: "application/pdf",
                        fileDownloadName: fileName
                    );
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo generar el reporte de pacientes",
                        message = ex.Message
                    });
                }
            })
            .WithName("GenerarReportePacientes")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .RequireAuthorization();

            app.MapPost("/reportes/atenciones", async (ReporteAtencionesRequestDTO request) =>
            {
                try
                {
                    if (request.FechaDesde > request.FechaHasta)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Fechas inválidas",
                            message = "La fecha desde no puede ser mayor a la fecha hasta"
                        });
                    }

                    var reporteService = new ReporteAtencionesService();
                    var pdfBytes = await reporteService.GenerarReporteAsync(request);

                    var fileName = $"Atenciones_{request.FechaDesde:yyyyMMdd}_{request.FechaHasta:yyyyMMdd}.pdf";

                    return Results.File(
                        pdfBytes,
                        contentType: "application/pdf",
                        fileDownloadName: fileName
                    );
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo generar el reporte de atenciones",
                        message = ex.Message
                    });
                }
            })
            .WithName("GenerarReporteAtenciones")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .RequireAuthorization();

            app.MapPost("/reportes/atenciones-horario", (ReporteAtencionesHorarioRequestDTO request) =>
            {
                try
                {
                    var reporteService = new ReporteAtencionesHorarioService();
                    var pdfBytes = reporteService.GenerarReporte(request);

                    return Results.File(
                        pdfBytes,
                        "application/pdf",
                        $"reporte-atenciones-horario-{DateTime.Now:yyyyMMdd-HHmmss}.pdf"
                    );
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        detail: ex.Message,
                        statusCode: StatusCodes.Status500InternalServerError,
                        title: "Error al generar el reporte de atenciones por horario"
                    );
                }
            })
            .WithName("GenerarReporteAtencionesHorario")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

            app.MapPost("/reportes/atenciones-odontologo", (ReporteAtencionesOdontologoRequestDTO request) =>
            {
                try
                {
                    var reporteService = new ReporteAtencionesOdontologoService();
                    var pdfBytes = reporteService.GenerarReporte(request);
                    
                    return Results.File(
                        pdfBytes,
                        "application/pdf",
                        $"agenda-odontologos-{request.Fecha:yyyyMMdd}.pdf"
                    );
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        detail: ex.Message,
                        statusCode: StatusCodes.Status500InternalServerError,
                        title: "Error al generar el reporte de atenciones por odontólogo"
                    );
                }
            })
            .WithName("GenerarReporteAtencionesOdontologo")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

            app.MapPost("/reportes/atenciones-porodontologo", (ReporteAtencionesPorOdontologoRequestDTO request) =>
            {
                try
                {
                    var reporteService = new ReporteAtencionesPorOdontologoService();
                    var pdfBytes = reporteService.GenerarReporte(request);
                    
                    return Results.File(
                        pdfBytes,
                        "application/pdf",
                        $"agenda-odontologos-{request.Fecha:yyyyMMdd}.pdf"
                    );
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        detail: ex.Message,
                        statusCode: StatusCodes.Status500InternalServerError,
                        title: "Error al generar el reporte de atenciones por odontólogo"
                    );
                }
            })
            .WithName("GenerarReporteAtencionesPorOdontologo")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}