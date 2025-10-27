using SmileSoft.DTO;
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
        public HistoriaClinicaDTO GetHistoriaClinica(int pacienteId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByPaciente(pacienteId);
            if (atenciones == null || !atenciones.Any())
            {
                return null;
            }
            var paciente = atenciones.First().Paciente;
            if (paciente == null)
            {
                return null;
            }
            var historiaClinicaDTO = new HistoriaClinicaDTO
            {
                PacienteId = paciente.Id,
                PacienteNombre = paciente.Nombre,
                PacienteApellido = paciente.Apellido,
                PacienteDni = paciente.NroDni,
                Observaciones = atenciones
                    .Where(a => !string.IsNullOrEmpty(a.Observaciones))
                    .Select(a => a.Observaciones)
                    .ToList()
            };
            return historiaClinicaDTO;
        }
        public AtencionSecretarioDTO? GetOneForSecretario(int id)
        {
            var atencionRepository = new AtencionRepository();
            Atencion? atencion = atencionRepository.Get(id);
            if (atencion == null)
            {
                throw new Exception("No se encontró la atención.");
            }
            return new AtencionSecretarioDTO
            {
                Id = atencion.Id,
                OdontologoId = atencion.OdontologoId,
                PacienteId = atencion.PacienteId,
                TipoAtencionId = atencion.TipoAtencionId,
                FechaHoraAtencion = atencion.FechaHoraAtencion,
                Estado = atencion.Estado,
                PacienteNombre = atencion.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = atencion.Paciente?.Apellido ?? string.Empty,
                PacienteDni = atencion.Paciente?.NroDni ?? string.Empty
            };
        }
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
        
        public AtencionDetalleDTO GetAtencion(int id)
        {
            var atencionRepository = new AtencionRepository();
            Atencion? atencion = atencionRepository.Get(id);
            if (atencion == null)
            {
                throw new Exception("No se encontró la atención.");
            }
            return new AtencionDetalleDTO
            {
                Id = atencion.Id,
                OdontologoId = atencion.OdontologoId,
                PacienteId = atencion.PacienteId,
                TipoAtencionId = atencion.TipoAtencionId,
                FechaHoraAtencion = atencion.FechaHoraAtencion,
                Estado = atencion.Estado,
                Observaciones = atencion.Observaciones,
                PacienteNombre = atencion.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = atencion.Paciente?.Apellido ?? string.Empty,
                PacienteDni = atencion.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = atencion.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = atencion.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = atencion.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = atencion.TipoAtencion?.Duracion ?? TimeSpan.Zero
            };
        }
        
        public IEnumerable<AtencionDetalleDTO>? GetAtencionesByEstado(string estado)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetByEstado(estado);
            if (atenciones == null || !atenciones.Any())
            {
                return null;
            }
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }
        
        public IEnumerable<AtencionDetalleDTO> GetAllByPaciente(int pacienteId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByPaciente(pacienteId);
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }
        
        public IEnumerable<AtencionDetalleDTO> GetAllByOdontologo(int odontologoId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByOdontologo(odontologoId);
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }
        
        public IEnumerable<AtencionDetalleDTO> GetAllByTipoAtencion(int tipoAtencionId)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByTipoAtencion(tipoAtencionId);
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }
        
        public IEnumerable<AtencionDetalleDTO> GetAllByRango(DateTime startDate, DateTime endDate)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByRango(startDate, endDate);
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }

        public IEnumerable<AtencionDetalleDTO> GetAllByRangoAndOdo(DateTime startDate, DateTime endDate,int id)
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAllByRangoAndOdo(startDate, endDate,id);
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }

        public IEnumerable<AtencionDetalleDTO> GetAll()
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAll();
            return atenciones.Select(a => new AtencionDetalleDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                Observaciones = a.Observaciones,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty,
                OdontologoNombre = a.Odontologo?.Nombre ?? string.Empty,
                OdontologoApellido = a.Odontologo?.Apellido ?? string.Empty,
                TipoAtencionDescripcion = a.TipoAtencion?.Descripcion ?? string.Empty,
                TipoAtencionDuracion = a.TipoAtencion?.Duracion ?? TimeSpan.Zero
            });
        }
        public IEnumerable<AtencionSecretarioDTO> GetAllAtencionesSecretario()
        {
            var atencionRepository = new AtencionRepository();
            var atenciones = atencionRepository.GetAll();
            return atenciones.Select(a => new AtencionSecretarioDTO
            {
                Id = a.Id,
                OdontologoId = a.OdontologoId,
                PacienteId = a.PacienteId,
                TipoAtencionId = a.TipoAtencionId,
                FechaHoraAtencion = a.FechaHoraAtencion,
                Estado = a.Estado,
                PacienteNombre = a.Paciente?.Nombre ?? string.Empty,
                PacienteApellido = a.Paciente?.Apellido ?? string.Empty,
                PacienteDni = a.Paciente?.NroDni ?? string.Empty
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
            return atencionRepository.Update(atencion,id);
        }
        public bool CancelaAtencion(int id)
        {
      
            var atencionRepository = new AtencionRepository();
            // Validar que la atención exista
            var atencion = atencionRepository.Get(id);
            if (atencion == null)
            {
                throw new ArgumentException($"No se encontró la atención con el ID '{id}'.");
            }
            return atencionRepository.CancelaAtencion(id);
        }
        public bool ActualizaLlegada(int id)
        {
            var atencionRepository = new AtencionRepository();
            // Validar que la atención exista
            var atencion = atencionRepository.Get(id);
            if (atencion == null)
            {
                throw new ArgumentException($"No se encontró la atención con el ID '{id}'.");
            }
            return atencionRepository.ActualizaLlegada(id);
        }
        public bool UpdateObservaciones(int id, string observaciones)
        {
            // Validate observaciones
            if (observaciones == null)
            {
                throw new ArgumentNullException(nameof(observaciones), "Las observaciones no pueden ser nulas.");
            }

            const int MaxLength = 5000; // ajustar
            if (observaciones.Length > MaxLength)
            {
                throw new ArgumentException($"Las observaciones no pueden exceder {MaxLength} caracteres.", nameof(observaciones));
            }

            var atencionRepository = new AtencionRepository();
            // Validar que la atención exista
            var atencion = atencionRepository.Get(id);
            if (atencion == null)
            {
                throw new ArgumentException($"No se encontró la atención con el ID '{id}'.");
            }
            return atencionRepository.UpdateObservaciones(id, observaciones);
        }
    }
}

