using SmileSoft.Dominio;
using DTO;
namespace SmileSoft.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            //Paciente.ListaP.Add(new Paciente(1, "Vittorio", "Maragliano", "Iriondo", 1));
            //Paciente.ListaP.Add(new Paciente(2, "Guido", "Maragliano", "Iriondo", 2));
            app.MapGet("/", () => $"Ir a /swagger para probar");
            app.MapGet("/pacientes", () => Paciente.ListaP)
                .WithName("GetPacientes");
            app.MapGet($"pacientes/id", (int id) =>
            {
                var paciente = Paciente.ListaP.FirstOrDefault(p => p.Id == id);
                return paciente is not null ? Results.Ok(paciente) : Results.NotFound();

            })
            .WithName("Get Paciente");
            app.MapPost("/pacientes", (PacienteDTO pacienteDTO) =>
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
                    return Results.BadRequest(new
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
                    return Results.Conflict(new
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
                return Results.Created($"pacientes/{nuevoID}", nuevoPaciente);
            })
                .WithName("Create paciente");
            app.MapDelete("/pacientes/{id}", (int id) =>
            {
                var paciente = Paciente.ListaP.FirstOrDefault(p => p.Id == id);
                if (paciente != null)
                {
                    Paciente.ListaP.Remove(paciente);
                    return Results.NoContent();

                }
                else
                {
                    return Results.NotFound();
                }
            })
                .WithName("Delete paciente");
            app.MapPut("pacientes/{id}", (int id, PacienteDTO pacienteDTO) =>
            {
                var paciente = Paciente.ListaP.FirstOrDefault(p => p.Id == id);
                if (paciente != null)
                {
                    var buscaHC = Paciente.ListaP.FirstOrDefault(p => p.NroHC == pacienteDTO.NroHC && p.Id != id);
                    if (buscaHC != null)
                    {
                        return Results.Conflict(new
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

                    return Results.NoContent();
                }
                return Results.NotFound();
            });
            app.Run();
        }
    }
}
