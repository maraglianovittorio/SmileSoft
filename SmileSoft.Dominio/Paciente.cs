using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class Paciente: Persona
    {
        //public DateTime FechaNacimiento { get; set; }
        public string NroAfiliado { get; private set; } = string.Empty;
        public string NroHC { get; private set; }
        //public string NroDni { get; set; }

        public int? TutorId { get; private set; } = 0;
        public Persona? Tutor { get; private set; } = null;
        public int? TipoPlanId { get; private set; }
        public TipoPlan? TipoPlan { get; private set; }
        public ICollection<Atencion> Atenciones { get; private set; } = new List<Atencion>();

        public Paciente(int id, string nombre, string apellido, string nroDni, string direccion, string email, DateTime fechaNacimiento, string telefono, string nroAfiliado, string nroHC,int? tutorId,int? tipoPlanId):base(id,nombre,apellido,nroDni,fechaNacimiento,direccion,email,telefono)
        {
            SetNroAfiliado(nroAfiliado);
            SetNroHC(nroHC);
            SetTutorId(tutorId);
            SetTipoPlanId(tipoPlanId);
        }
        public void SetNroAfiliado(string? nroAfiliado)
        {
            NroAfiliado = nroAfiliado;
        }
        public void SetNroHC(string nroHC)
        {
            if (string.IsNullOrWhiteSpace(nroHC))
            {
                throw new ArgumentException("El número de historia clínica no puede estar vacío.");
            }
            NroHC = nroHC;
        }
        public void SetTutorId(int? tutorId)
        {
            TutorId = tutorId;
        }
        public void SetTipoPlanId(int? tipoPlanId)
        {
            TipoPlanId = tipoPlanId;
        }
        public Paciente():base() { }

    }
}
