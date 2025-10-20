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
                        PacienteDTO paciente = await PacienteApiClient.GetByDni(txtDni.Text.Trim());
                        if (paciente == null)
                        {
                            MessageBox.Show($"Error: Paciente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        txtNomYApe.Text = paciente.Nombre + " " + paciente.Apellido;
                        // ver como ahorrarse esta llamada
                        if (paciente.TipoPlanId == null)
                        {
                            txtOS.Text = "Sin obra social";
                            return;
                        }
                        var tipoPlan = await TipoPlanApiClient.GetOneAsync(paciente.TipoPlanId.Value);
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

        private async void btnAgregarAtencion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNomYApe.Text))
                {
                    MessageBox.Show("Debe buscar y seleccionar un paciente antes de agregar una atención.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbTipoAtencion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de atención.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbOdontologo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un odontólogo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var paciente = await PacienteApiClient.GetByDni(txtDni.Text.Trim());
                AtencionDTO atencionCreada = new AtencionDTO
                {
                    PacienteId = paciente.Id,
                    TipoAtencionId = (int)cmbTipoAtencion.SelectedValue,
                    OdontologoId = (int)cmbOdontologo.SelectedValue,
                    FechaHoraAtencion = dtpDiaAtencion.Value
                };
                await AtencionApiClient.CreateAsync(atencionCreada);
                // Aquí podrías agregar la lógica para guardar la nueva atención en la base de datos o enviarla a través de una API.
                MessageBox.Show("Atención agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la atención: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscarTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                var atenciones = await AtencionApiClient.GetByFechaRangeAndOdoAsync(dtpDiaAtencion.Value, dtpDiaAtencion.Value, (int)cmbOdontologo.SelectedValue);
                dgvTurnosDisponibles.DataSource = atenciones;
                var tipoAtencion = await TipoAtencionApiClient.GetOneAsync((int)cmbTipoAtencion.SelectedValue);
                //populamos cmbHorario con los horarios de 8 a 17 subdvidido por tipoAtencion.Duracion
                // creo una lista con los horarios de 8 a 17 dividios cada media hora
                var horarios = new List<string>();
                var duracion = tipoAtencion.Duracion;
                var horaInicio = new DateTime(1, 1, 1, 8, 0, 0);
                var horaFin = new DateTime(1, 1, 1, 17, 0, 0);
                while (horaInicio < horaFin)
                {
                    horarios.Add(horaInicio.ToString("HH:mm"));
                    horaInicio = horaInicio.AddMinutes(30);
                }
                cmbHorario.DataSource = horarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar turnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
