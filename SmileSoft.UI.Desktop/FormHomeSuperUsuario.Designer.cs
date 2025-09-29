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
            // FormHomeSuperUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 349);
            Controls.Add(BtnCerrarSesion);
            Controls.Add(btnMenuAlt);
            Controls.Add(btnTipoAtencion);
            Controls.Add(btnTipoPlan);
            Controls.Add(btnUsuarios);
            Controls.Add(btnObraSocial);
            Controls.Add(btnPacientes);
            Margin = new Padding(2);
            Name = "FormHomeSuperUsuario";
            Text = "FormHome";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPacientes;
        private Button btnObraSocial;
        private Button btnUsuarios;
        private Button btnTipoPlan;
        private Button btnTipoAtencion;
        private Button btnMenuAlt;
        private Button BtnCerrarSesion;
    }
}