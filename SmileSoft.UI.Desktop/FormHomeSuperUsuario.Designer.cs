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
            BtnCerrarSesion = new Button();
            menuStrip1 = new MenuStrip();
            toolStripPaciente = new ToolStripMenuItem();
            toolStripOS = new ToolStripMenuItem();
            toolStripUsuarios = new ToolStripMenuItem();
            toolStripTipoPlan = new ToolStripMenuItem();
            toolStripTipoAtencion = new ToolStripMenuItem();
            odontologosToolStripMenuItem = new ToolStripMenuItem();
            tutoresToolStripMenuItem = new ToolStripMenuItem();
            atencionesToolStripMenuItem = new ToolStripMenuItem();
            lblNombreSuperUsuario = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
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
            BtnCerrarSesion.Click += BtnCerrarSesion_Click;
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
            // atencionesToolStripMenuItem
            // 
            atencionesToolStripMenuItem.Name = "atencionesToolStripMenuItem";
            atencionesToolStripMenuItem.Size = new Size(78, 20);
            atencionesToolStripMenuItem.Text = "Atenciones";
            atencionesToolStripMenuItem.Click += atencionesToolStripMenuItem_Click;
            // 
            // lblNombreSuperUsuario
            // 
            lblNombreSuperUsuario.AutoSize = true;
            lblNombreSuperUsuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreSuperUsuario.Location = new Point(26, 39);
            lblNombreSuperUsuario.Name = "lblNombreSuperUsuario";
            lblNombreSuperUsuario.Size = new Size(173, 25);
            lblNombreSuperUsuario.TabIndex = 10;
            lblNombreSuperUsuario.Text = "Bienvenido admin";
            // 
            // FormHomeSuperUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 349);
            Controls.Add(lblNombreSuperUsuario);
            Controls.Add(BtnCerrarSesion);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "FormHomeSuperUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormHome";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnCerrarSesion;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripPaciente;
        private ToolStripMenuItem toolStripOS;
        private ToolStripMenuItem toolStripUsuarios;
        private ToolStripMenuItem toolStripTipoPlan;
        private ToolStripMenuItem toolStripTipoAtencion;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem odontologosToolStripMenuItem;
        private ToolStripMenuItem tutoresToolStripMenuItem;
        private ToolStripMenuItem atencionesToolStripMenuItem;
        private Label lblNombreSuperUsuario;
    }
}