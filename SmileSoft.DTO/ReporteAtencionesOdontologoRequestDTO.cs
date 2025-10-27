using System;

namespace SmileSoft.DTO
{
    public class ReporteAtencionesOdontologoRequestDTO
    {
        public DateTime Fecha { get; set; }
        
        public ReporteAtencionesOdontologoRequestDTO()
        {
            // Por defecto: d�a actual
            Fecha = DateTime.Now.Date;
        }
    }
}