using System;

namespace SmileSoft.DTO
{
    public class ReporteAtencionesHorarioRequestDTO
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        
        public ReporteAtencionesHorarioRequestDTO()
        {
            // Por defecto: último mes
            FechaHasta = DateTime.Now;
            FechaDesde = DateTime.Now.AddMonths(-1);
        }
    }
}