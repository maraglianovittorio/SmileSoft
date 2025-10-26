namespace SmileSoft.WindowsForms
{
    partial class FormAtencion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblDni = new Label();
            txtDni = new TextBox();
            label2 = new Label();
            txtOS = new TextBox();
            btnBuscarPaciente = new Button();
            label3 = new Label();
            cmbTipoAtencion = new ComboBox();
            label4 = new Label();
            cmbOdontologo = new ComboBox();
            dgvTurnosOcupados = new DataGridView();
            lblTurnosOcupados = new Label();
            label6 = new Label();
            dtpDiaAtencion = new DateTimePicker();
            label7 = new Label();
            txtNomYApe = new TextBox();
            btnBuscarTurnos = new Button();
            btnAgregarAtencion = new Button();
            cmbHorario = new ComboBox();
            lblHorario = new Label();
            lblTurnos = new Label();
            lblAviso = new Label();
            btnCancelarAtencion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosOcupados).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(334, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(182, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nueva atención";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(322, 53);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(28, 15);
            lblDni.TabIndex = 0;
            lblDni.Text = "Dni:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(368, 50);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 23);
            txtDni.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 117);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Obra social:";
            // 
            // txtOS
            // 
            txtOS.Location = new Point(368, 114);
            txtOS.Name = "txtOS";
            txtOS.ReadOnly = true;
            txtOS.Size = new Size(125, 23);
            txtOS.TabIndex = 6;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(519, 50);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.Size = new Size(75, 23);
            btnBuscarPaciente.TabIndex = 2;
            btnBuscarPaciente.Text = "Buscar paciente";
            btnBuscarPaciente.UseVisualStyleBackColor = true;
            btnBuscarPaciente.Click += btnBuscarPaciente_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(252, 153);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 7;
            label3.Text = "Tipo de atención:";
            // 
            // cmbTipoAtencion
            // 
            cmbTipoAtencion.FormattingEnabled = true;
            cmbTipoAtencion.Location = new Point(368, 150);
            cmbTipoAtencion.Name = "cmbTipoAtencion";
            cmbTipoAtencion.Size = new Size(125, 23);
            cmbTipoAtencion.TabIndex = 8;
            cmbTipoAtencion.SelectedValueChanged += cmb_SelectedValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 187);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 9;
            label4.Text = "Odontólogo:";
            // 
            // cmbOdontologo
            // 
            cmbOdontologo.FormattingEnabled = true;
            cmbOdontologo.Location = new Point(368, 184);
            cmbOdontologo.Name = "cmbOdontologo";
            cmbOdontologo.Size = new Size(125, 23);
            cmbOdontologo.TabIndex = 10;
            cmbOdontologo.SelectedValueChanged += cmb_SelectedValueChanged;
            // 
            // dgvTurnosOcupados
            // 
            dgvTurnosOcupados.AllowUserToAddRows = false;
            dgvTurnosOcupados.AllowUserToDeleteRows = false;
            dgvTurnosOcupados.BackgroundColor = Color.PapayaWhip;
            dgvTurnosOcupados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosOcupados.GridColor = Color.PapayaWhip;
            dgvTurnosOcupados.Location = new Point(24, 270);
            dgvTurnosOcupados.Name = "dgvTurnosOcupados";
            dgvTurnosOcupados.ReadOnly = true;
            dgvTurnosOcupados.RowHeadersWidth = 62;
            dgvTurnosOcupados.Size = new Size(843, 146);
            dgvTurnosOcupados.TabIndex = 15;
            // 
            // lblTurnosOcupados
            // 
            lblTurnosOcupados.AutoSize = true;
            lblTurnosOcupados.Location = new Point(249, 252);
            lblTurnosOcupados.Name = "lblTurnosOcupados";
            lblTurnosOcupados.Size = new Size(101, 15);
            lblTurnosOcupados.TabIndex = 14;
            lblTurnosOcupados.Text = "Turnos ocupados:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(323, 224);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 11;
            label6.Text = "Día:";
            // 
            // dtpDiaAtencion
            // 
            dtpDiaAtencion.Format = DateTimePickerFormat.Short;
            dtpDiaAtencion.Location = new Point(368, 218);
            dtpDiaAtencion.Name = "dtpDiaAtencion";
            dtpDiaAtencion.Size = new Size(125, 23);
            dtpDiaAtencion.TabIndex = 12;
            dtpDiaAtencion.Value = new DateTime(2025, 10, 21, 0, 0, 0, 0);
            dtpDiaAtencion.ValueChanged += dtpDiaAtencion_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(295, 82);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 3;
            label7.Text = "Paciente:";
            // 
            // txtNomYApe
            // 
            txtNomYApe.Location = new Point(368, 79);
            txtNomYApe.Name = "txtNomYApe";
            txtNomYApe.ReadOnly = true;
            txtNomYApe.Size = new Size(125, 23);
            txtNomYApe.TabIndex = 4;
            // 
            // btnBuscarTurnos
            // 
            btnBuscarTurnos.Location = new Point(519, 218);
            btnBuscarTurnos.Name = "btnBuscarTurnos";
            btnBuscarTurnos.Size = new Size(129, 23);
            btnBuscarTurnos.TabIndex = 13;
            btnBuscarTurnos.Text = "Buscar turnos";
            btnBuscarTurnos.UseVisualStyleBackColor = true;
            btnBuscarTurnos.Click += btnBuscarTurnos_Click;
            // 
            // btnAgregarAtencion
            // 
            btnAgregarAtencion.Location = new Point(536, 510);
            btnAgregarAtencion.Name = "btnAgregarAtencion";
            btnAgregarAtencion.Size = new Size(92, 37);
            btnAgregarAtencion.TabIndex = 16;
            btnAgregarAtencion.Text = "Agregar";
            btnAgregarAtencion.UseVisualStyleBackColor = true;
            btnAgregarAtencion.Click += btnAgregarAtencion_Click;
            // 
            // cmbHorario
            // 
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(368, 429);
            cmbHorario.Margin = new Padding(2);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(129, 23);
            cmbHorario.TabIndex = 17;
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(232, 432);
            lblHorario.Margin = new Padding(2, 0, 2, 0);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(118, 15);
            lblHorario.TabIndex = 18;
            lblHorario.Text = "Horarios disponibles:";
            // 
            // lblTurnos
            // 
            lblTurnos.AutoSize = true;
            lblTurnos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTurnos.ForeColor = Color.DarkGreen;
            lblTurnos.Location = new Point(368, 252);
            lblTurnos.Name = "lblTurnos";
            lblTurnos.Size = new Size(289, 15);
            lblTurnos.TabIndex = 19;
            lblTurnos.Text = "Todos los horarios del odontólogo estan disponibles";
            lblTurnos.Visible = false;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.Red;
            lblAviso.Location = new Point(660, 221);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(145, 15);
            lblAviso.TabIndex = 20;
            lblAviso.Text = "Faltan completar campos";
            // 
            // btnCancelarAtencion
            // 
            btnCancelarAtencion.Location = new Point(683, 510);
            btnCancelarAtencion.Name = "btnCancelarAtencion";
            btnCancelarAtencion.Size = new Size(96, 34);
            btnCancelarAtencion.TabIndex = 21;
            btnCancelarAtencion.Text = "Cancelar";
            btnCancelarAtencion.UseVisualStyleBackColor = true;
            btnCancelarAtencion.Click += btnCancelarAtencion_Click;
            // 
            // FormAtencion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 557);
            Controls.Add(btnCancelarAtencion);
            Controls.Add(lblAviso);
            Controls.Add(lblTurnos);
            Controls.Add(lblHorario);
            Controls.Add(cmbHorario);
            Controls.Add(btnAgregarAtencion);
            Controls.Add(btnBuscarTurnos);
            Controls.Add(txtNomYApe);
            Controls.Add(label7);
            Controls.Add(dtpDiaAtencion);
            Controls.Add(label6);
            Controls.Add(lblTurnosOcupados);
            Controls.Add(dgvTurnosOcupados);
            Controls.Add(cmbOdontologo);
            Controls.Add(label4);
            Controls.Add(cmbTipoAtencion);
            Controls.Add(label3);
            Controls.Add(btnBuscarPaciente);
            Controls.Add(txtOS);
            Controls.Add(label2);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(lblTitulo);
            Name = "FormAtencion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva atención";
            Load += FormAtencion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTurnosOcupados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDni;
        private TextBox txtDni;
        private Label label2;
        private TextBox txtOS;
        private Button btnBuscarPaciente;
        private Label label3;
        private ComboBox cmbTipoAtencion;
        private Label label4;
        private ComboBox cmbOdontologo;
        private DataGridView dgvTurnosOcupados;
        private Label lblTurnosOcupados;
        private Label label6;
        private DateTimePicker dtpDiaAtencion;
        private Label label7;
        private TextBox txtNomYApe;
        private Button btnBuscarTurnos;
        private Button btnAgregarAtencion;
        private ComboBox cmbHorario;
        private Label lblHorario;
        private Label lblTurnos;
        private Label lblAviso;
        private Button btnCancelarAtencion;
    }
}