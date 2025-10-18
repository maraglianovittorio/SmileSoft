namespace SmileSoft.Dominio
{
    public class Odontologo:Persona
    {
        public string NroMatricula { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public string Rol { get; set; } = "Odontologo";
        public ICollection<ObraSocial> ObrasSociales { get; set; } = new List<ObraSocial>();
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public ICollection<Atencion> Atenciones { get; set; } = new List<Atencion>();
        public Odontologo(int id, string nombre, string apellido, string nroDni, DateTime fechaNacimiento, string direccion, string email, string telefono,string nroMatricula): base(id,nombre, apellido, nroDni,fechaNacimiento,direccion, email, telefono)
        {
            NroMatricula = nroMatricula;
            //Username = username;
            //Password = password;
        }


    }
}
