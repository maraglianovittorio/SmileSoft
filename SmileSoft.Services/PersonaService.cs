using DTO;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System.ComponentModel.DataAnnotations;

namespace SmileSoft.Services
{
    public class PersonaService
    {
        public PersonaDTO Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();
            if (personaRepository.DNIExists(dto.NroDni))
            {
                throw new Exception("Ya existe una persona con el mismo DNI.");
            }
            Persona persona = new Persona(0,dto.Nombre,dto.Apellido,dto.NroDni,dto.FechaNacimiento,dto.Direccion,dto.Email,dto.Telefono);

            personaRepository.Add(persona);

            return dto;
        }
        public bool Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.Delete(id);
        }
        public PersonaDTO GetPersona(int id)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.Get(id);
            if (persona == null)
            {
                throw new Exception("No se encontró la persona.");
            }
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                NroDni = persona.NroDni,
                Direccion = persona.Direccion,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                Telefono = persona.Telefono
            };

        }
        public PersonaDTO? GetByDni(string dni)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.GetByDni(dni);
            if (persona == null)
            {
                return null;
            }
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                NroDni = persona.NroDni,
                Direccion = persona.Direccion,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                Telefono = persona.Telefono
            };
        }
        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            var personas = personaRepository.GetAll();
            return personas.Select(p => new PersonaDTO
            {

                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                NroDni = p.NroDni,
                Direccion = p.Direccion,
                Email = p.Email,
                FechaNacimiento = p.FechaNacimiento,
                Telefono = p.Telefono,
            }).ToList();
        }
        public IEnumerable<PersonaDTO> GetTutores()
        {
            var personaRepository = new PersonaRepository();
            var tutores = personaRepository.GetAllTutors();
            return tutores.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                NroDni = p.NroDni,
                Direccion = p.Direccion,
                Email = p.Email,
                FechaNacimiento = p.FechaNacimiento,
                Telefono = p.Telefono,
            }).ToList();
        }
        public bool Update(int id, PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();
            // Validar que el DNI no exista en otra persona
            if (personaRepository.DNIExists(dto.NroDni, id))
            {
                throw new ArgumentException($"Ya existe otra persona con el DNI '{dto.NroDni}'.");
            }

            Persona persona = new Persona(id, dto.Nombre, dto.Apellido, dto.NroDni, dto.FechaNacimiento, dto.Email, dto.Direccion, dto.Telefono);
            return personaRepository.Update(persona);

        }
        public PersonaDTO? GetTutorByDni(string dni)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.GetTutorByDni(dni);
            if (persona == null)
            {
                return null;
            }
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                NroDni = persona.NroDni,
                Direccion = persona.Direccion,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                Telefono = persona.Telefono
            };
        }
    }
}
