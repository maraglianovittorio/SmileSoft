using SmileSoft.Dominio;
using System.Net.Http.Json;

namespace SmileSoft.UI.Desktop
{
    public partial class FormGetPacientes : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5279")

        };
        public FormGetPacientes()
        {
            InitializeComponent();

        }

        private async void btnGetPacientes_Click_1(object sender, EventArgs e)
        {
            try
            {
                var pacientes = await httpClient.GetFromJsonAsync<List<Paciente>>("/pacientes");
                if (pacientes.Count != 0)
                {
                    dvgPacientes.DataSource = pacientes;
                }
                else
                {
                    MessageBox.Show("No hay pacientes");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los pacientes: {ex.Message}");

            }
        }
    }
}
