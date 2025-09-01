using Microsoft.AspNetCore.Mvc;
using SmileSoft.Dominio;
using DTO;

namespace SmileSoft.UI.Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> GetPacientes()
        {
            return Ok(Paciente.ListaP);
        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> GetPaciente(int id)
        {
            var paciente = Paciente.ListaP.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        public ActionResult<Paciente> CreatePaciente(PacienteDTO pacienteDTO)
        {
            // Validación de campos obligatorios
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(pacienteDTO.Nombre))
                errores.Add("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(pacienteDTO.Apellido))
                errores.Add("El apellido es obligatorio");

            if (string.IsNullOrWhiteSpace(pacienteDTO.NroDni))
                errores.Add("El DNI es obligatorio");

            if (string.IsNullOrWhiteSpace(pacienteDTO.NroHC))
                errores.Add("El número de historia clínica es obligatorio");

            if (errores.Count > 0)
            {
                return BadRequest(new
                {
                    error = "Datos inválidos",
                    message = "Faltan campos obligatorios",
                    details = errores
                });
            }

            var nuevoID = Paciente.ObtenerProximoID();
            var buscaHC = Paciente.ListaP.FirstOrDefault(p => p.NroHC == pacienteDTO.NroHC);
            if (buscaHC != null)
            {
                return Conflict(new
                {
                    error = "Número de historia clínica duplicado",
                    message = $"Ya existe un paciente con el NroHC {pacienteDTO.NroHC}",
                    field = "NroHC"
                });
            }

            // Crear el paciente con datos limpios (trim)
            var nuevoPaciente = new Paciente(
                nuevoID,
                pacienteDTO.Nombre.Trim(),
                pacienteDTO.Apellido.Trim(),
                pacienteDTO.NroDni.Trim(),
                pacienteDTO.Direccion?.Trim() ?? string.Empty,
                pacienteDTO.Email?.Trim() ?? string.Empty,
                pacienteDTO.FechaNacimiento,
                pacienteDTO.Telefono?.Trim() ?? string.Empty,
                pacienteDTO.NroAfiliado?.Trim() ?? string.Empty,
                pacienteDTO.NroHC.Trim()
            );

            Paciente.ListaP.Add(nuevoPaciente);
            return CreatedAtAction(nameof(GetPaciente), new { id = nuevoID }, nuevoPaciente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePaciente(int id, PacienteDTO pacienteDTO)
        {
            var paciente = Paciente.ListaP.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            var buscaHC = Paciente.ListaP.FirstOrDefault(p => p.NroHC == pacienteDTO.NroHC && p.Id != id);
            if (buscaHC != null)
            {
                return Conflict(new
                {
                    error = "Número de historia clínica duplicado",
                    message = $"Ya existe un paciente con el NroHC {pacienteDTO.NroHC}",
                    field = "NroHC"
                });
            }

            paciente.Nombre = pacienteDTO.Nombre;
            paciente.Apellido = pacienteDTO.Apellido;
            paciente.NroDni = pacienteDTO.NroDni;
            paciente.Direccion = pacienteDTO.Direccion;
            paciente.Email = pacienteDTO.Email;
            paciente.FechaNacimiento = pacienteDTO.FechaNacimiento;
            paciente.Telefono = pacienteDTO.Telefono;
            paciente.NroAfiliado = pacienteDTO.NroAfiliado;
            paciente.NroHC = pacienteDTO.NroHC;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(int id)
        {
            var paciente = Paciente.ListaP.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            Paciente.ListaP.Remove(paciente);
            return NoContent();
        }
    }
}