using DTO;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Services
{
    public class AtencionService
    {
        public AtencionDTO Add(AtencionDTO dto)
        {
            var atencionRepository = new AtencionRepository();
            Atencion atencion = new Atencion(dto.FechaHoraAtencion, dto.Estado, dto.Observaciones, dto.OdontologoId, dto.PacienteId, dto.TipoAtencionId);
            // Validar que la atención no exista
            if (atencionRepository.Get(atencion.Id) != null)
            {
                throw new ArgumentException($"Ya existe una atención con el ID '{atencion.Id}'.");
            }

            atencionRepository.Add(atencion);

            return dto;
        }
        public bool Delete(int id)
        {
            var atencionRepository = new AtencionRepository();
            return atencionRepository.Delete(id);
        }
        public AtencionDTO GetAtencion(int id)
        {
            var atencionRepository = new AtencionRepository();
            Atencion? atencion = atencionRepository.Get(id);
            if (atencion == null)
            {
                throw new Exception("No se encontró la atención.");
            }
            return new AtencionDTO
            {
                OdontologoId = atencion.OdontologoId,
                PacienteId = atencion.PacienteId,
                TipoAtencionId = atencion.TipoAtencionId,
                FechaHoraAtencion = atencion.FechaHoraAtencion,
                Estado = atencion.Estado
            };
        }
        public IEnumerable<AtencionDTO>? GetAtencionesByEstado(string estado)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetByEstado(estado);
            if (atenciones == null || !atenciones.Any())
            {
                return null;
            }
            return atenciones.Select(a => new AtencionDTO
            {
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado
            });
        }
        public IEnumerable<AtencionDTO> GetAllByPaciente(int pacienteId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByPaciente(pacienteId);
            return atenciones.Select(a => new AtencionDTO
            {
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado
            });
        }
        public IEnumerable<AtencionDTO> GetAllByOdontologo(int odontologoId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByOdontologo(odontologoId);
            return atenciones.Select(a => new AtencionDTO
            {
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado
            });
        }
        public IEnumerable<AtencionDTO> GetAllByTipoAtencion(int tipoAtencionId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByTipoAtencion(tipoAtencionId);
            return atenciones.Select(a => new AtencionDTO
            {
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado
            });
        }
        public IEnumerable<AtencionDTO> GetAllByRango(DateTime startDate, DateTime endDate)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByRango(startDate, endDate);
            return atenciones.Select(a => new AtencionDTO
            {
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado
            });
        }
        public IEnumerable<AtencionDTO> GetAll()
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAll();
            return atenciones.Select(a => new AtencionDTO
            {
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado
            });
        }
        public bool Update(int id, AtencionDTO dto)
        {
            var atencionRepository = new AtencionRepository();
            // Validar que la atención no exista
            if (atencionRepository.Get(id) == null)
            {
                throw new ArgumentException($"Ya existe otra atención con el ID '{id}'.");
            }

            Atencion atencion = new Atencion(dto.FechaHoraAtencion, dto.Estado, dto.Observaciones, dto.OdontologoId, dto.PacienteId, dto.TipoAtencionId);
            return atencionRepository.Update(atencion);

        }
    }
}

