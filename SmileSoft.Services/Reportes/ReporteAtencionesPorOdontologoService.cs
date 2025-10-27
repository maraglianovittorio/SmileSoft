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
    public class ReporteAtencionesPorOdontologoService
    {
        public byte[] GenerarReporte(ReporteAtencionesPorOdontologoRequestDTO request)
        {
            var atencionRepository = new AtencionRepository();
            var odontologoRepository = new OdontologoRepository();

            var fecha = request.Fecha.Date;
            var fechaFin = fecha.AddDays(1);
            var idOdo = request.IdOdo;

            // Obtener todas las atenciones del día
            var todasLasAtenciones = atencionRepository.GetAllByRangoAndOdo(fecha, fechaFin, idOdo)
                .Where(a => a.Estado != "Cancelada")
                .OrderBy(a => a.FechaHoraAtencion)
                .ToList();

            // Obtener todos los odontólogos que tienen atenciones ese día
            var odontologosConAtenciones = todasLasAtenciones
                .GroupBy(a => a.OdontologoId)
                .Select(g => new
                {
                    OdontologoId = g.Key,
                    Odontologo = g.First().Odontologo,
                    Atenciones = g.OrderBy(a => a.FechaHoraAtencion).ToList()
                })
                .OrderBy(x => x.Odontologo?.Apellido ?? "")
                .ToList();

            if (!odontologosConAtenciones.Any())
            {
                // Si no hay atenciones, generar reporte vacío
                return GenerarReporteVacio(fecha);
            }

            var document = Document.Create(container =>
            {
                // Cada odontólogo en una página separada
                foreach (var odontologoData in odontologosConAtenciones)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(1.5f, Unit.Centimetre);
                        page.PageColor(Colors.White);

                        // Header
                        page.Header().Column(column =>
                        {
                            column.Item().Text("SmileSoft - Sistema de Gestión Odontológica")
                                .FontSize(16).SemiBold().FontColor(Colors.Blue.Darken2);

                            column.Item().Text("Agenda Diaria de Atenciones")
                                .FontSize(14).FontColor(Colors.Grey.Darken2);

                            column.Item().PaddingTop(5).Text($"Fecha: {fecha:dddd, dd 'de' MMMM 'de' yyyy}")
                                .FontSize(11).FontColor(Colors.Grey.Darken1);

                            column.Item().PaddingTop(10).BorderBottom(2).BorderColor(Colors.Blue.Darken1)
                                .PaddingBottom(5).Text(text =>
                                {
                                    text.Span("Odontólogo: ").FontSize(12).SemiBold().FontColor(Colors.Blue.Darken1);
                                    text.Span($"Dr./Dra. {odontologoData.Odontologo?.Apellido}, {odontologoData.Odontologo?.Nombre}")
                                        .FontSize(12).FontColor(Colors.Grey.Darken2);
                                });
                        });

                        // Content
                        page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
                        {
                            column.Spacing(10);

                            // Resumen
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text($"Total de atenciones: {odontologoData.Atenciones.Count}")
                                    .FontSize(11).SemiBold().FontColor(Colors.Blue.Darken1);

                                var primeraAtencion = odontologoData.Atenciones.First();
                                var ultimaAtencion = odontologoData.Atenciones.Last();

                                row.RelativeItem().AlignRight().Text(
                                    $"Horario: {primeraAtencion.FechaHoraAtencion:HH:mm} - {ultimaAtencion.FechaHoraAtencion:HH:mm}")
                                    .FontSize(10).FontColor(Colors.Grey.Darken1);
                            });

                            // Tabla de atenciones
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(60);   // Hora
                                    columns.RelativeColumn(1.5f); // Paciente Apellido
                                    columns.RelativeColumn(1.5f); // Paciente Nombre
                                    columns.RelativeColumn(2);    // Tipo de Atención
                                    columns.ConstantColumn(70);   // Estado
                                });

                                // Header
                                table.Header(header =>
                                {
                                    header.Cell().Element(HeaderStyle).Text("Hora");
                                    header.Cell().Element(HeaderStyle).Text("Apellido");
                                    header.Cell().Element(HeaderStyle).Text("Nombre");
                                    header.Cell().Element(HeaderStyle).Text("Tipo de Atención");
                                    header.Cell().Element(HeaderStyle).Text("Estado");

                                    static IContainer HeaderStyle(IContainer container)
                                    {
                                        return container
                                            .DefaultTextStyle(x => x.SemiBold().FontSize(10))
                                            .Background(Colors.Blue.Lighten3)
                                            .PaddingVertical(6)
                                            .PaddingHorizontal(4)
                                            .BorderBottom(2)
                                            .BorderColor(Colors.Blue.Darken1);
                                    }
                                });

                                // Rows
                                foreach (var atencion in odontologoData.Atenciones)
                                {
                                    var backgroundColor = GetBackgroundColorForEstado(atencion.Estado);

                                    table.Cell().Element(container => CellStyle(container, backgroundColor))
                                        .Text(atencion.FechaHoraAtencion.ToString("HH:mm"))
                                        .FontSize(9).SemiBold();

                                    table.Cell().Element(container => CellStyle(container, backgroundColor))
                                        .Text(atencion.Paciente?.Apellido ?? "N/A")
                                        .FontSize(9);

                                    table.Cell().Element(container => CellStyle(container, backgroundColor))
                                        .Text(atencion.Paciente?.Nombre ?? "N/A")
                                        .FontSize(9);

                                    table.Cell().Element(container => CellStyle(container, backgroundColor))
                                        .Text(atencion.TipoAtencion?.Descripcion ?? "N/A")
                                        .FontSize(9);

                                    table.Cell().Element(container => CellStyle(container, backgroundColor))
                                        .Text(GetEstadoDisplay(atencion.Estado))
                                        .FontSize(8)
                                        .FontColor(GetColorForEstado(atencion.Estado));

                                    static IContainer CellStyle(IContainer container, string background)
                                    {
                                        return container
                                            .Background(background)
                                            .BorderBottom(1)
                                            .BorderColor(Colors.Grey.Lighten2)
                                            .PaddingVertical(5)
                                            .PaddingHorizontal(4);
                                    }
                                }
                            });

                            // Leyenda de estados
                            column.Item().PaddingTop(15).Column(col =>
                            {
                                col.Item().Text("Leyenda de Estados")
                                    .FontSize(10).SemiBold().FontColor(Colors.Blue.Darken1);

                                col.Item().PaddingTop(5).Row(row =>
                                {
                                    row.Spacing(15);

                                    row.AutoItem().Row(r =>
                                    {
                                        r.AutoItem().Width(15).Height(15).Background(Colors.Green.Lighten3);
                                        r.AutoItem().PaddingLeft(5).Text("Otorgada").FontSize(8);
                                    });

                                    row.AutoItem().Row(r =>
                                    {
                                        r.AutoItem().Width(15).Height(15).Background(Colors.Yellow.Lighten3);
                                        r.AutoItem().PaddingLeft(5).Text("En sala de espera").FontSize(8);
                                    });

                                    row.AutoItem().Row(r =>
                                    {
                                        r.AutoItem().Width(15).Height(15).Background(Colors.Blue.Lighten3);
                                        r.AutoItem().PaddingLeft(5).Text("Atendido").FontSize(8);
                                    });
                                });
                            });

                            // Notas
                            column.Item().PaddingTop(20).Column(col =>
                            {
                                col.Item().Text("Notas:")
                                    .FontSize(10).SemiBold().FontColor(Colors.Grey.Darken1);

                                for (int i = 0; i < 5; i++)
                                {
                                    col.Item().PaddingTop(8).BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                                        .Height(15);
                                }
                            });
                        });

                        // Footer
                        page.Footer().Row(row =>
                        {
                            row.RelativeItem().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(8).FontColor(Colors.Grey.Darken1);

                            row.RelativeItem().AlignRight().Text(x =>
                            {
                                x.Span("Página ");
                                x.CurrentPageNumber();
                                x.Span(" de ");
                                x.TotalPages();
                            });
                        });
                    });
                }
            });

            return document.GeneratePdf();
        }

        private byte[] GenerarReporteVacio(DateTime fecha)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.Content().AlignMiddle().AlignCenter().Column(column =>
                    {
                        column.Item().Text("SmileSoft - Sistema de Gestión Odontológica")
                            .FontSize(18).SemiBold().FontColor(Colors.Blue.Darken2);

                        column.Item().PaddingTop(20).Text("Agenda Diaria de Atenciones")
                            .FontSize(16).FontColor(Colors.Grey.Darken2);

                        column.Item().PaddingTop(10).Text($"Fecha: {fecha:dddd, dd 'de' MMMM 'de' yyyy}")
                            .FontSize(12).FontColor(Colors.Grey.Darken1);

                        column.Item().PaddingTop(40).Text("No hay atenciones programadas para este día")
                            .FontSize(14).Italic().FontColor(Colors.Grey.Medium);
                    });

                    page.Footer().AlignCenter().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}")
                        .FontSize(8).FontColor(Colors.Grey.Darken1);
                });
            });

            return document.GeneratePdf();
        }

        private static string GetBackgroundColorForEstado(string estado)
        {
            return estado.ToLower() switch
            {
                "otorgada" => Colors.Green.Lighten3,
                "en sala de espera" => Colors.Yellow.Lighten3,
                "atendido" => Colors.Blue.Lighten3,
                _ => Colors.White
            };
        }

        private static string GetColorForEstado(string estado)
        {
            return estado.ToLower() switch
            {
                "otorgada" => Colors.Green.Darken2,
                "en sala de espera" => Colors.Orange.Darken1,
                "atendido" => Colors.Blue.Darken2,
                _ => Colors.Grey.Darken1
            };
        }

        private static string GetEstadoDisplay(string estado)
        {
            return estado switch
            {
                "Otorgada" => "Pendiente",
                "En sala de espera" => "En espera",
                "Atendido" => "Completado",
                _ => estado
            };
        }

        public Task<byte[]> GenerarReporteAsync(ReporteAtencionesPorOdontologoRequestDTO request)
        {
            return Task.Run(() => GenerarReporte(request));
        }
    }
}