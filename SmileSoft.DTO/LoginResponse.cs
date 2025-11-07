using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.DTO
{
    public class LoginResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        
        // Datos adicionales del odontólogo (si aplica)
        public int? OdontologoId { get; set; }
        public string? OdontologoNombre { get; set; }
        public string? OdontologoApellido { get; set; }

        // Datos adicionales del paciente (si aplica)
        public int? PacienteId { get; set; }
        public string? PacienteNombre { get; set; }
        public string? PacienteApellido { get; set; }
        public string? NroHistoriaClinica { get; set; }

    }
}
