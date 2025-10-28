namespace SmileSoft.Dominio
{
    public class Odontologo:Persona
    {
        public string NroMatricula { get; private set; }
        public ICollection<ObraSocial> ObrasSociales { get; private set; } = new List<ObraSocial>();
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public ICollection<Atencion> Atenciones { get; private set; } = new List<Atencion>();
        public Usuario? Usuario { get; private set; }
        public int? UsuarioId { get; private set; } // FK
        public Odontologo():base()
        {
        }

        //public string Rol { get; set; } = "Odontologo";
        public Odontologo(int id, string nombre, string apellido, string nroDni, DateTime fechaNacimiento, string direccion, string email, string telefono,string nroMatricula,Usuario? usuario): base(id,nombre, apellido, nroDni,fechaNacimiento,direccion, email, telefono)
        {
            SetNroMatricula(nroMatricula);
            SetUsuario(usuario);

        }
        public void SetNroMatricula(string nroMatricula)
        {
            if (string.IsNullOrWhiteSpace(nroMatricula))
            {
                throw new ArgumentException("El número de matrícula no puede estar vacío.");
            }
            NroMatricula = nroMatricula;
        }
        public void SetUsuario(Usuario? usuario)
        {
            if (usuario == null)
            {
                return;
            }
            Usuario = usuario;
        }


    }
}
