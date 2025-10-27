using System;

namespace SmileSoft.DTO
{
    public class ReporteAtencionesOdontologoRequestDTO
    {
        public DateTime Fecha { get; set; }
        
        public ReporteAtencionesOdontologoRequestDTO()
        {
            // Por defecto: día actual
            Fecha = DateTime.Now.Date;
        }
    }
}