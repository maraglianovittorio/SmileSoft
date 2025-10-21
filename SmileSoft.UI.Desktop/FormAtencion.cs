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
        private List<TipoAtencion> tiposAtencion;
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

        private async void FormAtencion_Load(object sender, EventArgs e)
        {
            tiposAtencion = (await TipoAtencionApiClient.GetAllAsync()).ToList();
            if (tiposAtencion != null && tiposAtencion.Count() > 0)
            {
                cmbTipoAtencion.SelectedValueChanged -= cmb_SelectedValueChanged;
                cmbTipoAtencion.DataSource = tiposAtencion.ToList();
                cmbTipoAtencion.DisplayMember = "Descripcion";
                cmbTipoAtencion.ValueMember = "Id";
                cmbTipoAtencion.SelectedIndex = -1; // No seleccionar nada al cargar
                cmbTipoAtencion.SelectedValueChanged += cmb_SelectedValueChanged;
            }
            else
            {
                MessageBox.Show("No se encontraron tipos de atención.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var odontologos = await OdontologoApiClient.GetAllAsync();
            if (odontologos != null && odontologos.Count() > 0)
            {
                cmbOdontologo.SelectedValueChanged -= cmb_SelectedValueChanged;
                cmbOdontologo.DataSource = odontologos.ToList();
                cmbOdontologo.DisplayMember = "NombreCompleto";
                cmbOdontologo.ValueMember = "Id";
                cmbOdontologo.SelectedIndex = -1;
                cmbOdontologo.SelectedValueChanged += cmb_SelectedValueChanged;
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
                if (cmbHorario.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Combinar fecha y hora
                DateTime fechaSeleccionada = dtpDiaAtencion.Value.Date;
                TimeSpan horaSeleccionada = TimeSpan.Parse(cmbHorario.SelectedItem.ToString());
                DateTime fechaHoraCompleta = fechaSeleccionada + horaSeleccionada;

                var tipoAtencion = tiposAtencion?.FirstOrDefault(t => t.Id == (int)cmbTipoAtencion.SelectedValue);
                var duracion = tipoAtencion?.Duracion;
                //if (duracion != null)
                //{
                //    // Verificar si el horario seleccionado más la duración excede el horario de atención (17:00)
                //    DateTime horaFinAtencion = fechaHoraCompleta.AddMinutes(duracion.Value);
                //    DateTime horaCierre = fechaSeleccionada.AddHours(17); // 17:00 del mismo día
                //    if (horaFinAtencion > horaCierre)
                //    {
                //        MessageBox.Show("El horario seleccionado más la duración de la atención excede el horario de atención (hasta las 17:00). Por favor, seleccione otro horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}
                var turnosDelDia = await AtencionApiClient.GetByFechaRangeAndOdoAsync(fechaSeleccionada, fechaSeleccionada, (int)cmbOdontologo.SelectedValue);
                var paciente = await PacienteApiClient.GetByDni(txtDni.Text.Trim());
                AtencionDTO atencionCreada = new AtencionDTO
                {
                    PacienteId = paciente.Id,
                    TipoAtencionId = (int)cmbTipoAtencion.SelectedValue,
                    OdontologoId = (int)cmbOdontologo.SelectedValue,
                    FechaHoraAtencion = fechaHoraCompleta
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

        private async Task BuscarTurnosPorOdontologo()
        {
            if (cmbOdontologo.SelectedIndex != -1 && cmbTipoAtencion.SelectedIndex != -1 && dtpDiaAtencion.Value != null)
            {
                try
                {
                    atencionesDelDia = (await AtencionApiClient.GetByFechaRangeAndOdoAsync(dtpDiaAtencion.Value.Date, dtpDiaAtencion.Value.Date, (int)cmbOdontologo.SelectedValue)).ToList();
                    dgvTurnosDisponibles.DataSource = atencionesDelDia;

                    var tipoAtencionSeleccionado = tiposAtencion.FirstOrDefault(t => t.Id == (int)cmbTipoAtencion.SelectedValue);
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

                        // 4. Si el horario no está ocupado, agregarlo a la lista
                        if (!horarioOcupado)
                        {
                            horariosDisponibles.Add(hora.ToString(@"hh\:mm"));
                        }
                    }
                    
                    if (atencionesDelDia.Count == 0 && horariosDisponibles.Count > 0)
                    {
                        MessageBox.Show("Todos los horarios están disponibles", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
