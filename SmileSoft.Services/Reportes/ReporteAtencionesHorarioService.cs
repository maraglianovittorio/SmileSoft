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
    public class ReporteAtencionesHorarioService : IReporteService<ReporteAtencionesHorarioRequestDTO>
    {
        public byte[] GenerarReporte(ReporteAtencionesHorarioRequestDTO request)
        {
            var atencionRepository = new AtencionRepository();
            
            // Establecer fechas por defecto si no se proporcionan
            var fechaDesde = request.FechaDesde ?? DateTime.Now.AddMonths(-1);
            var fechaHasta = request.FechaHasta ?? DateTime.Now;
            
            // Obtener atenciones en el rango de fechas
            var atenciones = atencionRepository.GetAllByRango(fechaDesde, fechaHasta)
                .Where(a => a.Estado != "Cancelada") // Excluir canceladas
                .ToList();

            // Agrupar por franja horaria (bloques de 30 minutos desde 8:00 a 16:30)
            var franjaHoraria = new Dictionary<string, int>();
            
            // Inicializar todas las franjas horarias
            for (int hora = 8; hora <= 16; hora++)
            {
                franjaHoraria[$"{hora:00}:00"] = 0;
                if (hora < 16 || (hora == 16)) // Incluir 16:30
                {
                    franjaHoraria[$"{hora:00}:30"] = 0;
                }
            }

            // Contar atenciones por franja horaria
            foreach (var atencion in atenciones)
            {
                var hora = atencion.FechaHoraAtencion.Hour;
                var minuto = atencion.FechaHoraAtencion.Minute;
                
                // Redondear a la franja horaria más cercana
                string franja;
                if (minuto < 30)
                {
                    franja = $"{hora:00}:00";
                }
                else
                {
                    franja = $"{hora:00}:30";
                }
                
                if (franjaHoraria.ContainsKey(franja))
                {
                    franjaHoraria[franja]++;
                }
            }

            // Encontrar el máximo para escalar el gráfico
            int maxAtenciones = franjaHoraria.Values.Max();
            if (maxAtenciones == 0) maxAtenciones = 1; // Evitar división por cero

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    // Header
                    page.Header().Column(column =>
                    {
                        column.Item().Text("SmileSoft - Sistema de Gestión Odontológica")
                            .FontSize(16).SemiBold().FontColor(Colors.Blue.Darken2);
                        column.Item().Text("Reporte de Atenciones por Horario")
                            .FontSize(12).FontColor(Colors.Grey.Darken2);
                        column.Item().PaddingTop(3).Text($"Período: {fechaDesde:dd/MM/yyyy} - {fechaHasta:dd/MM/yyyy}")
                            .FontSize(9).Italic().FontColor(Colors.Grey.Darken1);
                        column.Item().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .FontSize(8).FontColor(Colors.Grey.Darken1);
                    });

                    // Content
                    page.Content().PaddingVertical(0.5f, Unit.Centimetre).Column(column =>
                    {
                        column.Spacing(10);

                        // Resumen
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text($"Total de atenciones: {atenciones.Count}")
                                    .FontSize(10).SemiBold().FontColor(Colors.Blue.Darken1);
                                
                                var horarioMasOcupado = franjaHoraria.OrderByDescending(x => x.Value).First();
                                col.Item().Text($"Horario más ocupado: {horarioMasOcupado.Key} hs ({horarioMasOcupado.Value} atenciones)")
                                    .FontSize(9).FontColor(Colors.Grey.Darken1);
                            });
                        });

                        column.Item().PaddingTop(5).Text("Histograma de Atenciones por Franja Horaria")
                            .FontSize(11).SemiBold().FontColor(Colors.Blue.Darken1);

                        // Histograma con tabla más compacta
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(60);  // Horario
                                columns.RelativeColumn(3);   // Barra
                                columns.ConstantColumn(40);  // Cantidad
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("Horario");
                                header.Cell().Element(HeaderStyle).Text("Atenciones");
                                header.Cell().Element(HeaderStyle).AlignCenter().Text("Total");

                                static IContainer HeaderStyle(IContainer container)
                                {
                                    return container
                                        .DefaultTextStyle(x => x.SemiBold().FontSize(8))
                                        .Background(Colors.Blue.Lighten3)
                                        .PaddingVertical(4)
                                        .PaddingHorizontal(3)
                                        .BorderBottom(1)
                                        .BorderColor(Colors.Blue.Darken1);
                                }
                            });

                            // Filas del histograma
                            foreach (var franja in franjaHoraria.OrderBy(x => x.Key))
                            {
                                var cantidad = franja.Value;
                                var porcentaje = maxAtenciones > 0 ? (float)cantidad / maxAtenciones : 0;

                                table.Cell().Element(CellStyle).Text(franja.Key).FontSize(7);
                                
                                // Barra del histograma
                                table.Cell().Element(CellStyle).Row(row =>
                                {
                                    if (porcentaje > 0)
                                    {
                                        row.RelativeItem(porcentaje)
                                            .Height(12)
                                            .Background(GetColorForValue(cantidad, maxAtenciones));
                                    }
                                    
                                    if (porcentaje < 1)
                                    {
                                        row.RelativeItem(1 - porcentaje)
                                            .Height(12);
                                    }
                                });

                                table.Cell().Element(CellStyle).AlignCenter().Text($"{cantidad}").FontSize(7).SemiBold();

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container
                                        .BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten2)
                                        .PaddingVertical(3)
                                        .PaddingHorizontal(2);
                                }
                            }
                        });

                        // Leyenda de colores (más compacta)
                        column.Item().PaddingTop(8).Row(row =>
                        {
                            row.Spacing(8);
                            
                            row.AutoItem().Row(r =>
                            {
                                r.AutoItem().Width(12).Height(12).Background(Colors.Green.Lighten1);
                                r.AutoItem().PaddingLeft(3).Text("Baja").FontSize(7);
                            });
                            
                            row.AutoItem().Row(r =>
                            {
                                r.AutoItem().Width(12).Height(12).Background(Colors.Orange.Lighten1);
                                r.AutoItem().PaddingLeft(3).Text("Media").FontSize(7);
                            });
                            
                            row.AutoItem().Row(r =>
                            {
                                r.AutoItem().Width(12).Height(12).Background(Colors.Red.Lighten1);
                                r.AutoItem().PaddingLeft(3).Text("Alta").FontSize(7);
                            });
                        });

                        // Análisis
                        column.Item().PaddingTop(10).Column(col =>
                        {
                            col.Item().Text("Análisis y Recomendaciones")
                                .FontSize(10).SemiBold().FontColor(Colors.Blue.Darken1);
                            
                            var horariosPico = franjaHoraria
                                .Where(x => x.Value >= maxAtenciones * 0.7)
                                .OrderByDescending(x => x.Value)
                                .Take(3);
                            
                            var horariosValle = franjaHoraria
                                .Where(x => x.Value <= maxAtenciones * 0.3)
                                .OrderBy(x => x.Value)
                                .Take(3);

                            if (horariosPico.Any())
                            {
                                col.Item().PaddingTop(3).Text(text =>
                                {
                                    text.Span("Horarios pico: ").FontSize(8).SemiBold();
                                    text.Span(string.Join(", ", horariosPico.Select(x => $"{x.Key} ({x.Value})"))).FontSize(8);
                                });
                            }

                            if (horariosValle.Any())
                            {
                                col.Item().Text(text =>
                                {
                                    text.Span("Menor demanda: ").FontSize(8).SemiBold();
                                    text.Span(string.Join(", ", horariosValle.Select(x => $"{x.Key} ({x.Value})"))).FontSize(8);
                                });
                            }
                        });
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

        private static string GetColorForValue(int value, int max)
        {
            if (max == 0) return Colors.Grey.Lighten2;
            
            var ratio = (float)value / max;
            
            if (ratio >= 0.7) return Colors.Red.Lighten1;      // Alta ocupación
            if (ratio >= 0.4) return Colors.Orange.Lighten1;   // Media ocupación
            return Colors.Green.Lighten1;                       // Baja ocupación
        }

        public Task<byte[]> GenerarReporteAsync(ReporteAtencionesHorarioRequestDTO request)
        {
            return Task.Run(() => GenerarReporte(request));
        }
    }
}