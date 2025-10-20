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
            label1.Location = new Point(397, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(267, 48);
            label1.TabIndex = 0;
            label1.Text = "Nueva atención";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(297, 138);
            lblDni.Margin = new Padding(4, 0, 4, 0);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(143, 25);
            lblDni.TabIndex = 0;
            lblDni.Text = "Dni del paciente:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(459, 133);
            txtDni.Margin = new Padding(4, 5, 4, 5);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(141, 31);
            txtDni.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(334, 195);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 5;
            label2.Text = "Obra social:";
            // 
            // txtOS
            // 
            txtOS.Location = new Point(459, 190);
            txtOS.Margin = new Padding(4, 5, 4, 5);
            txtOS.Name = "txtOS";
            txtOS.ReadOnly = true;
            txtOS.Size = new Size(141, 31);
            txtOS.TabIndex = 6;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(631, 132);
            btnBuscarPaciente.Margin = new Padding(4, 5, 4, 5);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.Size = new Size(107, 38);
            btnBuscarPaciente.TabIndex = 2;
            btnBuscarPaciente.Text = "Buscar";
            btnBuscarPaciente.UseVisualStyleBackColor = true;
            btnBuscarPaciente.Click += btnBuscarPaciente_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(293, 255);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 25);
            label3.TabIndex = 7;
            label3.Text = "Tipo de atencion:";
            // 
            // cmbTipoAtencion
            // 
            cmbTipoAtencion.FormattingEnabled = true;
            cmbTipoAtencion.Location = new Point(459, 250);
            cmbTipoAtencion.Margin = new Padding(4, 5, 4, 5);
            cmbTipoAtencion.Name = "cmbTipoAtencion";
            cmbTipoAtencion.Size = new Size(171, 33);
            cmbTipoAtencion.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(326, 320);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 9;
            label4.Text = "Odontólogo:";
            // 
            // cmbOdontologo
            // 
            cmbOdontologo.FormattingEnabled = true;
            cmbOdontologo.Location = new Point(459, 315);
            cmbOdontologo.Margin = new Padding(4, 5, 4, 5);
            cmbOdontologo.Name = "cmbOdontologo";
            cmbOdontologo.Size = new Size(171, 33);
            cmbOdontologo.TabIndex = 10;
            // 
            // dgvTurnosDisponibles
            // 
            dgvTurnosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosDisponibles.Location = new Point(186, 450);
            dgvTurnosDisponibles.Margin = new Padding(4, 5, 4, 5);
            dgvTurnosDisponibles.Name = "dgvTurnosDisponibles";
            dgvTurnosDisponibles.RowHeadersWidth = 62;
            dgvTurnosDisponibles.Size = new Size(870, 243);
            dgvTurnosDisponibles.TabIndex = 15;
            // 
            // lblTurnosOcupados
            // 
            lblTurnosOcupados.AutoSize = true;
            lblTurnosOcupados.Location = new Point(277, 405);
            lblTurnosOcupados.Margin = new Padding(4, 0, 4, 0);
            lblTurnosOcupados.Name = "lblTurnosOcupados";
            lblTurnosOcupados.Size = new Size(154, 25);
            lblTurnosOcupados.TabIndex = 14;
            lblTurnosOcupados.Text = "Turnos ocupados:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(394, 363);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 25);
            label6.TabIndex = 11;
            label6.Text = "Día:";
            // 
            // dtpDiaAtencion
            // 
            dtpDiaAtencion.Location = new Point(453, 363);
            dtpDiaAtencion.Margin = new Padding(4, 5, 4, 5);
            dtpDiaAtencion.Name = "dtpDiaAtencion";
            dtpDiaAtencion.Size = new Size(364, 31);
            dtpDiaAtencion.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(820, 102);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(164, 25);
            label7.TabIndex = 3;
            label7.Text = "Nombre y apellido:";
            // 
            // txtNomYApe
            // 
            txtNomYApe.Location = new Point(801, 133);
            txtNomYApe.Margin = new Padding(4, 5, 4, 5);
            txtNomYApe.Name = "txtNomYApe";
            txtNomYApe.ReadOnly = true;
            txtNomYApe.Size = new Size(228, 31);
            txtNomYApe.TabIndex = 4;
            // 
            // btnBuscarTurnos
            // 
            btnBuscarTurnos.Location = new Point(847, 367);
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
            btnAgregarAtencion.Location = new Point(541, 770);
            btnAgregarAtencion.Margin = new Padding(4, 5, 4, 5);
            btnAgregarAtencion.Name = "btnAgregarAtencion";
            btnAgregarAtencion.Size = new Size(107, 38);
            btnAgregarAtencion.TabIndex = 16;
            btnAgregarAtencion.Text = "Agregar";
            btnAgregarAtencion.UseVisualStyleBackColor = true;
            btnAgregarAtencion.Click += btnAgregarAtencion_Click;
            // 
            // cmbHorario
            // 
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(508, 715);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(182, 33);
            cmbHorario.TabIndex = 17;
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(347, 715);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(72, 25);
            lblHorario.TabIndex = 18;
            lblHorario.Text = "Horario";
            // 
            // FormAtencion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 918);
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
            Margin = new Padding(4, 5, 4, 5);
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