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
            textBox1 = new TextBox();
            btnBuscarPaciente = new Button();
            label3 = new Label();
            cbTipoAtencion = new ComboBox();
            label4 = new Label();
            cbOdontologo = new ComboBox();
            dgvTurnosDisponibles = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            dtpDia = new DateTimePicker();
            label7 = new Label();
            txtNomYApe = new TextBox();
            btnBuscarTurnos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosDisponibles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(278, 24);
            label1.Name = "label1";
            label1.Size = new Size(182, 32);
            label1.TabIndex = 0;
            label1.Text = "Nueva atención";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(208, 83);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(95, 15);
            lblDni.TabIndex = 1;
            lblDni.Text = "Dni del paciente:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(321, 80);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 117);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Obra social:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(321, 114);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(442, 79);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.Size = new Size(75, 23);
            btnBuscarPaciente.TabIndex = 5;
            btnBuscarPaciente.Text = "Buscar";
            btnBuscarPaciente.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(205, 153);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 6;
            label3.Text = "Tipo de atencion:";
            // 
            // cbTipoAtencion
            // 
            cbTipoAtencion.FormattingEnabled = true;
            cbTipoAtencion.Location = new Point(321, 150);
            cbTipoAtencion.Name = "cbTipoAtencion";
            cbTipoAtencion.Size = new Size(121, 23);
            cbTipoAtencion.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 192);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 8;
            label4.Text = "Odontólogo:";
            // 
            // cbOdontologo
            // 
            cbOdontologo.FormattingEnabled = true;
            cbOdontologo.Location = new Point(321, 189);
            cbOdontologo.Name = "cbOdontologo";
            cbOdontologo.Size = new Size(121, 23);
            cbOdontologo.TabIndex = 9;
            // 
            // dgvTurnosDisponibles
            // 
            dgvTurnosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosDisponibles.Location = new Point(130, 270);
            dgvTurnosDisponibles.Name = "dgvTurnosDisponibles";
            dgvTurnosDisponibles.Size = new Size(609, 146);
            dgvTurnosDisponibles.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(194, 243);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 13;
            label5.Text = "Turnos disponibles:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(276, 218);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 14;
            label6.Text = "Día:";
            // 
            // dtpDia
            // 
            dtpDia.Location = new Point(317, 218);
            dtpDia.Name = "dtpDia";
            dtpDia.Size = new Size(256, 23);
            dtpDia.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(574, 61);
            label7.Name = "label7";
            label7.Size = new Size(108, 15);
            label7.TabIndex = 16;
            label7.Text = "Nombre y apellido:";
            // 
            // txtNomYApe
            // 
            txtNomYApe.Location = new Point(561, 80);
            txtNomYApe.Name = "txtNomYApe";
            txtNomYApe.ReadOnly = true;
            txtNomYApe.Size = new Size(161, 23);
            txtNomYApe.TabIndex = 17;
            // 
            // btnBuscarTurnos
            // 
            btnBuscarTurnos.Location = new Point(593, 220);
            btnBuscarTurnos.Name = "btnBuscarTurnos";
            btnBuscarTurnos.Size = new Size(129, 23);
            btnBuscarTurnos.TabIndex = 18;
            btnBuscarTurnos.Text = "Buscar turnos";
            btnBuscarTurnos.UseVisualStyleBackColor = true;
            // 
            // FormAtencion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBuscarTurnos);
            Controls.Add(txtNomYApe);
            Controls.Add(label7);
            Controls.Add(dtpDia);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dgvTurnosDisponibles);
            Controls.Add(cbOdontologo);
            Controls.Add(label4);
            Controls.Add(cbTipoAtencion);
            Controls.Add(label3);
            Controls.Add(btnBuscarPaciente);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(label1);
            Name = "FormAtencion";
            Text = "Nueva atención";
            ((System.ComponentModel.ISupportInitialize)dgvTurnosDisponibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblDni;
        private TextBox txtDni;
        private Label label2;
        private TextBox textBox1;
        private Button btnBuscarPaciente;
        private Label label3;
        private ComboBox cbTipoAtencion;
        private Label label4;
        private ComboBox cbOdontologo;
        private DataGridView dgvTurnosDisponibles;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpDia;
        private Label label7;
        private TextBox txtNomYApe;
        private Button btnBuscarTurnos;
    }
}