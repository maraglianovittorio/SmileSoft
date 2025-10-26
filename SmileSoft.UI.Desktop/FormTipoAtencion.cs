using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmileSoft.UI.Desktop
{
    public partial class FormTipoAtencion : Form
    {
        private List<ObraSocial> obrasSociales = new List<ObraSocial>();

        public FormTipoAtencion()
        {
            InitializeComponent();
            this.Text = "SmileSoft - Agregar Tipo de Atención";
            LimpiarFormulario();
            ConfigurarEstilos();
            btnEditarTipoAtencion.Visible = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        public FormTipoAtencion(int idTipoAtencion)
        {
            InitializeComponent();
            this.Text = "SmileSoft - Editar Tipo de Atención";
            LimpiarFormulario();
            ConfigurarEstilos();
            PopularFormTipoAtencion(idTipoAtencion);
            btnGuardarTipoAtencion.Visible = false;
            btnEditarTipoAtencion.Tag = idTipoAtencion;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }


        private void ConfigurarEstilos()
        {
            // Estilo verde moderno para POST
            this.BackColor = Color.FromArgb(245, 255, 250); // MintCream
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(925, 558); // Tamaño mínimo

            // Estilo para labels
            foreach (Control control in this.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                    // Marcar campos obligatorios con asterisco
                    if (lbl.Name == "lblDescripcionTipoAtencion" || lbl.Name == "lblDuracionTipoAtencion")
                    {
                        lbl.Text = lbl.Text.TrimEnd(':') + " *";
                        lbl.ForeColor = Color.FromArgb(220, 20, 60); // Crimson para campos obligatorios
                    }
                }
                else if (control is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 9F);
                }
                else if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(60, 179, 113); // MediumSeaGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 125, 50); // Darker green
                    btn.Cursor = Cursors.Hand;
                }
                else if (control is DateTimePicker dtp)
                {
                    dtp.Font = new Font("Segoe UI", 9F);
                }
            }
        }

        private bool ValidarCampos()
        {
            var errores = new List<string>();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtDescripcionTipoAtencion.Text))
                errores.Add("• La descripción es obligatoria");

            if (errores.Count > 0)
            {
                string mensaje = "Por favor corrija los siguientes errores:\n\n" + string.Join("\n", errores);
                MessageBox.Show(mensaje, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtDescripcionTipoAtencion.Clear();
            cmbDuracion.SelectedIndex = -1;

            txtDescripcionTipoAtencion.Focus();
        }

        private async void btnEnviarTipoAtencion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            try
            {
                TipoAtencionDTO tipoAtencion = new TipoAtencionDTO
                {
                    Descripcion = txtDescripcionTipoAtencion.Text.Trim(),
                    Duracion = cmbDuracion.SelectedItem != null ? TimeSpan.Parse(cmbDuracion.SelectedItem.ToString()) : TimeSpan.Zero

                };

                btnGuardarTipoAtencion.Text = "Enviando...";
                btnGuardarTipoAtencion.Enabled = false;

                await TipoAtencionApiClient.CreateAsync(tipoAtencion);
                MessageBox.Show("Tipo de atención agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarTipoAtencion.Text = "Enviar";
                btnGuardarTipoAtencion.Enabled = true;
            }
        }

        public async void PopularFormTipoAtencion(int idTipoAtencion)
        {
            LimpiarFormulario();
            try
            {
                var tipoAtencionResponse = await TipoAtencionApiClient.GetOneAsync(idTipoAtencion);
                if (tipoAtencionResponse != null)
                {
                    txtDescripcionTipoAtencion.Text = tipoAtencionResponse.Descripcion;
                    cmbDuracion.SelectedValue = tipoAtencionResponse.Duracion.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos del tipo de atención. Código: {MessageBoxIcon.Error}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditarTipoAtencion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            
            try
            {
                if (btnEditarTipoAtencion.Tag is not int id)
                {
                    MessageBox.Show("Error al obtener el ID del tipo de plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TipoAtencionDTO tipoAtencion = new TipoAtencionDTO
                {
                    Id = id,
                    Descripcion = txtDescripcionTipoAtencion.Text.Trim(),
                    Duracion = TimeSpan.Parse(cmbDuracion.Text.Trim())
                };

                btnEditarTipoAtencion.Text = "Enviando...";
                btnEditarTipoAtencion.Enabled = false;

                await TipoAtencionApiClient.UpdateAsync(tipoAtencion, tipoAtencion.Id);
                MessageBox.Show("Tipo de atención editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEditarTipoAtencion.Text = "Enviar";
                btnEditarTipoAtencion.Enabled = true;
            }
        }
    }
}
