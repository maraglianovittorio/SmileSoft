using SmileSoft.DTO;
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
        private int? _idAtencionEditar = null; // Guardamos el ID si es modo edición
        public FormAtencion()
        {
            InitializeComponent();
            btnCancelarAtencion.Visible = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

        }

        public FormAtencion(int idAtencion)
        {
            InitializeComponent();
            lblTitulo.Text = "Editar Atención";
            this.Text = "Editar Atención";
            btnCancelarAtencion.Visible = true;
            _idAtencionEditar = idAtencion; // Guardamos el ID para usarlo después del Load
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private List<TipoAtencionDTO> tiposAtencion;
        private List<AtencionDetalleDTO> atencionesDelDia;

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


        private async Task PopularFormAtencion(int idAtencion)
        {
            try
            {

                var atencionResponse = await AtencionApiClient.GetOneAsync(idAtencion);
                if (atencionResponse == null)
                {
                    MessageBox.Show("Error al cargar los datos de la atención.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await BuscarTurnosPorOdontologo();
                // Deshabilitar eventos temporalmente para evitar llamadas innecesarias
                cmbTipoAtencion.SelectedValueChanged -= cmb_SelectedValueChanged;
                cmbOdontologo.SelectedValueChanged -= cmb_SelectedValueChanged;

                // Poblar datos del paciente
                txtDni.Text = atencionResponse.PacienteDni;
                txtNomYApe.Text = $"{atencionResponse.PacienteNombre} {atencionResponse.PacienteApellido}";

                // Poblar Obra Social
                var paciente = await PacienteApiClient.GetByDni(atencionResponse.PacienteDni);
                if (paciente != null && paciente.TipoPlanId.HasValue)
                {
                    var tipoPlan = await TipoPlanApiClient.GetOneAsync(paciente.TipoPlanId.Value);
                    var obraSocial = await ObraSocialApiClient.GetOneAsync(tipoPlan.ObraSocialId);
                    txtOS.Text = obraSocial?.Nombre ?? "Sin obra social";
                }
                else
                {
                    txtOS.Text = "Sin obra social";
                }

                // Asignar fecha
                dtpDiaAtencion.Value = atencionResponse.FechaHoraAtencion.Date;

                // Asignar odontólogo
                if (cmbOdontologo.Items.Count > 0)
                {
                    cmbOdontologo.SelectedValue = atencionResponse.OdontologoId;
                }

                // Asignar tipo de atención
                if (cmbTipoAtencion.Items.Count > 0)
                {
                    cmbTipoAtencion.SelectedValue = atencionResponse.TipoAtencionId;
                }

                // Buscar turnos y poblar horarios disponibles

                // Asignar horario
                string horarioAtencion = atencionResponse.FechaHoraAtencion.ToString("HH:mm");
                if (cmbHorario.Items.Count > 0)
                {
                    int indexHorario = cmbHorario.FindString(horarioAtencion);
                    if (indexHorario != -1)
                    {
                        cmbHorario.SelectedIndex = indexHorario;
                    }
                    else
                    {
                        // Si el horario no está disponible, lo agregamos (porque es el horario actual de la atención)
                        cmbHorario.Items.Add(horarioAtencion);
                        cmbHorario.SelectedItem = horarioAtencion;
                    }
                }
                await BuscarTurnosPorOdontologo();

                // Rehabilitar eventos
                cmbTipoAtencion.SelectedValueChanged += cmb_SelectedValueChanged;
                cmbOdontologo.SelectedValueChanged += cmb_SelectedValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al popular el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FormAtencion_Load(object sender, EventArgs e)
        {
            dtpDiaAtencion.Value = DateTime.Today;
            lblAviso.Visible = false;

            // Cargar tipos de atención
            tiposAtencion = (await TipoAtencionApiClient.GetAllAsync()).ToList();
            if (tiposAtencion != null && tiposAtencion.Any())
            {
                cmbTipoAtencion.DataSource = tiposAtencion.ToList();
                cmbTipoAtencion.DisplayMember = "Descripcion";
                cmbTipoAtencion.ValueMember = "Id";
                cmbTipoAtencion.SelectedIndex = -1;
            }


            // Cargar odontólogos
            var odontologos = await OdontologoApiClient.GetAllAsync();
            if (odontologos != null && odontologos.Any())
            {
                cmbOdontologo.DataSource = odontologos.ToList();
                cmbOdontologo.DisplayMember = "NombreCompleto";
                cmbOdontologo.ValueMember = "Id";
                cmbOdontologo.SelectedIndex = -1;
            }

            // Si es modo edición, popular el formulario DESPUÉS de que los ComboBox estén cargados
            if (_idAtencionEditar.HasValue)
            {
                await PopularFormAtencion(_idAtencionEditar.Value);
            }

            // Suscribir a eventos después de cargar todo
            cmbTipoAtencion.SelectedValueChanged += cmb_SelectedValueChanged;
            cmbOdontologo.SelectedValueChanged += cmb_SelectedValueChanged;
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
                if (cmbHorario.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime fechaSeleccionada = dtpDiaAtencion.Value.Date;
                TimeSpan horaSeleccionada = TimeSpan.Parse(cmbHorario.SelectedItem.ToString());
                DateTime fechaHoraCompleta = fechaSeleccionada + horaSeleccionada;

                var paciente = await PacienteApiClient.GetByDni(txtDni.Text.Trim());
                AtencionDTO atencionCreada = new AtencionDTO
                {
                    PacienteId = paciente.Id,
                    TipoAtencionId = (int)cmbTipoAtencion.SelectedValue,
                    OdontologoId = (int)cmbOdontologo.SelectedValue,
                    FechaHoraAtencion = fechaHoraCompleta
                };

                // Si es modo edición, actualizar; si no, crear
                if (_idAtencionEditar.HasValue)
                {
                    await AtencionApiClient.UpdateAsync(atencionCreada, _idAtencionEditar.Value);
                    MessageBox.Show("Atención actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await AtencionApiClient.CreateAsync(atencionCreada);
                    MessageBox.Show("Atención agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la atención: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BuscarTurnosPorOdontologo()
        {
            if (cmbOdontologo.SelectedIndex != -1 && cmbTipoAtencion.SelectedIndex != -1 && dtpDiaAtencion.Value != null)
            {
                lblTurnos.Visible = false;
                lblAviso.Visible = false;
                try
                {
                    atencionesDelDia = (await AtencionApiClient.GetByFechaRangeAndOdoAsync(dtpDiaAtencion.Value.Date, dtpDiaAtencion.Value.Date, (int)cmbOdontologo.SelectedValue)).ToList();

                    // Excluir la atención actual si estamos en modo edición
                    if (_idAtencionEditar.HasValue)
                    {
                        atencionesDelDia = atencionesDelDia.Where(a => a.Id != _idAtencionEditar.Value).ToList();
                    }
                    atencionesDelDia = atencionesDelDia.Where(a => a.Estado == "Otorgada" || a.Estado == "En sala de espera").ToList();

                    foreach (var atencion in atencionesDelDia)
                    {
                        atencion.PacienteNombre = $"{atencion.PacienteApellido}, {atencion.PacienteNombre}";
                        atencion.OdontologoNombre = $"{atencion.OdontologoApellido}, {atencion.OdontologoNombre}";
                    }
                    dgvTurnosOcupados.DataSource = atencionesDelDia;
                    dgvTurnosOcupados.Columns["Id"].Visible = false;
                    dgvTurnosOcupados.Columns["FechaHoraAtencion"].HeaderText = "Fecha y hora";
                    dgvTurnosOcupados.Columns["TipoAtencionId"].Visible = false;
                    dgvTurnosOcupados.Columns["Observaciones"].Visible = false;
                    dgvTurnosOcupados.Columns["OdontologoId"].Visible = false;
                    dgvTurnosOcupados.Columns["PacienteId"].Visible = false;
                    dgvTurnosOcupados.Columns["PacienteNombre"].HeaderText = "Paciente";
                    dgvTurnosOcupados.Columns["PacienteApellido"].Visible = false;
                    dgvTurnosOcupados.Columns["PacienteDni"].HeaderText = "Dni";
                    dgvTurnosOcupados.Columns["OdontologoNombre"].HeaderText = "Odontólogo";
                    dgvTurnosOcupados.Columns["OdontologoApellido"].Visible = false;
                    dgvTurnosOcupados.Columns["TipoAtencionDescripcion"].HeaderText = "Atención";
                    dgvTurnosOcupados.Columns["TipoAtencionDuracion"].HeaderText = "Duración";

                    // Configurar anchos de columnas
                    dgvTurnosOcupados.Columns["FechaHoraAtencion"].Width = 100;
                    dgvTurnosOcupados.Columns["PacienteNombre"].Width = 150;
                    dgvTurnosOcupados.Columns["PacienteDni"].Width = 100;
                    dgvTurnosOcupados.Columns["OdontologoNombre"].Width = 150;
                    dgvTurnosOcupados.Columns["Estado"].Width = 100;
                    dgvTurnosOcupados.Columns["TipoAtencionDescripcion"].Width = 100;
                    dgvTurnosOcupados.Columns["TipoAtencionDuracion"].Width = 75;

                    var tipoAtencionSeleccionado = tiposAtencion?.FirstOrDefault(t => t.Id == (int)cmbTipoAtencion.SelectedValue);
                    if (tipoAtencionSeleccionado == null) return;

                    var duracionNuevoTurno = tipoAtencionSeleccionado.Duracion;
                    var horariosDisponibles = new List<string>();

                    var horaInicioDia = TimeSpan.FromHours(8);
                    var horaFinDia = TimeSpan.FromHours(17);
                    var intervaloMinutos = 30;

                    for (var hora = horaInicioDia; hora < horaFinDia; hora = hora.Add(TimeSpan.FromMinutes(intervaloMinutos)))
                    {
                        if (hora.Add(duracionNuevoTurno) > horaFinDia)
                        {
                            break;
                        }

                        bool horarioOcupado = false;
                        var inicioNuevoTurno = hora;
                        var finNuevoTurno = hora.Add(duracionNuevoTurno);

                        foreach (var atencionExistente in atencionesDelDia)
                        {
                            var inicioTurnoExistente = atencionExistente.FechaHoraAtencion.TimeOfDay;
                            var finTurnoExistente = inicioTurnoExistente.Add(atencionExistente.TipoAtencionDuracion);

                            if (inicioNuevoTurno < finTurnoExistente && finNuevoTurno > inicioTurnoExistente)
                            {
                                horarioOcupado = true;
                                break;
                            }
                        }

                        if (!horarioOcupado)
                        {
                            horariosDisponibles.Add(hora.ToString(@"hh\:mm"));
                        }
                    }

                    if (atencionesDelDia.Count == 0 && horariosDisponibles.Count > 0)
                    {
                        lblTurnos.Visible = true;
                    }

                    cmbHorario.DataSource = horariosDisponibles;
                    if (horariosDisponibles.Count == 0)
                    {
                        MessageBox.Show("No hay horarios disponibles para la selección actual.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar turnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblAviso.Visible = true;
            }
        }

        private async void btnBuscarTurnos_Click(object sender, EventArgs e)
        {
            await BuscarTurnosPorOdontologo();
        }

        private async void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            await BuscarTurnosPorOdontologo();
        }

        private async void dtpDiaAtencion_ValueChanged(object sender, EventArgs e)
        {
            await BuscarTurnosPorOdontologo();
        }

        private async void btnCancelarAtencion_Click(object sender, EventArgs e)
        {
            if(_idAtencionEditar == null)
            {
                MessageBox.Show("Error: No se puede cancelar una atención que no ha sido creada aún.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await AtencionApiClient.CancelaAtencionAsync(_idAtencionEditar.Value);
            await BuscarTurnosPorOdontologo();
            MessageBox.Show("Atención cancelada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
