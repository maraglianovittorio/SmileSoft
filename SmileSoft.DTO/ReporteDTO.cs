using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmileSoft.DTO
{
    public class ReportePacientesRequestDTO
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public bool IncluirSoloConOS { get; set; }
        public int? ObraSocialId { get; set; }
    }

    public class ReporteAtencionesRequestDTO
    {
        [Required(ErrorMessage = "La fecha desde es obligatoria")]
        public DateTime FechaDesde { get; set; }
        
        [Required(ErrorMessage = "La fecha hasta es obligatoria")]
        public DateTime FechaHasta { get; set; }
        
        public int? OdontologoId { get; set; }
        public string? Estado { get; set; }
        public int? TipoAtencionId { get; set; }
    }

    public class ReporteResponseDTO
    {
        public byte[] PdfBytes { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = "application/pdf";
        public int TotalRegistros { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }

    public class ReporteHistogramaAtencionesRequestDTO
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        public ReporteHistogramaAtencionesRequestDTO()
        {
            // Por defecto: último mes
            FechaHasta = DateTime.Today;
            FechaDesde = DateTime.Today.AddMonths(-1);
        }
    }

}