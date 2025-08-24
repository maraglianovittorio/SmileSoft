using DTO;
using SmileSoft.Dominio;
namespace SmileSoft.Services
{
    public class PacienteService
    {
        public PacienteDTO Add(PacienteDTO dto)
        {
            var listaPaciente = Paciente.ListaP;

            // Validar que la historia clínica no exista
            var existeHC = listaPaciente.Any(p => p.NroHC == dto.NroHC);
            if (existeHC)
            {
                throw new Exception("Ya existe un paciente con la misma historia clínica.");
            }
            var idPaciente = Paciente.ObtenerProximoID();
            Paciente cliente = new Paciente(idPaciente,dto.Nombre,dto.Apellido,dto.NroDni,dto.Direccion,dto.Email,dto.FechaNacimiento,dto.Telefono,dto.NroAfiliado,dto.NroHC);

            listaPaciente.Add(cliente);

            return dto;
        }
        public bool Delete(int id)
        {
            var listaPaciente = Paciente.ListaP;
            var paciente = listaPaciente.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return false; // No se encontró el paciente
            }
            listaPaciente.Remove(paciente);
            return true; // Paciente eliminado exitosamente
        }
        public PacienteDTO GetPaciente(int id)
        {
            var listaPaciente = Paciente.ListaP;
            var paciente = listaPaciente.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return null; // No se encontró el paciente
            }
            var pacienteDTO = new PacienteDTO
            {
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                NroDni = paciente.NroDni,
                Direccion = paciente.Direccion,
                Email = paciente.Email,
                FechaNacimiento = paciente.FechaNacimiento,
                Telefono = paciente.Telefono,
                NroAfiliado = paciente.NroAfiliado,
                NroHC = paciente.NroHC
            };
            return pacienteDTO;

        }
        public List<PacienteDTO> GetAll()
        {
            var listaPaciente = Paciente.ListaP;
            var listaPacienteDTO = listaPaciente.Select(p => new PacienteDTO
            {
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                NroDni = p.NroDni,
                Direccion = p.Direccion,
                Email = p.Email,
                FechaNacimiento = p.FechaNacimiento,
                Telefono = p.Telefono,
                NroAfiliado = p.NroAfiliado,
                NroHC = p.NroHC
            }).ToList();
            return listaPacienteDTO;
        }
        public bool Update(int id, PacienteDTO dto)
        {
            var listaPaciente = Paciente.ListaP;
            var paciente = listaPaciente.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return false; // No se encontró el paciente
            }
            //validar que la historia clinica no exista en otro paciente
            var existeHC = listaPaciente.Any(p => p.NroHC == dto.NroHC && p.Id != id);
            if (existeHC)
            {
                throw new Exception("Ya existe un paciente con la misma historia clínica.");
            }
            // Actualizar los campos del paciente
            paciente.Nombre = dto.Nombre;
            paciente.Apellido = dto.Apellido;
            paciente.NroDni = dto.NroDni;
            paciente.Direccion = dto.Direccion;
            paciente.Email = dto.Email;
            paciente.FechaNacimiento = dto.FechaNacimiento;
            paciente.Telefono = dto.Telefono;
            paciente.NroAfiliado = dto.NroAfiliado;
            paciente.NroHC = dto.NroHC;
            return true; // Paciente actualizado exitosamente
        }
    }
}
