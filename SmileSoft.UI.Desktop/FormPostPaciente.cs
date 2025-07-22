using SmileSoft.Dominio;
using System.Net.Http.Json;
using DTO;
namespace SmileSoft.UI.Desktop
{
    public partial class FormPostPaciente : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5279")

        };
        public FormPostPaciente()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteDTO paciente = new PacienteDTO
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    NroDni = txtDNI.Text,
                    NroHC = txtNroHC.Text,
                    Telefono = txtTelefono.Text,
                    NroAfiliado = txtNroAfiliado.Text
                };
                var response = httpClient.PostAsJsonAsync("/pacientes", paciente).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Paciente agregado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al agregar el paciente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
