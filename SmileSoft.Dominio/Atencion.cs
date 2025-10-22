using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class Atencion
    {
        public int Id { get; private set; }
        public DateTime FechaHoraAtencion { get; private set; }
        public string Estado { get; private set; } = "Otorgada";// Los estados posibles son: "Otorgada", "En espera","Cancelada" y "Finalizada"
        public string Observaciones { get; private set; } = string.Empty;
        public int OdontologoId { get; private set; } 
        public Odontologo Odontologo { get; private set; }
        public int PacienteId { get; private set; }
        public Paciente Paciente { get; private set; }
        public int TipoAtencionId { get; private set; }
        public TipoAtencion TipoAtencion { get; private set; }
        public Atencion(DateTime fechaHoraAtencion,string estado,string observaciones,int odontologoId,int pacienteId,int tipoAtencionId)
        {
            SetFechaHoraAtencion(fechaHoraAtencion);
            SetEstado(estado);
            SetObservaciones(observaciones);
            SetOdontologoId(odontologoId);
            SetPacienteId(pacienteId);
            SetTipoAtencionId(tipoAtencionId);
        }
        public void SetFechaHoraAtencion(DateTime fechaHoraAtencion)
        {
            //if (fechaHoraAtencion < DateTime.Now)
            //{
            //    throw new ArgumentException("La fecha y hora de atención no puede ser en el pasado.");
            //} Agregamos esta validacion?

            FechaHoraAtencion = fechaHoraAtencion;
        }
        public void SetEstado(string estado)
        {
            Estado = estado;
        }
        public void SetObservaciones(string observaciones)
        {
            // hago append para no perder las observaciones anteriores 
            Observaciones += observaciones ?? string.Empty;
        }
        public void SetOdontologoId(int odontologoId)
        {
            if (odontologoId <= 0)
            {
                throw new ArgumentException("El Id del odontólogo debe ser un número positivo.");
            }
            OdontologoId = odontologoId;
        }
        public void SetPacienteId(int pacienteId)
        {
            if (pacienteId <= 0)
            {
                throw new ArgumentException("El Id del paciente debe ser un número positivo.");
            }
            PacienteId = pacienteId;
        }
        public void SetTipoAtencionId(int tipoAtencionId)
        {
            if (tipoAtencionId <= 0)
            {
                throw new ArgumentException("El Id del tipo de atención debe ser un número positivo.");
            }
            TipoAtencionId = tipoAtencionId;
        }
    }
}
