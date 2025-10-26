using SmileSoft.DTO;
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
    public partial class FormTipoPlan : Form
    {
        private List<ObraSocial> obrasSociales = new List<ObraSocial>();

        public FormTipoPlan()
        {
            InitializeComponent();
            this.Text = "SmileSoft - Agregar Tipo de Plan";
            LimpiarFormulario();
            ConfigurarEstilos();
            btnEditarTipoPlan.Visible = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        public FormTipoPlan(int idTipoPlan)
        {
            InitializeComponent();
            this.Text = "SmileSoft - Editar Tipo de Plan";
            LimpiarFormulario();
            ConfigurarEstilos();
            btnGuardarTipoPlan.Visible = false; 
            btnEditarTipoPlan.Tag = idTipoPlan;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private async void FormTipoPlan_Load(object sender, EventArgs e)
        {
            await CargarObrasSociales();
            if (btnEditarTipoPlan.Tag is int idTipoPlan)
            {
                PopularFormTipoPlan(idTipoPlan);
            }

        }

        private async Task CargarObrasSociales()
        {
            try
            {
                var obrasSocialesResponse = await ObraSocialApiClient.GetAllAsync();
                if (obrasSocialesResponse != null)
                {
                    obrasSociales = obrasSocialesResponse.ToList();
                    
                    cmbObraSocial.DataSource = obrasSociales;
                    cmbObraSocial.DisplayMember = "Nombre";
                    cmbObraSocial.ValueMember = "Id"; 
                    cmbObraSocial.SelectedIndex = -1; 
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar las obras sociales.", "Advertencia", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar obras sociales: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (lbl.Name == "lblNombreTipoPlan" || lbl.Name == "lblDescripcionTipoPlan" || lbl.Name == "lblObraSocial")
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
                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = Color.White;
                    cmb.Font = new Font("Segoe UI", 9F);
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
            if (string.IsNullOrWhiteSpace(txtNombreTipoPlan.Text))
                errores.Add("• El nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(txtDescripcionTipoPlan.Text))
                errores.Add("• La descripción es obligatoria");
            if (cmbObraSocial.SelectedValue == null)
                errores.Add("• Debe seleccionar una obra social");

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
            txtNombreTipoPlan.Clear();
            txtDescripcionTipoPlan.Clear();
            if (cmbObraSocial.Items.Count > 0)
                cmbObraSocial.SelectedIndex = -1;

            txtNombreTipoPlan.Focus();
        }

        private async void btnEnviarTipoPlan_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            try
            {
                TipoPlanDTO tipoPlan = new TipoPlanDTO
                {
                    Nombre = txtNombreTipoPlan.Text.Trim(),
                    Descripcion = txtDescripcionTipoPlan.Text.Trim(),
                    ObraSocialId = (int)cmbObraSocial.SelectedValue
                };

                btnGuardarTipoPlan.Text = "Enviando...";
                btnGuardarTipoPlan.Enabled = false;

                await TipoPlanApiClient.CreateAsync(tipoPlan);
                MessageBox.Show("Tipo de plan agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarTipoPlan.Text = "Enviar";
                btnGuardarTipoPlan.Enabled = true;
            }
        }

        public async void PopularFormTipoPlan(int idTipoPlan)
        {
            LimpiarFormulario();
            try
            {
                var tipoPlanResponse = await TipoPlanApiClient.GetOneAsync(idTipoPlan);
                if (tipoPlanResponse != null)
                {
                    txtNombreTipoPlan.Text = tipoPlanResponse.Nombre;
                    txtDescripcionTipoPlan.Text = tipoPlanResponse.Descripcion;

                    if (tipoPlanResponse.ObraSocialId != -1)
                    {
                        cmbObraSocial.SelectedValue = tipoPlanResponse.ObraSocialId;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos del tipo de plan. Código: {MessageBoxIcon.Error}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditarTipoPlan_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            
            try
            {
                if (btnEditarTipoPlan.Tag is not int id)
                {
                    MessageBox.Show("Error al obtener el ID del tipo de plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TipoPlanDTO tipoPlan = new TipoPlanDTO
                {
                    Id = id,
                    Nombre = txtNombreTipoPlan.Text.Trim(),
                    Descripcion = txtDescripcionTipoPlan.Text.Trim(),
                    ObraSocialId = (int)cmbObraSocial.SelectedValue
                };

                btnEditarTipoPlan.Text = "Enviando...";
                btnEditarTipoPlan.Enabled = false;

                await TipoPlanApiClient.UpdateAsync(tipoPlan, tipoPlan.Id);
                MessageBox.Show("Tipo de plan editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEditarTipoPlan.Text = "Enviar";
                btnEditarTipoPlan.Enabled = true;
            }
        }
    }
}
