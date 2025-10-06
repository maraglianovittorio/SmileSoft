using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmileSoft.WindowsForms
{
    public partial class FormInicioAlternativo : Form
    {
        public FormInicioAlternativo()
        {
            InitializeComponent();
        }

        private string EntidadSeleccionada = string.Empty;
        private List<Usuario> usuarios = new();

        private async void tsbUsuarios_Click(object sender, EventArgs e)
        {
            EntidadSeleccionada = "Usuarios";
            await ObtenerDatos();
        }

        // Reusable generic loader for any entity T
        private async Task CargarEntidad<T>(
            Func<Task<IEnumerable<T>>> getAllAsync,
            string nombreEntidadPlural,
            Action<List<T>>? onLoaded = null)
        {
            try
            {
                var response = await getAllAsync();
                var list = response?.ToList() ?? new List<T>();

                if (list.Count > 0)
                {
                    dgvPrincipal.AutoGenerateColumns = true;

                    // Reset then bind to support proper refresh/sorting
                    dgvPrincipal.DataSource = null;
                    dgvPrincipal.DataSource = new BindingSource { DataSource = list };

                    onLoaded?.Invoke(list);

                    // Example: hide Id column if present
                    if (dgvPrincipal.Columns.Contains("Id"))
                        dgvPrincipal.Columns["Id"].Visible = false;
                }
                else
                {
                    dgvPrincipal.DataSource = null;
                    MessageBox.Show($"No se encontraron {nombreEntidadPlural}.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión al cargar {nombreEntidadPlural}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show($"Timeout al cargar {nombreEntidadPlural}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar {nombreEntidadPlural}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Current users loader reuses the generic method
        private async Task ObtenerDatos()
        {
            await CargarEntidad<Usuario>(
                UsuarioApiClient.GetAllAsync,
                "usuarios",
                list => usuarios = list
            );
        }

        private void tsbOS_Click(object sender, EventArgs e)
        {

        }

        private void tsbPlanes_Click(object sender, EventArgs e)
        {

        }

        private void tsbPacientes_Click(object sender, EventArgs e)
        {

        }

        private void tsbTiposAtencion_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }
    }
}
