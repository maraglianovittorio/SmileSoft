using System;

namespace SmileSoft.DTO
{
    /// <summary>
    /// DTO that contains only time slot information without exposing patient data
    /// </summary>
    public class HorarioDisponibleDTO
    {
        public string Horario { get; set; } = string.Empty;
        public bool Disponible { get; set; }
    }
}
