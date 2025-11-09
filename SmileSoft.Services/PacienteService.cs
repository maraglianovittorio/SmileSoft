using SmileSoft.DTO;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System.ComponentModel.DataAnnotations;

namespace SmileSoft.Services
{
    public class PacienteService
    {
        public PacienteDTO Add(PacienteDTO dto)
        {
            var pacienteRepository = new PacienteRepository();
            var personaRepository = new PersonaRepository();
            var usuarioRepository = new UsuarioRepository();
            
            // Validar que la historia clínica no exista
            if (pacienteRepository.HCExists(dto.NroHC))
            {
                throw new Exception("Ya existe un paciente con la misma historia clínica.");
            }
            // Validar que el DNI no exista
            if (personaRepository.DNIExists(dto.NroDni))
            {
                throw new Exception("Ya existe una persona con el mismo DNI.");
            }
            
            // Crear usuario automáticamente para el paciente (username = DNI, password = fecha nacimiento ddMMyyyy)
            Usuario? usuario = null;
            string username = dto.NroDni;
            string password = dto.FechaNacimiento.ToString("ddMMyyyy");
            
            // Check if user already exists
            if (usuarioRepository.UsernameExists(username))
            {
                // Get existing usuario
                usuario = usuarioRepository.GetByUsername(username);
                if (usuario == null)
                {
                    throw new Exception($"El usuario con DNI {dto.NroDni} existe pero no se pudo recuperar.");
                }
            }
            else
            {
                // Create new usuario - don't save it yet, let EF Core cascade it
                usuario = new Usuario(username, password, "Paciente");
            }
            
            // Create Paciente with Usuario object - EF Core will handle the cascade insert
            Paciente paciente = new Paciente(0, dto.Nombre, dto.Apellido, dto.NroDni, 
                dto.Direccion, dto.Email, dto.FechaNacimiento, dto.Telefono, 
                dto.NroAfiliado, dto.NroHC, dto.TutorId, dto.TipoPlanId, 
                usuario?.Id, usuario);

            try
            {
                pacienteRepository.Add(paciente);
                return dto;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                throw new Exception($"Error al guardar en la base de datos: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
        }
        public bool Delete(int id)
        {
            var pacienteRepository = new PacienteRepository();
            //var atencionRepository = new AtencionRepository();
            var paciente = pacienteRepository.Get(id);
            if (paciente == null)
            {
                throw new Exception("No se encontró el paciente.");
            }
            var atencionesDelPaciente = paciente.Atenciones;
            // Verificar si el paciente tiene atenciones asociadas
            if (atencionesDelPaciente != null && atencionesDelPaciente.Any())
            {
                throw new EntidadConDependenciasException("No se puede eliminar el paciente porque tiene atenciones asociadas.");
            }
            
            return pacienteRepository.Delete(id);
        }
        public PacienteDTO GetPaciente(int id)
        {
            var pacienteRepository = new PacienteRepository();
            Paciente? paciente = pacienteRepository.Get(id);
            if (paciente == null)
            {
                throw new Exception("No se encontró el paciente.");
            }
            return new PacienteDTO
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                NroDni = paciente.NroDni,
                Direccion = paciente.Direccion,
                Email = paciente.Email,
                FechaNacimiento = paciente.FechaNacimiento,
                Telefono = paciente.Telefono,
                NroAfiliado = paciente.NroAfiliado,
                NroHC = paciente.NroHC,
                TipoPlanId = paciente.TipoPlanId,
                TutorId = paciente.TutorId,
                UsuarioId = paciente.UsuarioId
            };

        }
        public PacienteDTO? GetByDni(string dni)
        {
            var pacienteRepository = new PacienteRepository();
            Paciente? paciente = pacienteRepository.GetByDni(dni);
            if (paciente == null)
            {
                return null;
            }
            return new PacienteDTO
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                NroDni = paciente.NroDni,
                Direccion = paciente.Direccion,
                Email = paciente.Email,
                FechaNacimiento = paciente.FechaNacimiento,
                Telefono = paciente.Telefono,
                NroAfiliado = paciente.NroAfiliado,
                NroHC = paciente.NroHC,
                TipoPlanId = paciente.TipoPlanId,
                UsuarioId = paciente.UsuarioId
            };
        }
        public IEnumerable<PacienteDTO> GetAll()
        {
            var pacienteRepository = new PacienteRepository();
            var pacientes = pacienteRepository.GetAll();
            return pacientes.Select(p => new PacienteDTO
            {

                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                NroDni = p.NroDni,
                Direccion = p.Direccion,
                Email = p.Email,
                FechaNacimiento = p.FechaNacimiento,
                Telefono = p.Telefono,
                NroAfiliado = p.NroAfiliado,
                NroHC = p.NroHC,
                TipoPlanId = p.TipoPlanId,
                UsuarioId = p.UsuarioId
            }).ToList();
        }
        public bool Update(int id, PacienteDTO dto)
        {
            var pacienteRepository = new PacienteRepository();
            // Validar que la HC no exista en otro paciente
            if (pacienteRepository.HCExists(dto.NroHC, id))
            {
                throw new ArgumentException($"Ya existe otro paciente con la Historia Clínica '{dto.NroHC}'.");
            }

            Paciente paciente = new Paciente(id, dto.Nombre, dto.Apellido, dto.NroDni, dto.Direccion, dto.Email, dto.FechaNacimiento, dto.Telefono, dto.NroAfiliado, dto.NroHC, dto.TutorId, dto.TipoPlanId, dto.UsuarioId, null);
            return pacienteRepository.Update(paciente);

        }
    }
}
