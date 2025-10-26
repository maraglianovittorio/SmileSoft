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
    public partial class FormOS : Form
    {
        public FormOS()
        {
            InitializeComponent();
            this.Text = "SmileSoft - Agregar Obra Social";
            LimpiarFormulario();
            ConfigurarEstilos();
            btnEditarOS.Visible = false; // Ocultar botón de editar
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        public FormOS(int idOS)
        {
            InitializeComponent();
            this.Text = "SmileSoft - Editar Obra Social";
            LimpiarFormulario();
            ConfigurarEstilos();
            btnGuardarOS.Visible = false; // Ocultar botón de agregar
            btnEditarOS.Tag = idOS; // Guardar el ID de la obra social en el Tag del botón de editar
            PopularFormOS(idOS);
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
                    if (lbl.Name == "lblNombreOS")
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
            if (string.IsNullOrWhiteSpace(txtNombreOS.Text))
                errores.Add("• El nombre es obligatorio");
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
            txtNombreOS.Clear();

            // Enfocar el primer campo
            txtNombreOS.Focus();
        }
        private async void btnEnviarOS_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            try
            {
                ObraSocialDTO obraSocial = new ObraSocialDTO
                {
                    Nombre = txtNombreOS.Text.Trim(),
                };

                btnGuardarOS.Text = "Enviando...";
                btnGuardarOS.Enabled = false;

                await ObraSocialApiClient.CreateAsync(obraSocial);
                MessageBox.Show("Obra social agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se agregó una obra social
                this.Close(); // Cerrar el formulario después del éxito


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarOS.Text = "Enviar";
                btnGuardarOS.Enabled = true;
            }
        }
        public async void PopularFormOS(int idOS)
        {

            LimpiarFormulario();
            try
            {
                var OSResponse = await ObraSocialApiClient.GetOneAsync(idOS);
                if (OSResponse != null)
                {
                    txtNombreOS.Text = OSResponse.Nombre;


                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos de la obra social. Código: {MessageBoxIcon.Error}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private async void btnEditarOS_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEditarOS.Tag is not int id)
                {
                    MessageBox.Show("Error al obtener el ID de la obra social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ObraSocialDTO obraSocial = new ObraSocialDTO
                {
                    Nombre = txtNombreOS.Text.Trim()
                };

                btnEditarOS.Text = "Enviando...";
                btnEditarOS.Enabled = false;

                await ObraSocialApiClient.UpdateAsync(obraSocial,obraSocial.Id);
                MessageBox.Show("Obra social editada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se editó una obra social
                this.Close(); // Cerrar el formulario después del éxito
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEditarOS.Text = "Enviar";
                btnEditarOS.Enabled = true;
            }

        }
    }
}
