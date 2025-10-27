using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SmileSoft.Data;
using SmileSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileSoft.Services.Reportes
{
    public class ReporteAtencionesService : IReporteService<ReporteAtencionesRequestDTO>
    {
        public byte[] GenerarReporte(ReporteAtencionesRequestDTO request)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByRango(request.FechaDesde, request.FechaHasta).ToList();

            // Aplicar filtros adicionales
            if (request.OdontologoId.HasValue)
            {
                atenciones = atenciones.Where(a => a.OdontologoId == request.OdontologoId.Value).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Estado))
            {
                atenciones = atenciones.Where(a => a.Estado.Equals(request.Estado, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (request.TipoAtencionId.HasValue)
            {
                atenciones = atenciones.Where(a => a.TipoAtencionId == request.TipoAtencionId.Value).ToList();
            }

            // Convertir a DTOs
            var atencionesDto = atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            }).OrderBy(a => a.FechaHoraAtencion).ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    // Header
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().Text("SmileSoft - Sistema de Gestión Odontológica")
                                .FontSize(16).SemiBold().FontColor(Colors.Blue.Darken2);
                            column.Item().Text("Reporte de Atenciones")
                                .FontSize(13).FontColor(Colors.Grey.Darken2);
                            column.Item().PaddingTop(5).Text($"Período: {request.FechaDesde:dd/MM/yyyy} - {request.FechaHasta:dd/MM/yyyy}")
                                .FontSize(10).Italic().FontColor(Colors.Grey.Darken1);
                            
                            if (request.OdontologoId.HasValue)
                            {
                                var odontologo = atencionesDto.FirstOrDefault();
                                if (odontologo != null)
                                {
                                    column.Item().Text($"Odontólogo: {odontologo.OdontologoApellido}, {odontologo.OdontologoNombre}")
                                        .FontSize(9).FontColor(Colors.Grey.Darken1);
                                }
                            }
                        });

                        row.ConstantItem(100).AlignRight().Column(column =>
                        {
                            column.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                                .FontSize(9).FontColor(Colors.Grey.Darken1);
                            column.Item().Text($"Hora: {DateTime.Now:HH:mm}")
                                .FontSize(9).FontColor(Colors.Grey.Darken1);
                        });
                    });

                    // Content
                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
                    {
                        column.Spacing(15);

                        // Estadísticas
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Total de atenciones: {atencionesDto.Count}")
                                .FontSize(11).SemiBold().FontColor(Colors.Blue.Darken1);

                            var porEstado = atencionesDto.GroupBy(a => a.Estado)
                                .Select(g => $"{g.Key}: {g.Count()}")
                                .ToList();
                            
                            row.RelativeItem().AlignRight()
                                .Text(string.Join(" | ", porEstado))
                                .FontSize(9).FontColor(Colors.Grey.Darken1);
                        });

                        // Tabla de atenciones
                        foreach (var atencion in atencionesDto)
                        {
                            column.Item().Border(1).BorderColor(Colors.Grey.Lighten2)
                                .Padding(10).Column(innerColumn =>
                                {
                                    innerColumn.Spacing(5);

                                    // Fecha y Estado
                                    innerColumn.Item().Row(row =>
                                    {
                                        row.RelativeItem().Text($" {atencion.FechaHoraAtencion:dd/MM/yyyy HH:mm}")
                                            .FontSize(10).SemiBold().FontColor(Colors.Blue.Darken1);
                                        
                                        var estadoColor = atencion.Estado.ToLower() switch
                                        {
                                            "otorgada" => Colors.Orange.Medium,
                                            "en sala de espera" => Colors.Green.Medium,
                                            "atendido" => Colors.Blue.Medium,
                                            "cancelada" => Colors.Red.Medium,
                                            _ => Colors.Grey.Medium
                                        };
                                        
                                        row.ConstantItem(100).AlignRight()
                                            .Text(atencion.Estado)
                                            .FontSize(9).SemiBold().FontColor(estadoColor);
                                    });

                                    // Paciente y Odontólogo
                                    innerColumn.Item().Row(row =>
                                    {
                                        row.RelativeItem().Text(text =>
                                        {
                                            text.Span(" Paciente: ").FontSize(9).FontColor(Colors.Grey.Darken1);
                                            text.Span($"{atencion.PacienteApellido}, {atencion.PacienteNombre}")
                                                .FontSize(9).SemiBold();
                                            text.Span($" (DNI: {atencion.PacienteDni})")
                                                .FontSize(8).FontColor(Colors.Grey.Medium);
                                        });
                                    });

                                    innerColumn.Item().Row(row =>
                                    {
                                        row.RelativeItem().Text(text =>
                                        {
                                            text.Span(" Odontólogo: ").FontSize(9).FontColor(Colors.Grey.Darken1);
                                            text.Span($"{atencion.OdontologoApellido}, {atencion.OdontologoNombre}")
                                                .FontSize(9).SemiBold();
                                        });
                                    });

                                    // Tipo de atención
                                    innerColumn.Item().Text(text =>
                                    {
                                        text.Span(" Tipo: ").FontSize(9).FontColor(Colors.Grey.Darken1);
                                        text.Span(atencion.TipoAtencionDescripcion)
                                            .FontSize(9).SemiBold().FontColor(Colors.Blue.Medium);
                                        text.Span($" (Duración: {atencion.TipoAtencionDuracion})")
                                            .FontSize(8).FontColor(Colors.Grey.Medium);
                                    });

                                    // Observaciones
                                    if (!string.IsNullOrWhiteSpace(atencion.Observaciones))
                                    {
                                        innerColumn.Item().PaddingTop(5).Column(obsColumn =>
                                        {
                                            obsColumn.Item().Text(" Observaciones:")
                                                .FontSize(9).SemiBold().FontColor(Colors.Grey.Darken2);
                                            obsColumn.Item().PaddingLeft(10).Text(atencion.Observaciones)
                                                .FontSize(8).FontColor(Colors.Grey.Darken1);
                                        });
                                    }
                                });
                        }
                    });

                    // Footer
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            });

            return document.GeneratePdf();
        }

        public Task<byte[]> GenerarReporteAsync(ReporteAtencionesRequestDTO request)
        {
            return Task.Run(() => GenerarReporte(request));
        }
    }
}