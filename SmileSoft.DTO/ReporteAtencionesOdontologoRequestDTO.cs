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
    public class ReporteAtencionesPorOdontologoRequestDTO
    { 
        public DateTime Fecha { get; set; }
        public int IdOdo { get; set; }
        public ReporteAtencionesPorOdontologoRequestDTO(DateTime fecha, int idOdo)
        {
            // Por defecto: d�a actual
            Fecha = DateTime.Now.Date;
            IdOdo = idOdo;
        }

    }

}