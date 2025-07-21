using SmileSoft.Dominio;
using System.Net.Http.Json;
using DTO;
using SmileSoft.UI;

namespace SmileSoft.Consola
{
    internal class Program
    {

        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5279")

        };
        static async Task Main(string[] args)
        {

            Console.WriteLine("--- Performing API Operations ---");
            Console.WriteLine("Menu de opciones: ");
            Console.WriteLine("1. Crear Paciente");
            Console.WriteLine("2. Obtener Pacientes");
            Console.WriteLine("3. Obtener Paciente por ID");
            Console.WriteLine("4. Actualizar Paciente");
            Console.WriteLine("5. Salir");
            int opcion = 0;
            do
            {
                Console.Write("Seleccione una opción(primero ponga 1 para crear los pacientes y luego 2 para verlos): ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        await CreatePaciente();
                        break;
                    case 2:
                        await GetPacientes();
                        break;
                    case 3:
                        await GetPaciente();
                        break;
                    case 4:
                        await UpdatePaciente();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            } while (opcion != 5);


        }
        public static async Task CreatePaciente()
        {
            PacienteDTO p1 = new PacienteDTO()
            {
                Nombre = "vittorio",
                Apellido = "maragliano",
                Direccion = "aa",
                NroHC = "1",
                NroDni = "111",
                NroAfiliado = "1111A",
                FechaNacimiento = new DateTime(2000,1,1),
                Email = "aa@gmail.com",
                Telefono = "123"

            };
            await httpClient.PostAsJsonAsync("/pacientes", p1);
            //PacienteDTO p2 = new PacienteDTO()
            //{
            //    Nombre = "vittorio2",
            //    Apellido = "maragliano2",
            //    Direccion = "aa2",
            //    NroHC = 2
            //};
            //await httpClient.PostAsJsonAsync("/pacientes", p2);

            Console.WriteLine("Pacientes creados exitosamente.");


        }
        public static async Task GetPacientes()
        {
            List<Paciente> pacientes = await httpClient.GetFromJsonAsync<List<Paciente>>("/pacientes");

            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes");
            }
            else
            {
                foreach (var p in pacientes)
                {
                    Console.WriteLine($"Nombre del paciente: {p.Nombre} Apellido del paciente: {p.Apellido}");
                }
                Console.WriteLine("Total de pacientes: " + pacientes.Count);
            }
        }
        public static async Task GetPaciente()
        {

            Console.WriteLine("Ingrese el ID del paciente a buscar:");
            int id = int.Parse(Console.ReadLine());
            Paciente? paciente = await httpClient.GetFromJsonAsync<Paciente>($"/pacientes/id?id={id}");
            if (paciente != null)
            {
                Console.WriteLine($"Paciente encontrado: {paciente.Nombre} {paciente.Apellido}");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }

        }
        public static async Task UpdatePaciente()
        {
            Console.WriteLine("Ingrese el ID del paciente a actualizar:");
            int id = int.Parse(Console.ReadLine());
            PacienteDTO p = new PacienteDTO()
            {
                Nombre = "NuevoNombre",
                Apellido = "NuevoApellido",
                Direccion = "NuevaDireccion",
                NroHC = "123",
                Telefono = "123",
                Email = "aa@gmail.com",
                FechaNacimiento = new DateTime(08 / 11 / 2003),
                NroAfiliado = "0215711A",
                NroDni = "123",



            };
            HttpResponseMessage response = await httpClient.PutAsJsonAsync($"/pacientes/{id}", p);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Paciente actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
                Console.WriteLine(response.Content.ToString());
            }
        }
    }
}
