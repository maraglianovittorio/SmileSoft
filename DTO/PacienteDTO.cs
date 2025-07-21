namespace DTO
{
    public class PacienteDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NroDni { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string NroAfiliado { get; set; } = string.Empty;
        public string NroHC { get; set; } = string.Empty;
    }
}
