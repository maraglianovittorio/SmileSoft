namespace SmileSoft.UI.Desktop
{
    partial class FormHomeSuperUsuario
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
            btnPacientes = new Button();
            btnObraSocial = new Button();
            btnUsuarios = new Button();
            btnTipoPlan = new Button();
            btnTipoAtencion = new Button();
            btnMenuAlt = new Button();
            BtnCerrarSesion = new Button();
            menuStrip1 = new MenuStrip();
            toolStripPaciente = new ToolStripMenuItem();
            toolStripOS = new ToolStripMenuItem();
            toolStripUsuarios = new ToolStripMenuItem();
            toolStripTipoPlan = new ToolStripMenuItem();
            toolStripTipoAtencion = new ToolStripMenuItem();
            odontologosToolStripMenuItem = new ToolStripMenuItem();
            tutoresToolStripMenuItem = new ToolStripMenuItem();
            NuevaAtencion = new Button();
            atencionesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPacientes
            // 
            btnPacientes.Location = new Point(46, 57);
            btnPacientes.Margin = new Padding(2);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(109, 46);
            btnPacientes.TabIndex = 0;
            btnPacientes.Text = "Pacientes";
            btnPacientes.UseVisualStyleBackColor = true;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnObraSocial
            // 
            btnObraSocial.Location = new Point(223, 57);
            btnObraSocial.Margin = new Padding(2);
            btnObraSocial.Name = "btnObraSocial";
            btnObraSocial.Size = new Size(124, 46);
            btnObraSocial.TabIndex = 1;
            btnObraSocial.Text = "Obras Sociales";
            btnObraSocial.UseVisualStyleBackColor = true;
            btnObraSocial.Click += btnObraSocial_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(401, 57);
            btnUsuarios.Margin = new Padding(2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(111, 46);
            btnUsuarios.TabIndex = 2;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnTipoPlan
            // 
            btnTipoPlan.Location = new Point(573, 57);
            btnTipoPlan.Margin = new Padding(2);
            btnTipoPlan.Name = "btnTipoPlan";
            btnTipoPlan.Size = new Size(111, 46);
            btnTipoPlan.TabIndex = 3;
            btnTipoPlan.Text = "Tipos Plan";
            btnTipoPlan.UseVisualStyleBackColor = true;
            btnTipoPlan.Click += btnTipoPlan_Click;
            // 
            // btnTipoAtencion
            // 
            btnTipoAtencion.Location = new Point(46, 159);
            btnTipoAtencion.Margin = new Padding(2);
            btnTipoAtencion.Name = "btnTipoAtencion";
            btnTipoAtencion.Size = new Size(118, 60);
            btnTipoAtencion.TabIndex = 4;
            btnTipoAtencion.Text = "Tipos Atencion";
            btnTipoAtencion.UseVisualStyleBackColor = true;
            btnTipoAtencion.Click += btnTipoAtencion_Click;
            // 
            // btnMenuAlt
            // 
            btnMenuAlt.BackColor = Color.Orange;
            btnMenuAlt.ForeColor = SystemColors.MenuHighlight;
            btnMenuAlt.Location = new Point(223, 159);
            btnMenuAlt.Margin = new Padding(2);
            btnMenuAlt.Name = "btnMenuAlt";
            btnMenuAlt.Size = new Size(114, 60);
            btnMenuAlt.TabIndex = 5;
            btnMenuAlt.Text = "Menu alernativo";
            btnMenuAlt.UseVisualStyleBackColor = false;
            btnMenuAlt.Click += btnMenuAlt_Click;
            // 
            // BtnCerrarSesion
            // 
            BtnCerrarSesion.BackColor = SystemColors.ActiveCaption;
            BtnCerrarSesion.Location = new Point(702, 296);
            BtnCerrarSesion.Name = "BtnCerrarSesion";
            BtnCerrarSesion.Size = new Size(133, 41);
            BtnCerrarSesion.TabIndex = 8;
            BtnCerrarSesion.Text = "Cerrar sesion";
            BtnCerrarSesion.UseVisualStyleBackColor = false;
            BtnCerrarSesion.Click += BtnVolver_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripPaciente, toolStripOS, toolStripUsuarios, toolStripTipoPlan, toolStripTipoAtencion, odontologosToolStripMenuItem, tutoresToolStripMenuItem, atencionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(858, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripPaciente
            // 
            toolStripPaciente.Name = "toolStripPaciente";
            toolStripPaciente.Size = new Size(69, 20);
            toolStripPaciente.Text = "Pacientes";
            toolStripPaciente.Click += toolStripPaciente_Click;
            // 
            // toolStripOS
            // 
            toolStripOS.Name = "toolStripOS";
            toolStripOS.Size = new Size(95, 20);
            toolStripOS.Text = "Obras Sociales";
            toolStripOS.Click += toolStripOS_Click;
            // 
            // toolStripUsuarios
            // 
            toolStripUsuarios.Name = "toolStripUsuarios";
            toolStripUsuarios.Size = new Size(64, 20);
            toolStripUsuarios.Text = "Usuarios";
            toolStripUsuarios.Click += toolStripUsuarios_Click;
            // 
            // toolStripTipoPlan
            // 
            toolStripTipoPlan.Name = "toolStripTipoPlan";
            toolStripTipoPlan.Size = new Size(73, 20);
            toolStripTipoPlan.Text = "Tipos plan";
            toolStripTipoPlan.Click += toolStripTipoPlan_Click;
            // 
            // toolStripTipoAtencion
            // 
            toolStripTipoAtencion.Name = "toolStripTipoAtencion";
            toolStripTipoAtencion.Size = new Size(96, 20);
            toolStripTipoAtencion.Text = "Tipos atencion";
            toolStripTipoAtencion.Click += toolStripTipoAtencion_Click;
            // 
            // odontologosToolStripMenuItem
            // 
            odontologosToolStripMenuItem.Name = "odontologosToolStripMenuItem";
            odontologosToolStripMenuItem.Size = new Size(89, 20);
            odontologosToolStripMenuItem.Text = "Odontologos";
            odontologosToolStripMenuItem.Click += odontologosToolStripMenuItem_Click;
            // 
            // tutoresToolStripMenuItem
            // 
            tutoresToolStripMenuItem.Name = "tutoresToolStripMenuItem";
            tutoresToolStripMenuItem.Size = new Size(58, 20);
            tutoresToolStripMenuItem.Text = "Tutores";
            tutoresToolStripMenuItem.Click += tutoresToolStripMenuItem_Click;
            // 
            // NuevaAtencion
            // 
            NuevaAtencion.BackColor = Color.Orange;
            NuevaAtencion.ForeColor = SystemColors.Highlight;
            NuevaAtencion.Location = new Point(390, 159);
            NuevaAtencion.Name = "NuevaAtencion";
            NuevaAtencion.Size = new Size(113, 53);
            NuevaAtencion.TabIndex = 10;
            NuevaAtencion.Text = "Nueva atención";
            NuevaAtencion.UseVisualStyleBackColor = false;
            NuevaAtencion.Click += NuevaAtencion_Click;
            // 
            // atencionesToolStripMenuItem
            // 
            atencionesToolStripMenuItem.Name = "atencionesToolStripMenuItem";
            atencionesToolStripMenuItem.Size = new Size(78, 20);
            atencionesToolStripMenuItem.Text = "Atenciones";
            atencionesToolStripMenuItem.Click += atencionesToolStripMenuItem_Click;
            // 
            // FormHomeSuperUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 349);
            Controls.Add(NuevaAtencion);
            Controls.Add(BtnCerrarSesion);
            Controls.Add(btnMenuAlt);
            Controls.Add(btnTipoAtencion);
            Controls.Add(btnTipoPlan);
            Controls.Add(btnUsuarios);
            Controls.Add(btnObraSocial);
            Controls.Add(btnPacientes);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "FormHomeSuperUsuario";
            Text = "FormHome";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPacientes;
        private Button btnObraSocial;
        private Button btnUsuarios;
        private Button btnTipoPlan;
        private Button btnTipoAtencion;
        private Button btnMenuAlt;
        private Button BtnCerrarSesion;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripPaciente;
        private ToolStripMenuItem toolStripOS;
        private ToolStripMenuItem toolStripUsuarios;
        private ToolStripMenuItem toolStripTipoPlan;
        private ToolStripMenuItem toolStripTipoAtencion;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private Button NuevaAtencion;
        private ToolStripMenuItem odontologosToolStripMenuItem;
        private ToolStripMenuItem tutoresToolStripMenuItem;
        private ToolStripMenuItem atencionesToolStripMenuItem;
    }
}