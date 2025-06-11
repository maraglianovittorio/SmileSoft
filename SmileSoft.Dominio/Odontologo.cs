namespace SmileSoft.Dominio
{
    public class Odontologo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroMatricula { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public ICollection<Atencion> Atenciones { get; set; }
    }
}
