using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private async void tsbUsuarios_Click(object sender, EventArgs e)
        {
            await ObtenerDatos();
        }
        private List<Usuario> usuarios = new();

        private async Task ObtenerDatos()
        {
            try
            {
                var usuarioResponse = await UsuarioApiClient.GetAllAsync();
                if (usuarioResponse != null && usuarioResponse.Count() > 0)
                {
                    dgvPrincipal.DataSource = usuarioResponse;
                    usuarios = (List<Usuario>)usuarioResponse;
                    //dgvPrincipal.Columns["Id"].Visible = false;
                }
                else
                {
                    dgvPrincipal.DataSource = null;
                    usuarios.Clear();
                    MessageBox.Show("No se encontraron usuarios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }


}
