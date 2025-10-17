namespace SmileSoft.Dominio
{
    public class Odontologo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroMatricula { get; set; }
        public string Email { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public string Rol { get; set; } = "Odontologo";
        public ICollection<ObraSocial> ObrasSociales { get; set; } = new List<ObraSocial>();
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public Odontologo(int id, string nombre, string apellido, string nroMatricula, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NroMatricula = nroMatricula;
            Email = email;
            //Username = username;
            //Password = password;
            //ObrasSociales = obrasSociales;
        }

        //public ICollection<Atencion> Atenciones { get; set; }
    }
}
