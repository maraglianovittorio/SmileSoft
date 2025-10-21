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
            label1 = new Label();
            lblDni = new Label();
            txtDni = new TextBox();
            label2 = new Label();
            txtOS = new TextBox();
            btnBuscarPaciente = new Button();
            label3 = new Label();
            cmbTipoAtencion = new ComboBox();
            label4 = new Label();
            cmbOdontologo = new ComboBox();
            dgvTurnosDisponibles = new DataGridView();
            lblTurnosOcupados = new Label();
            label6 = new Label();
            dtpDiaAtencion = new DateTimePicker();
            label7 = new Label();
            txtNomYApe = new TextBox();
            btnBuscarTurnos = new Button();
            btnAgregarAtencion = new Button();
            cmbHorario = new ComboBox();
            lblHorario = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosDisponibles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(287, 9);
            label1.Name = "label1";
            label1.Size = new Size(182, 32);
            label1.TabIndex = 0;
            label1.Text = "Nueva atención";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(275, 53);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(28, 15);
            lblDni.TabIndex = 0;
            lblDni.Text = "Dni:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(321, 50);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 23);
            txtDni.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 117);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Obra social:";
            // 
            // txtOS
            // 
            txtOS.Location = new Point(321, 114);
            txtOS.Name = "txtOS";
            txtOS.ReadOnly = true;
            txtOS.Size = new Size(125, 23);
            txtOS.TabIndex = 6;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(472, 50);
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
            label3.Location = new Point(205, 153);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 7;
            label3.Text = "Tipo de atencion:";
            // 
            // cmbTipoAtencion
            // 
            cmbTipoAtencion.FormattingEnabled = true;
            cmbTipoAtencion.Location = new Point(321, 150);
            cmbTipoAtencion.Name = "cmbTipoAtencion";
            cmbTipoAtencion.Size = new Size(125, 23);
            cmbTipoAtencion.TabIndex = 8;
            cmbTipoAtencion.SelectedValueChanged += cmb_SelectedValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 187);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 9;
            label4.Text = "Odontólogo:";
            // 
            // cmbOdontologo
            // 
            cmbOdontologo.FormattingEnabled = true;
            cmbOdontologo.Location = new Point(321, 184);
            cmbOdontologo.Name = "cmbOdontologo";
            cmbOdontologo.Size = new Size(125, 23);
            cmbOdontologo.TabIndex = 10;
            cmbOdontologo.SelectedValueChanged += cmb_SelectedValueChanged;
            // 
            // dgvTurnosDisponibles
            // 
            dgvTurnosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosDisponibles.Location = new Point(130, 270);
            dgvTurnosDisponibles.Name = "dgvTurnosDisponibles";
            dgvTurnosDisponibles.RowHeadersWidth = 62;
            dgvTurnosDisponibles.Size = new Size(609, 146);
            dgvTurnosDisponibles.TabIndex = 15;
            // 
            // lblTurnosOcupados
            // 
            lblTurnosOcupados.AutoSize = true;
            lblTurnosOcupados.Location = new Point(202, 252);
            lblTurnosOcupados.Name = "lblTurnosOcupados";
            lblTurnosOcupados.Size = new Size(101, 15);
            lblTurnosOcupados.TabIndex = 14;
            lblTurnosOcupados.Text = "Turnos ocupados:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(276, 224);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 11;
            label6.Text = "Día:";
            // 
            // dtpDiaAtencion
            // 
            dtpDiaAtencion.Format = DateTimePickerFormat.Short;
            dtpDiaAtencion.Location = new Point(321, 218);
            dtpDiaAtencion.Name = "dtpDiaAtencion";
            dtpDiaAtencion.Size = new Size(125, 23);
            dtpDiaAtencion.TabIndex = 12;
            dtpDiaAtencion.Value = new DateTime(2025, 10, 20, 0, 0, 0, 0);
            dtpDiaAtencion.ValueChanged += dtpDiaAtencion_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(248, 82);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 3;
            label7.Text = "Paciente:";
            // 
            // txtNomYApe
            // 
            txtNomYApe.Location = new Point(321, 79);
            txtNomYApe.Name = "txtNomYApe";
            txtNomYApe.ReadOnly = true;
            txtNomYApe.Size = new Size(125, 23);
            txtNomYApe.TabIndex = 4;
            // 
            // btnBuscarTurnos
            // 
            btnBuscarTurnos.Location = new Point(472, 218);
            btnBuscarTurnos.Name = "btnBuscarTurnos";
            btnBuscarTurnos.Size = new Size(129, 23);
            btnBuscarTurnos.TabIndex = 13;
            btnBuscarTurnos.Text = "Buscar turnos";
            btnBuscarTurnos.UseVisualStyleBackColor = true;
            btnBuscarTurnos.Click += btnBuscarTurnos_Click;
            // 
            // btnAgregarAtencion
            // 
            btnAgregarAtencion.Location = new Point(647, 508);
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
            cmbHorario.Location = new Point(321, 429);
            cmbHorario.Margin = new Padding(2);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(129, 23);
            cmbHorario.TabIndex = 17;
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(185, 432);
            lblHorario.Margin = new Padding(2, 0, 2, 0);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(118, 15);
            lblHorario.TabIndex = 18;
            lblHorario.Text = "Horarios disponibles:";
            // 
            // FormAtencion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 557);
            Controls.Add(lblHorario);
            Controls.Add(cmbHorario);
            Controls.Add(btnAgregarAtencion);
            Controls.Add(btnBuscarTurnos);
            Controls.Add(txtNomYApe);
            Controls.Add(label7);
            Controls.Add(dtpDiaAtencion);
            Controls.Add(label6);
            Controls.Add(lblTurnosOcupados);
            Controls.Add(dgvTurnosDisponibles);
            Controls.Add(cmbOdontologo);
            Controls.Add(label4);
            Controls.Add(cmbTipoAtencion);
            Controls.Add(label3);
            Controls.Add(btnBuscarPaciente);
            Controls.Add(txtOS);
            Controls.Add(label2);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(label1);
            Name = "FormAtencion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva atención";
            Load += FormAtencion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTurnosDisponibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblDni;
        private TextBox txtDni;
        private Label label2;
        private TextBox txtOS;
        private Button btnBuscarPaciente;
        private Label label3;
        private ComboBox cmbTipoAtencion;
        private Label label4;
        private ComboBox cmbOdontologo;
        private DataGridView dgvTurnosDisponibles;
        private Label lblTurnosOcupados;
        private Label label6;
        private DateTimePicker dtpDiaAtencion;
        private Label label7;
        private TextBox txtNomYApe;
        private Button btnBuscarTurnos;
        private Button btnAgregarAtencion;
        private ComboBox cmbHorario;
        private Label lblHorario;
    }
}