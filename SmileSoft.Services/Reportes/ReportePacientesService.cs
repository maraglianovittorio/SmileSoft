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
    public class ReportePacientesService : IReporteService<ReportePacientesRequestDTO>
    {
        public byte[] GenerarReporte(ReportePacientesRequestDTO request)
        {
            var pacienteRepository = new PacienteRepository();
            var pacientes = pacienteRepository.GetAll().ToList();

            // Aplicar filtros
            if (request.FechaDesde.HasValue)
            {
                pacientes = pacientes.Where(p => p.FechaNacimiento >= request.FechaDesde.Value).ToList();
            }

            if (request.FechaHasta.HasValue)
            {
                pacientes = pacientes.Where(p => p.FechaNacimiento <= request.FechaHasta.Value).ToList();
            }

            if (request.IncluirSoloConOS)
            {
                pacientes = pacientes.Where(p => p.TipoPlanId.HasValue && p.TipoPlanId.Value > 0).ToList();
            }

            // Convertir a DTOs para el reporte
            var pacientesDto = pacientes.Select(p => new PacienteDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                NroDni = p.NroDni,
                Email = p.Email,
                Telefono = p.Telefono,
                Direccion = p.Direccion,
                FechaNacimiento = p.FechaNacimiento,
                NroHC = p.NroHC,
                NroAfiliado = p.NroAfiliado ?? "Sin OS",
                TipoPlanId = p.TipoPlanId,
                TutorId = p.TutorId
            }).ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    // Header
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().Text("SmileSoft - Sistema de Gestión Odontológica")
                                .FontSize(18).SemiBold().FontColor(Colors.Blue.Darken2);
                            column.Item().Text("Reporte de Pacientes")
                                .FontSize(14).FontColor(Colors.Grey.Darken2);
                            
                            if (request.FechaDesde.HasValue || request.FechaHasta.HasValue)
                            {
                                var filtro = "Período: ";
                                if (request.FechaDesde.HasValue)
                                    filtro += $"desde {request.FechaDesde.Value:dd/MM/yyyy} ";
                                if (request.FechaHasta.HasValue)
                                    filtro += $"hasta {request.FechaHasta.Value:dd/MM/yyyy}";
                                
                                column.Item().PaddingTop(5).Text(filtro)
                                    .FontSize(10).Italic().FontColor(Colors.Grey.Darken1);
                            }
                        });

                        row.ConstantItem(120).AlignRight().Column(column =>
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

                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Total de pacientes: {pacientesDto.Count}")
                                .FontSize(11).SemiBold().FontColor(Colors.Blue.Darken1);
                            
                            if (request.IncluirSoloConOS)
                            {
                                row.RelativeItem().AlignRight()
                                    .Text("Filtro: Solo pacientes con Obra Social")
                                    .FontSize(9).Italic().FontColor(Colors.Grey.Darken1);
                            }
                        });

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(70);  // Nro HC
                                columns.RelativeColumn(1.2f); // Apellido
                                columns.RelativeColumn(1.2f); // Nombre
                                columns.ConstantColumn(70);   // DNI
                                columns.ConstantColumn(65);   // Edad
                                columns.ConstantColumn(80);   // Teléfono
                                columns.RelativeColumn(1.5f); // Email
                                columns.ConstantColumn(90);   // Obra Social
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("Nro HC");
                                header.Cell().Element(HeaderStyle).Text("Apellido");
                                header.Cell().Element(HeaderStyle).Text("Nombre");
                                header.Cell().Element(HeaderStyle).Text("DNI");
                                header.Cell().Element(HeaderStyle).Text("Edad");
                                header.Cell().Element(HeaderStyle).Text("Teléfono");
                                header.Cell().Element(HeaderStyle).Text("Email");
                                header.Cell().Element(HeaderStyle).Text("Obra Social");

                                static IContainer HeaderStyle(IContainer container)
                                {
                                    return container
                                        .DefaultTextStyle(x => x.SemiBold().FontSize(9))
                                        .Background(Colors.Blue.Lighten3)
                                        .PaddingVertical(6)
                                        .PaddingHorizontal(4)
                                        .BorderBottom(2)
                                        .BorderColor(Colors.Blue.Darken1);
                                }
                            });

                            // Rows
                            foreach (var paciente in pacientesDto)
                            {
                                var edad = DateTime.Now.Year - paciente.FechaNacimiento.Year;
                                if (DateTime.Now < paciente.FechaNacimiento.AddYears(edad))
                                    edad--;

                                table.Cell().Element(CellStyle).Text(paciente.NroHC).FontSize(8);
                                table.Cell().Element(CellStyle).Text(paciente.Apellido).FontSize(8);
                                table.Cell().Element(CellStyle).Text(paciente.Nombre).FontSize(8);
                                table.Cell().Element(CellStyle).Text(paciente.NroDni).FontSize(8);
                                table.Cell().Element(CellStyle).Text($"{edad} años").FontSize(8);
                                table.Cell().Element(CellStyle).Text(paciente.Telefono ?? "N/A").FontSize(8);
                                table.Cell().Element(CellStyle).Text(paciente.Email ?? "N/A").FontSize(8);
                                table.Cell().Element(CellStyle).Text(paciente.NroAfiliado).FontSize(8);

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container
                                        .BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten2)
                                        .PaddingVertical(5)
                                        .PaddingHorizontal(4);
                                }
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

        public Task<byte[]> GenerarReporteAsync(ReportePacientesRequestDTO request)
        {
            return Task.Run(() => GenerarReporte(request));
        }
    }
}

// Add at the beginning of your application startup
