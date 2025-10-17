using DTO;
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
    public partial class FormAtencion : Form
    {
        public FormAtencion()
        {
            InitializeComponent();
        }

        private async void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (txtDni == null || string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show($"Error: Debe ingresar el DNI del paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (int.TryParse(txtDni.Text.Trim(), out int dni))
                {
                    try
                    {
                        Paciente paciente = await PacienteApiClient.GetByDni(txtDni.Text.Trim());
                        if (paciente == null)
                        {
                            MessageBox.Show($"Error: Paciente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        txtNomYApe.Text = paciente.Nombre + " " + paciente.Apellido;
                        // ver como ahorrarse esta llamada
                        var tipoPlan = await TipoPlanApiClient.GetOneAsync(paciente.TipoPlanId);
                        var obraSocial = await ObraSocialApiClient.GetOneAsync(tipoPlan.ObraSocialId);
                        txtOS.Text = obraSocial != null ? obraSocial.Nombre : "Sin obra social";
                    }
                    catch
                    {
                        MessageBox.Show($"Error: Paciente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Error: El DNI ingresado no es válido. No utilice puntos ni espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private async void FormAtencion_Load(object sender, EventArgs e)
        {
            var tiposAtencion = await TipoAtencionApiClient.GetAllAsync();
            if (tiposAtencion != null && tiposAtencion.Count() > 0)
            {
                cmbTipoAtencion.DataSource = tiposAtencion.ToList();
                cmbTipoAtencion.DisplayMember = "Descripcion";
                cmbTipoAtencion.ValueMember = "Id";
                cmbTipoAtencion.SelectedIndex = -1; // No seleccionar nada al cargar
            }
            else
            {
                MessageBox.Show("No se encontraron tipos de atención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var odontologos = await OdontologoApiClient.GetAllAsync();
            if (odontologos != null && odontologos.Count() > 0)
            {
                cmbOdontologo.DataSource = odontologos.ToList();
                cmbOdontologo.DisplayMember = "NombreCompleto";
                cmbOdontologo.ValueMember = "Id";
                cmbOdontologo.SelectedIndex = -1; 
            }
            else
            {
                MessageBox.Show("No se encontraron odontólogos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
