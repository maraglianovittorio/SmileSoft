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
            btnEditarAtencion = new Button();
            lblDiaHorarioActual = new Label();
            txtDiaHorarioActual = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosOcupados).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(477, 15);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(267, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nueva atención";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(460, 88);
            lblDni.Margin = new Padding(4, 0, 4, 0);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(43, 25);
            lblDni.TabIndex = 0;
            lblDni.Text = "Dni:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(526, 83);
            txtDni.Margin = new Padding(4, 5, 4, 5);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(177, 31);
            txtDni.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 195);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 5;
            label2.Text = "Obra social:";
            // 
            // txtOS
            // 
            txtOS.Location = new Point(526, 190);
            txtOS.Margin = new Padding(4, 5, 4, 5);
            txtOS.Name = "txtOS";
            txtOS.ReadOnly = true;
            txtOS.Size = new Size(177, 31);
            txtOS.TabIndex = 6;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(741, 83);
            btnBuscarPaciente.Margin = new Padding(4, 5, 4, 5);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.Size = new Size(107, 38);
            btnBuscarPaciente.TabIndex = 2;
            btnBuscarPaciente.Text = "Buscar paciente";
            btnBuscarPaciente.UseVisualStyleBackColor = true;
            btnBuscarPaciente.Click += btnBuscarPaciente_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(360, 255);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 25);
            label3.TabIndex = 7;
            label3.Text = "Tipo de atención:";
            // 
            // cmbTipoAtencion
            // 
            cmbTipoAtencion.FormattingEnabled = true;
            cmbTipoAtencion.Location = new Point(526, 250);
            cmbTipoAtencion.Margin = new Padding(4, 5, 4, 5);
            cmbTipoAtencion.Name = "cmbTipoAtencion";
            cmbTipoAtencion.Size = new Size(177, 33);
            cmbTipoAtencion.TabIndex = 8;
            cmbTipoAtencion.SelectedValueChanged += cmb_SelectedValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(393, 312);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 9;
            label4.Text = "Odontólogo:";
            // 
            // cmbOdontologo
            // 
            cmbOdontologo.FormattingEnabled = true;
            cmbOdontologo.Location = new Point(526, 307);
            cmbOdontologo.Margin = new Padding(4, 5, 4, 5);
            cmbOdontologo.Name = "cmbOdontologo";
            cmbOdontologo.Size = new Size(177, 33);
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
            dgvTurnosOcupados.Location = new Point(38, 527);
            dgvTurnosOcupados.Margin = new Padding(4, 5, 4, 5);
            dgvTurnosOcupados.Name = "dgvTurnosOcupados";
            dgvTurnosOcupados.ReadOnly = true;
            dgvTurnosOcupados.RowHeadersWidth = 62;
            dgvTurnosOcupados.Size = new Size(1204, 243);
            dgvTurnosOcupados.TabIndex = 15;
            // 
            // lblTurnosOcupados
            // 
            lblTurnosOcupados.AutoSize = true;
            lblTurnosOcupados.Location = new Point(360, 497);
            lblTurnosOcupados.Margin = new Padding(4, 0, 4, 0);
            lblTurnosOcupados.Name = "lblTurnosOcupados";
            lblTurnosOcupados.Size = new Size(154, 25);
            lblTurnosOcupados.TabIndex = 14;
            lblTurnosOcupados.Text = "Turnos ocupados:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(461, 373);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 25);
            label6.TabIndex = 11;
            label6.Text = "Día:";
            // 
            // dtpDiaAtencion
            // 
            dtpDiaAtencion.Format = DateTimePickerFormat.Short;
            dtpDiaAtencion.Location = new Point(526, 363);
            dtpDiaAtencion.Margin = new Padding(4, 5, 4, 5);
            dtpDiaAtencion.Name = "dtpDiaAtencion";
            dtpDiaAtencion.Size = new Size(177, 31);
            dtpDiaAtencion.TabIndex = 12;
            dtpDiaAtencion.Value = new DateTime(2025, 10, 21, 0, 0, 0, 0);
            dtpDiaAtencion.ValueChanged += dtpDiaAtencion_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(421, 137);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(80, 25);
            label7.TabIndex = 3;
            label7.Text = "Paciente:";
            // 
            // txtNomYApe
            // 
            txtNomYApe.Location = new Point(526, 132);
            txtNomYApe.Margin = new Padding(4, 5, 4, 5);
            txtNomYApe.Name = "txtNomYApe";
            txtNomYApe.ReadOnly = true;
            txtNomYApe.Size = new Size(177, 31);
            txtNomYApe.TabIndex = 4;
            // 
            // btnBuscarTurnos
            // 
            btnBuscarTurnos.Location = new Point(741, 363);
            btnBuscarTurnos.Margin = new Padding(4, 5, 4, 5);
            btnBuscarTurnos.Name = "btnBuscarTurnos";
            btnBuscarTurnos.Size = new Size(184, 38);
            btnBuscarTurnos.TabIndex = 13;
            btnBuscarTurnos.Text = "Buscar turnos";
            btnBuscarTurnos.UseVisualStyleBackColor = true;
            btnBuscarTurnos.Click += btnBuscarTurnos_Click;
            // 
            // btnAgregarAtencion
            // 
            btnAgregarAtencion.Location = new Point(654, 845);
            btnAgregarAtencion.Margin = new Padding(4, 5, 4, 5);
            btnAgregarAtencion.Name = "btnAgregarAtencion";
            btnAgregarAtencion.Size = new Size(131, 62);
            btnAgregarAtencion.TabIndex = 16;
            btnAgregarAtencion.Text = "Agregar";
            btnAgregarAtencion.UseVisualStyleBackColor = true;
            btnAgregarAtencion.Click += btnAgregarAtencion_Click;
            // 
            // cmbHorario
            // 
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(530, 792);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(183, 33);
            cmbHorario.TabIndex = 17;
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(335, 797);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(180, 25);
            lblHorario.TabIndex = 18;
            lblHorario.Text = "Horarios disponibles:";
            // 
            // lblTurnos
            // 
            lblTurnos.AutoSize = true;
            lblTurnos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTurnos.ForeColor = Color.DarkGreen;
            lblTurnos.Location = new Point(530, 497);
            lblTurnos.Margin = new Padding(4, 0, 4, 0);
            lblTurnos.Name = "lblTurnos";
            lblTurnos.Size = new Size(454, 25);
            lblTurnos.TabIndex = 19;
            lblTurnos.Text = "Todos los horarios del odontólogo estan disponibles";
            lblTurnos.Visible = false;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.Red;
            lblAviso.Location = new Point(943, 368);
            lblAviso.Margin = new Padding(4, 0, 4, 0);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(224, 25);
            lblAviso.TabIndex = 20;
            lblAviso.Text = "Faltan completar campos";
            // 
            // btnCancelarAtencion
            // 
            btnCancelarAtencion.Location = new Point(976, 850);
            btnCancelarAtencion.Margin = new Padding(4, 5, 4, 5);
            btnCancelarAtencion.Name = "btnCancelarAtencion";
            btnCancelarAtencion.Size = new Size(217, 57);
            btnCancelarAtencion.TabIndex = 21;
            btnCancelarAtencion.Text = "Cancelar atencion";
            btnCancelarAtencion.UseVisualStyleBackColor = true;
            btnCancelarAtencion.Click += btnCancelarAtencion_Click;
            // 
            // btnEditarAtencion
            // 
            btnEditarAtencion.Location = new Point(819, 850);
            btnEditarAtencion.Name = "btnEditarAtencion";
            btnEditarAtencion.Size = new Size(134, 57);
            btnEditarAtencion.TabIndex = 22;
            btnEditarAtencion.Text = "Editar";
            btnEditarAtencion.UseVisualStyleBackColor = true;
            btnEditarAtencion.Click += btnEditarAtencion_Click;
            // 
            // lblDiaHorarioActual
            // 
            lblDiaHorarioActual.AutoSize = true;
            lblDiaHorarioActual.Location = new Point(375, 427);
            lblDiaHorarioActual.Name = "lblDiaHorarioActual";
            lblDiaHorarioActual.Size = new Size(126, 25);
            lblDiaHorarioActual.TabIndex = 23;
            lblDiaHorarioActual.Text = "Horario Actual";
            // 
            // txtDiaHorarioActual
            // 
            txtDiaHorarioActual.Location = new Point(526, 421);
            txtDiaHorarioActual.Name = "txtDiaHorarioActual";
            txtDiaHorarioActual.ReadOnly = true;
            txtDiaHorarioActual.Size = new Size(177, 31);
            txtDiaHorarioActual.TabIndex = 24;
            // 
            // FormAtencion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1273, 928);
            Controls.Add(txtDiaHorarioActual);
            Controls.Add(lblDiaHorarioActual);
            Controls.Add(btnEditarAtencion);
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
            Margin = new Padding(4, 5, 4, 5);
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
        private Button btnEditarAtencion;
        private Label lblDiaHorarioActual;
        private TextBox txtDiaHorarioActual;
    }
}